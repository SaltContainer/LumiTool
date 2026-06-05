using LumiTool.Data.Wwise;
using LumiTool.Data;
using LumiTool.Engine;
using LumiTool.Utils;

namespace LumiTool.BDSPWwiseCloners
{
    public class BgmFieldBothIntroCloner : BaseCloner
    {
        public BgmFieldBothIntroCloner(LumiToolEngine engine) : base(engine) { }

        public override bool ExecuteClone(WwiseData wd, string newEventName, WwiseLoopPointData loopData, WwiseLoopPointData dsLoopData)
        {
            uint oldEventID = engine.FNV132Hash("D05"); // Also the ID of the old State in the State Group
            uint newEventID = engine.FNV132Hash(newEventName); // Also the ID of the new State in the State Group
            uint groupID = engine.FNV132Hash("BGM_FIELD");

            engine.Log($"Creating new event {newEventID} ({newEventName}) which affects group {groupID} (BGM_FIELD)", LogLevel.Information);

            Dictionary<uint, uint> update = new();

            CloneEventAndActions(wd, oldEventID, newEventID, update);

            HircChunk hc = (HircChunk)wd.banks[0].chunks.First(c => c is HircChunk);

            // Find all MusicSwitchCntr that check this State Group
            List<MusicSwitchCntr> mscs = hc.loadedItem.Where(hi => hi is MusicSwitchCntr msc && msc.arguments
                .Any(gs => gs.group == groupID))
                .Cast<MusicSwitchCntr>()
                .ToList();

            List<uint> oldMusicRanSeqCntrIDs = UpdateMusicRanSeqCntrs(wd, mscs, oldEventID, newEventID, groupID, update, 805188190, 319787682, 407871725, 935782994);

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

            AdjustLoopPointsInMusicSegments(splitSegments, new Dictionary<(int i, uint id), WwiseLoopPointData>()
            {
                { (0, 276947786), loopData.CloneForLoop() },    // First segment (Regular)
                { (1, 1070756379), loopData.CloneForIntro() },  // Second segment (Regular)
                { (0, 139029859), dsLoopData.CloneForIntro() }, // First segment (DS)
                { (1, 339155458), dsLoopData.CloneForLoop() },  // Second segment (DS)
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

            AdjustLoopPointsInMusicTracks(splitTracks, new Dictionary<(int i, int j, uint id, int k), WwiseLoopPointData>()
            {
                { (0, 0, 386023986, 0), loopData.CloneForLoop() },    // First segment, first track, first playlist item (Regular)
                { (1, 0, 423543179, 0), loopData.CloneForIntro() },   // Second segment, first track, first playlist item (Regular)
                { (1, 1, 730502391, 1), loopData.CloneForIntro() },   // Second segment, second track, second playlist item (Regular)

                { (0, 0, 464817851, 1), dsLoopData.CloneForIntro() }, // First segment, first track, second playlist item (DS)
                { (0, 1, 612785700, 0), dsLoopData.CloneForIntro() }, // First segment, second track, first playlist item (DS)
                { (1, 0, 1051238099, 0), dsLoopData.CloneForLoop() }, // Second segment, first track, first playlist item (DS)
            });

            GenerateNewMusicTrackAndSourceIDs(wd, mts, update, 1050421825, 956548356);

            UpdateAllFinalIDs(mscs, mrscs, mrspis, mss, mts, update);

            return true;
        }
    }
}
