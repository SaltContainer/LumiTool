using LumiTool.BDSPWwiseCloners;
using LumiTool.Data.Wwise;
using LumiTool.Data;
using LumiTool.Engine;
using LumiTool.Utils;

namespace LumiTool.BDSPWwiseCloners
{
    public abstract class BgmEventBaseCloner : BaseCloner
    {
        public BgmEventBaseCloner(LumiToolEngine engine) : base(engine) { }

        protected bool ExecuteBgmEventClone(WwiseData wd, string oldEventName, string newEventName, List<(int segmentIndex, uint segmentID, bool isDS, bool isLoop)> segmentLoopData, List<(int segmentIndex, int trackIndex, uint trackID, int playlistItemIndex, bool isDS, bool isLoop)> trackLoopData,  WwiseLoopPointData loopData, WwiseLoopPointData dsLoopData, uint oldRegularMusicRanSeqCntrID, uint oldDSMusicRanSeqCntrID, uint oldRegularSourceID, uint oldDSSourceID)
        {
            uint oldEventID = engine.FNV132Hash(oldEventName); // Also the ID of the old State in the State Group
            uint newEventID = engine.FNV132Hash(newEventName); // Also the ID of the new State in the State Group
            uint groupID = engine.FNV132Hash("BGM_EVENT");

            engine.Log($"Creating new event {newEventID} ({newEventName}) which affects group {groupID} (BGM_EVENT)", LogLevel.Information);

            Dictionary<uint, uint> update = new();

            CloneEventAndActions(wd, oldEventID, newEventID, groupID, update);

            HircChunk hc = (HircChunk)wd.banks[0].chunks.First(c => c is HircChunk);

            // Find all MusicSwitchCntr that check this State Group
            List<MusicSwitchCntr> mscs = hc.loadedItem.Where(hi => hi is MusicSwitchCntr msc && msc.arguments
                .Any(gs => gs.group == groupID))
                .Cast<MusicSwitchCntr>()
                .ToList();

            List<uint> oldMusicRanSeqCntrIDs = UpdateMusicRanSeqCntrs(wd, mscs, oldEventID, newEventID, groupID, update, 717132912, 175587878, oldRegularMusicRanSeqCntrID, oldDSMusicRanSeqCntrID);

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

            AdjustLoopPointsInMusicSegments(splitSegments, segmentLoopData.ToDictionary(s => (s.segmentIndex, s.segmentID),
                s => s.isDS ?
                    (s.isLoop ? dsLoopData.CloneForLoop() : dsLoopData.CloneForIntro()) :
                    (s.isLoop ? loopData.CloneForLoop() : loopData.CloneForIntro())
                ));

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

            AdjustLoopPointsInMusicTracks(splitTracks, trackLoopData.ToDictionary(t => (t.segmentIndex, t.trackIndex, t.trackID, t.playlistItemIndex),
                t => t.isDS ?
                    (t.isLoop ? dsLoopData.CloneForLoop() : dsLoopData.CloneForIntro()) :
                    (t.isLoop ? loopData.CloneForLoop() : loopData.CloneForIntro())
                ));

            GenerateNewMusicTrackAndSourceIDs(wd, mts, update, oldRegularSourceID, oldDSSourceID);

            UpdateAllFinalIDs(mscs, mrscs, mrspis, mss, mts, update);

            return true;
        }
    }
}
