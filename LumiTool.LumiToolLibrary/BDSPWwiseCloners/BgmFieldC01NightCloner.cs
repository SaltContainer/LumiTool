using LumiTool.Data;
using LumiTool.Data.Wwise;
using LumiTool.Engine;
using LumiTool.Utils;

namespace LumiTool.BDSPWwiseCloners
{
    public class BgmFieldC01NightCloner : BaseCloner
    {
        public BgmFieldC01NightCloner(LumiToolEngine engine) : base(engine) { }

        public override void ExecuteClone(WwiseData wd, string newEventName, WwiseLoopPointData loopData, WwiseLoopPointData dsLoopData)
        {
            uint oldEventID = engine.FNV132Hash("C01_NIGHT"); // Also the ID of the old State in the State Group
            uint newEventID = engine.FNV132Hash(newEventName); // Also the ID of the new State in the State Group
            uint groupID = engine.FNV132Hash("BGM_FIELD");

            engine.Log($"Creating new event {newEventID} ({newEventName}) which affects group {groupID} (BGM_FIELD)", LogLevel.Information);

            Dictionary<uint, uint> update = new();

            // Clone initial Event and add it with the new ID
            Event e = ((Event)wd.objectsByID[oldEventID]).Clone();
            AddHirc(wd, e, newEventID);
            update.Add(oldEventID, newEventID);

            List<uint> oldActionIDs = new List<uint>();
            List<uint> newActionIDs = new List<uint>();

            // Should just be one ActionSetState
            for (int i = 0; i < e.actionIDs.Count; i++)
            {
                // Keep track of old IDs and their equivalent new IDs
                oldActionIDs.Add(e.actionIDs[i]);
                newActionIDs.Add(GenerateNewID(wd));

                // Change the ID on the cloned Event
                e.actionIDs[i] = newActionIDs[i];

                engine.Log($"Action {oldActionIDs[i]} cloned to {newActionIDs[i]}", LogLevel.Information);

                if (wd.objectsByID[oldActionIDs[i]] is ActionSetState oldAss)
                {
                    // Clone Action of Event
                    var newAss = oldAss.Clone();
                    AddHirc(wd, newAss, newActionIDs[i]);

                    // Adjust necessary values
                    newAss.targetStateID = newEventID;
                    newAss.idExt = newEventID;

                    update.Add(oldActionIDs[i], newActionIDs[i]);
                }
                else
                {
                    engine.Log($"Action of Type {wd.objectsByID[oldActionIDs[i]].GetType()} is not supported at this time.", LogLevel.Information);
                }
            }

            HircChunk hc = (HircChunk)wd.banks[0].chunks.First(c => c is HircChunk);

            // Find all MusicSwitchCntr that check this State Group
            List<MusicSwitchCntr> mscs = hc.loadedItem.Where(hi => hi is MusicSwitchCntr msc && msc.arguments
                .Any(gs => gs.group == groupID))
                .Cast<MusicSwitchCntr>()
                .ToList();

            List<uint> oldMusicRanSeqCntrIDs = new();
            foreach (MusicSwitchCntr msc in mscs)
            {
                if (msc.id == 805188190)
                    engine.Log($"Editing MusicSwitchCntr {msc.id} [Regular]", LogLevel.Information);
                else if (msc.id == 319787682)
                    engine.Log($"Editing MusicSwitchCntr {msc.id} [DS]", LogLevel.Information);
                else
                    engine.Log($"Editing MusicSwitchCntr {msc.id} [Unknown]", LogLevel.Information);

                // Get all nodes at the proper level for the State Group
                List<(Node parent, int childIdx)> targetNodes = GetTargetNodes(msc, groupID);
                List<uint> newMusicRanSeqCntrIDs = new();
                foreach ((Node parent, int childIdx) in targetNodes)
                {
                    Node n = parent.nodes[childIdx];

                    // Find the node we want to clone
                    if (n.key != oldEventID)
                        continue;

                    // Add the cloned node to the parent of the original node and update its ID
                    Node newNode = n.Clone();
                    parent.nodes.Add(newNode);
                    newNode.key = newEventID;
                    Node leaf = newNode;

                    // Grabbing the bottom node of this cloned node
                    while (leaf.nodes.Count > 0)
                        leaf = leaf.nodes.First();

                    // If we don't already have this MusicRanSeqCntr ID marked as found, mark it
                    if (!update.ContainsKey(leaf.audioNodeId))
                    {
                        var newMusicRanSeqCntrID = GenerateNewID(wd);

                        if (leaf.audioNodeId == 1066351178)
                            engine.Log($"Node with audioId {leaf.audioNodeId} cloned to {newMusicRanSeqCntrID} [Regular]", LogLevel.Information);
                        else if (leaf.audioNodeId == 380621555)
                            engine.Log($"Node with audioId {leaf.audioNodeId} cloned to {newMusicRanSeqCntrID} [DS]", LogLevel.Information);
                        else
                            engine.Log($"Node with audioId {leaf.audioNodeId} cloned to {newMusicRanSeqCntrID} [Unknown]", LogLevel.Information);

                        newMusicRanSeqCntrIDs.Add(newMusicRanSeqCntrID);
                        oldMusicRanSeqCntrIDs.Add(leaf.audioNodeId);
                        update.Add(leaf.audioNodeId, newMusicRanSeqCntrID);
                    }

                    // If the node params for this MusicSwitchCntr contain the old MusicRanSeqCntr ID but not the new one, add the new one
                    if (msc.musicTransNodeParams.musicNodeParams.children.childIDs.Contains(leaf.audioNodeId) &&
                        !msc.musicTransNodeParams.musicNodeParams.children.childIDs.Contains(update[leaf.audioNodeId]))
                    {
                        msc.musicTransNodeParams.musicNodeParams.children.childIDs.Add(update[leaf.audioNodeId]);
                    }

                    // Update the MusicRanSeqCntr ID on the cloned last node
                    leaf.audioNodeId = update[leaf.audioNodeId];
                }
            }

            // Clone the old MusicRanSeqCntrs
            List<MusicRanSeqCntr> mrscs = oldMusicRanSeqCntrIDs.Select(i => ((MusicRanSeqCntr)wd.objectsByID[i]).Clone()).ToList();

            // List all the PlaylistItems recursively
            List<MusicRanSeqPlaylistItem> mrspis = mrscs.SelectMany(mrsc => mrsc.playList).FlattenRecursive(pi => pi.playList).ToList();
            foreach (MusicRanSeqCntr mrsc in mrscs)
            {
                AddHirc(wd, mrsc, update[mrsc.id]);
                GenerateNewPlaylistItemIDs(wd, mrsc.playList, update);
            }

            // MusicRanSeqCntr contains MusicSegments, which we also clone
            var splitSegments = mrscs.Select(mrsc => mrsc.musicTransNodeParams.musicNodeParams.children.childIDs
                    .Select(i => ((MusicSegment)wd.objectsByID[i]).Clone())
                    .ToList())
                .ToList();

            // Collect the MusicSegments into one big list
            List<MusicSegment> mss = splitSegments.SelectMany(x => x).ToList();

            // Do some edits on the loop data for MusicSegments
            foreach (var segments in splitSegments)
            {
                // Segment for Regular
                if (segments[0].id == 615383685 && loopData != null)
                {
                    segments[0].duration = loopData.LoopStart - loopData.InitialDelay;
                    segments[0].arrayMarkers[1].position = loopData.LoopStart - loopData.InitialDelay;
                }
                // Segment for DS
                else if (segments[0].id == 738419479 && dsLoopData != null)
                {
                    segments[0].duration = dsLoopData.LoopStart - dsLoopData.InitialDelay;
                    segments[0].arrayMarkers[1].position = dsLoopData.LoopStart - dsLoopData.InitialDelay;
                }
            }

            // Generate new IDs for the MusicSegments
            foreach (MusicSegment ms in mss)
            {
                uint newID = GenerateNewID(wd);
                update.Add(ms.id, newID);
                AddHirc(wd, ms, newID);
            }

            // MusicSegments contain MusicTracks, which we also clone
            var splitTracks = splitSegments.Select(mrsc => mrsc.Select(ms => ms.musicNodeParams.children.childIDs
                        .Select(i => ((MusicTrack)wd.objectsByID[i]).Clone())
                        .ToList())
                    .ToList())
                .ToList();

            // Collect the MusicTracks into one big list
            List<MusicTrack> mts = splitTracks.SelectMany(x => x).SelectMany(x => x).ToList();

            // Do some edits on the loop data for MusicTracks
            foreach (var tracks in splitTracks)
            {
                // INTRO SECTION
                // First segment, first track, second playlist item (Regular)
                if (tracks[0][0].id == 921805984 && loopData != null)
                {
                    tracks[0][0].playlist[1].playAt = -loopData.InitialDelay;
                    tracks[0][0].playlist[1].beginTrimOffset = loopData.InitialDelay;
                    tracks[0][0].playlist[1].endTrimOffset = loopData.LoopStart;
                    tracks[0][0].playlist[1].srcDuration = loopData.TotalSourceLength;
                }
                // First segment, first track, second playlist item (DS)
                else if (tracks[0][0].id == 251474847 && dsLoopData != null)
                {
                    tracks[0][0].playlist[1].playAt = -dsLoopData.InitialDelay;
                    tracks[0][0].playlist[1].beginTrimOffset = dsLoopData.InitialDelay;
                    tracks[0][0].playlist[1].endTrimOffset = dsLoopData.LoopStart;
                    tracks[0][0].playlist[1].srcDuration = dsLoopData.TotalSourceLength;
                }

                // LOOP SECTION
                // First segment, second track, first playlist item (Regular)
                if (tracks[0][1].id == 978661004 && loopData != null)
                {
                    tracks[0][1].playlist[0].playAt = loopData.InitialDelay - loopData.LoopStart;
                    tracks[0][1].playlist[0].beginTrimOffset = loopData.LoopStart;
                    tracks[0][1].playlist[0].endTrimOffset = loopData.LoopEnd;
                    tracks[0][1].playlist[0].srcDuration = loopData.TotalSourceLength;
                }
                // First segment, second track, first playlist item (DS)
                else if (tracks[0][1].id == 433531414 && dsLoopData != null)
                {
                    tracks[0][1].playlist[0].playAt = dsLoopData.InitialDelay - dsLoopData.LoopStart;
                    tracks[0][1].playlist[0].beginTrimOffset = dsLoopData.LoopStart;
                    tracks[0][1].playlist[0].endTrimOffset = dsLoopData.LoopEnd;
                    tracks[0][1].playlist[0].srcDuration = dsLoopData.TotalSourceLength;
                }
            }

            foreach (MusicTrack mt in mts)
            {
                // Generate new IDs for the MusicTracks
                uint newID = GenerateNewID(wd);
                update.Add(mt.id, newID);
                AddHirc(wd, mt, newID);

                // Only generate a new ID for a source if it hasn't already had one
                uint oldSourceID = mt.source.First().mediaInformation.sourceID;
                if (!update.ContainsKey(oldSourceID))
                {
                    uint newSourceID = GenerateNewID(wd);
                    update.Add(oldSourceID, newSourceID);

                    if (oldSourceID == 1061429089)
                        engine.Log($"Source {oldSourceID} cloned to {newSourceID} [Regular]", LogLevel.Information);
                    else if (oldSourceID == 629390443)
                        engine.Log($"Source {oldSourceID} cloned to {newSourceID} [DS]", LogLevel.Information);
                    else
                        engine.Log($"Source {oldSourceID} cloned to {newSourceID} [Unknown]", LogLevel.Information);
                }
            }

            // Update all the IDs that weren't adjusted
            foreach (MusicSwitchCntr msc in mscs)
            {
                foreach (MusicTransitionRule mtr in msc.musicTransNodeParams.rules)
                {
                    AddNewIDs(mtr.srcIDs, update);
                    AddNewIDs(mtr.dstIDs, update);
                }
            }

            foreach (MusicRanSeqCntr mrsc in mrscs)
            {
                UpdateIDs(mrsc.musicTransNodeParams.musicNodeParams.children.childIDs, update);
                foreach (MusicTransitionRule mtr in mrsc.musicTransNodeParams.rules)
                {
                    UpdateIDs(mtr.srcIDs, update);
                    UpdateIDs(mtr.dstIDs, update);
                }
            }

            foreach (MusicRanSeqPlaylistItem mrspi in mrspis)
                mrspi.segmentID = GetNewID(mrspi.segmentID, update);

            foreach (MusicSegment ms in mss)
            {
                ms.musicNodeParams.nodeBaseParams.directParentID = GetNewID(ms.musicNodeParams.nodeBaseParams.directParentID, update);
                UpdateIDs(ms.musicNodeParams.children.childIDs, update);
            }

            foreach (MusicTrack mt in mts)
            {
                foreach (BankSourceData bsd in mt.source)
                    bsd.mediaInformation.sourceID = GetNewID(bsd.mediaInformation.sourceID, update);

                foreach (TrackSrcInfo tsi in mt.playlist)
                    tsi.sourceID = GetNewID(tsi.sourceID, update);

                mt.nodeBaseParams.directParentID = GetNewID(mt.nodeBaseParams.directParentID, update);
            }
        }
    }
}
