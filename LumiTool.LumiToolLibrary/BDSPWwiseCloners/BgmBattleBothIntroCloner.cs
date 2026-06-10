using LumiTool.Data.Wwise;
using LumiTool.Data;
using LumiTool.Engine;
using LumiTool.Utils;

namespace LumiTool.BDSPWwiseCloners
{
    public class BgmBattleBothIntroCloner : BaseCloner
    {
        public BgmBattleBothIntroCloner(LumiToolEngine engine) : base(engine) { }

        public override bool ExecuteClone(WwiseData wd, string newEventName, WwiseLoopPointData loopData, WwiseLoopPointData dsLoopData)
        {
            uint oldEventID = engine.FNV132Hash("BA001"); // Also the ID of the old State in the State Group
            uint newEventID = engine.FNV132Hash(newEventName); // Also the ID of the new State in the State Group
            uint groupID = engine.FNV132Hash("BGM_BATTLE");

            engine.Log($"Creating new event {newEventID} ({newEventName}) which affects group {groupID} (BGM_BATTLE)", LogLevel.Information);

            Dictionary<uint, uint> update = new();

            CloneEventAndActions(wd, oldEventID, newEventID, groupID, update);

            HircChunk hc = (HircChunk)wd.banks[0].chunks.First(c => c is HircChunk);

            // Find all MusicSwitchCntr that check this State Group
            List<MusicSwitchCntr> mscs = hc.loadedItem.Where(hi => hi is MusicSwitchCntr msc && msc.arguments
                .Any(gs => gs.group == groupID))
                .Cast<MusicSwitchCntr>()
                .ToList();

            List<uint> oldMusicRanSeqCntrIDs = UpdateMusicRanSeqCntrs(wd, mscs, oldEventID, newEventID, groupID, update, 275563224, 429717840, 524767234, 642505365);

            // Clone the old MusicRanSeqCntrs
            List<MusicRanSeqCntr> mrscs = oldMusicRanSeqCntrIDs.Select(i => ((MusicRanSeqCntr)wd.objectsByID[i]).Clone()).ToList();

            // List all the PlaylistItems recursively
            List<MusicRanSeqPlaylistItem> mrspis = mrscs.SelectMany(mrsc => mrsc.playList).FlattenRecursive(pi => pi.playList).ToList();

            SetupPlaylistItems(wd, mrscs, update);

            // MusicRanSeqCntr contains MusicSegments, which we also clone
            var splitSegments = mrscs.Select(mrsc => mrsc.musicTransNodeParams.musicNodeParams.children.childIDs
                    .Select(i => ((MusicSegment)wd.objectsByID[i]).Clone())
                    .ToList())
                .ToList();

            // Collect the MusicSegments into one big list
            List<MusicSegment> mss = splitSegments.SelectMany(x => x).ToList();

            AdjustLoopPointsInMusicSegments(splitSegments, new Dictionary<(int segmentIndex, uint segmentID), WwiseLoopPointData>()
            {
                { (0, 87947217), loopData.CloneForIntro() },    // First segment (Regular)
                { (1, 879792264), loopData.CloneForLoop() },    // Second segment (Regular)
                { (0, 118470410), dsLoopData.CloneForIntro() }, // First segment (DS)
                { (1, 99051959), dsLoopData.CloneForLoop() },   // Second segment (DS)
            });

            GenerateNewMusicSegmentIDs(wd, mss, update);

            // MusicSegments contain MusicTracks, which we also clone
            var splitTracks = splitSegments.Select(mrsc => mrsc.Select(ms => ms.musicNodeParams.children.childIDs
                        .Select(i => ((MusicTrack)wd.objectsByID[i]).Clone())
                        .ToList())
                    .ToList())
                .ToList();

            // Collect the MusicTracks into one big list
            List<MusicTrack> mts = splitTracks.SelectMany(x => x).SelectMany(x => x).ToList();

            AdjustLoopPointsInMusicTracks(splitTracks, new Dictionary<(int segmentIndex, int trackIndex, uint trackID, int playlistItemIndex), WwiseLoopPointData>()
            {
                { (0, 0, 374048914, 0), loopData.CloneForIntro() },   // First segment, first track, first playlist item (Regular)
                { (1, 0, 116833099, 0), loopData.CloneForLoop() },    // Second segment, first track, first playlist item (Regular)
                { (0, 0, 579154598, 0), dsLoopData.CloneForIntro() }, // First segment, first track, first playlist item (DS)
                { (1, 0, 877168764, 0), dsLoopData.CloneForLoop() },  // Second segment, first track, first playlist item (DS)
            });

            GenerateNewMusicTrackAndSourceIDs(wd, mts, update, 498926385, 414103803);

            UpdateAllFinalIDs(mscs, mrscs, mrspis, mss, mts, update);

            return true;
        }
    }
}
