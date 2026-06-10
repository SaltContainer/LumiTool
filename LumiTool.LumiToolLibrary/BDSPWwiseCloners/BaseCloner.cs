using LumiTool.Data.Wwise;
using LumiTool.Data;
using LumiTool.Engine;

namespace LumiTool.BDSPWwiseCloners
{
    public abstract class BaseCloner
    {
        protected LumiToolEngine engine;

        public BaseCloner(LumiToolEngine engine)
        {
            this.engine = engine;
        }

        public abstract bool ExecuteClone(WwiseData wd, string newEventName, WwiseLoopPointData loopData, WwiseLoopPointData dsLoopData);

        protected Dictionary<uint, uint> CloneEventAndActions(WwiseData wd, uint oldEventID, uint newEventID, uint groupID, Dictionary<uint, uint> update)
        {
            // Clone initial Event and add it with the new ID
            Event e = ((Event)wd.objectsByID[oldEventID]).Clone();
            AddHirc(wd, e, newEventID);
            update.Add(oldEventID, newEventID);

            List<uint> oldActionIDs = new List<uint>();
            List<uint> newActionIDs = new List<uint>();

            // Should just be one ActionSetState
            for (int i=0; i<e.actionIDs.Count; i++)
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

                    // Adjust necessary values if it's the specified group
                    if (newAss.stateGroupID == groupID)
                    {
                        newAss.targetStateID = newEventID;
                        newAss.idExt = newEventID;
                    }

                    update.Add(oldActionIDs[i], newActionIDs[i]);
                }
                else if (wd.objectsByID[oldActionIDs[i]] is ActionPlay oldAp)
                {
                    // Clone Action of Event
                    var newAp = oldAp.Clone();
                    AddHirc(wd, newAp, newActionIDs[i]);
                    update.Add(oldActionIDs[i], newActionIDs[i]);
                }
                else if (wd.objectsByID[oldActionIDs[i]] is ActionPause oldAps)
                {
                    // Clone Action of Event
                    var newAps = oldAps.Clone();
                    AddHirc(wd, newAps, newActionIDs[i]);
                    update.Add(oldActionIDs[i], newActionIDs[i]);
                }
                else if (wd.objectsByID[oldActionIDs[i]] is ActionSetAkProp oldAsap)
                {
                    // Clone Action of Event
                    var newAsap = oldAsap.Clone();
                    AddHirc(wd, newAsap, newActionIDs[i]);
                    update.Add(oldActionIDs[i], newActionIDs[i]);
                }
                else
                {
                    engine.Log($"Action of Type {wd.objectsByID[oldActionIDs[i]].GetType()} is not supported at this time.", LogLevel.Information);
                }
            }

            return oldActionIDs.Zip(newActionIDs).ToDictionary(kvp => kvp.First, kvp => kvp.Second);
        }

        protected List<uint> UpdateMusicRanSeqCntrs(WwiseData wd, List<MusicSwitchCntr> mscs, uint oldEventID, uint newEventID, uint groupID, Dictionary<uint, uint> update, uint regularMusicSwitchCntrID, uint dsMusicSwitchCntrID, uint oldRegularMusicRanSeqCntrID, uint oldDSMusicRanSeqCntrID)
        {
            List<uint> oldMusicRanSeqCntrIDs = new();

            foreach (MusicSwitchCntr msc in mscs)
            {
                if (msc.id == regularMusicSwitchCntrID)
                    engine.Log($"Editing MusicSwitchCntr {msc.id} [Regular]", LogLevel.Information);
                else if (msc.id == dsMusicSwitchCntrID)
                    engine.Log($"Editing MusicSwitchCntr {msc.id} [DS]", LogLevel.Information);
                else
                    engine.Log($"Editing MusicSwitchCntr {msc.id} [Unknown]", LogLevel.Information);

                // Get all nodes at the proper level for the State Group
                List<(Node parent, int childIdx)> targetNodes = GetTargetNodes(msc, groupID);

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

                        if (leaf.audioNodeId == oldRegularMusicRanSeqCntrID)
                            engine.Log($"Node with audioId {leaf.audioNodeId} cloned to {newMusicRanSeqCntrID} [Regular]", LogLevel.Information);
                        else if (leaf.audioNodeId == oldDSMusicRanSeqCntrID)
                            engine.Log($"Node with audioId {leaf.audioNodeId} cloned to {newMusicRanSeqCntrID} [DS]", LogLevel.Information);
                        else
                            engine.Log($"Node with audioId {leaf.audioNodeId} cloned to {newMusicRanSeqCntrID} [Unknown]", LogLevel.Information);

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

            return oldMusicRanSeqCntrIDs;
        }

        protected void SetupPlaylistItems(WwiseData wd, List<MusicRanSeqCntr> mrscs, Dictionary<uint, uint> update)
        {
            foreach (MusicRanSeqCntr mrsc in mrscs)
            {
                AddHirc(wd, mrsc, update[mrsc.id]);
                GenerateNewPlaylistItemIDs(wd, mrsc.playList, update);
            }
        }

        protected void AdjustLoopPointsInMusicSegments(List<List<MusicSegment>> splitSegments, Dictionary<(int segmentIndex, uint segmentID), WwiseLoopPointData> loopData)
        {
            // Do some edits on the loop data for MusicSegments
            foreach (var segments in splitSegments)
            {
                foreach (var ((i, id), l) in loopData)
                {
                    if (l != null && segments.Count > i && segments[i].id == id)
                    {
                        segments[i].duration = l.SegmentDuration;
                        segments[i].arrayMarkers[1].position = l.SegmentArrayMarkerPosition;
                    }
                }
            }
        }

        protected void GenerateNewMusicSegmentIDs(WwiseData wd, List<MusicSegment> mss, Dictionary<uint, uint> update)
        {
            // Generate new IDs for the MusicSegments
            foreach (MusicSegment ms in mss)
            {
                uint newID = GenerateNewID(wd);
                update.Add(ms.id, newID);
                AddHirc(wd, ms, newID);
            }
        }

        protected void AdjustLoopPointsInMusicTracks(List<List<List<MusicTrack>>> splitTracks, Dictionary<(int segmentIndex, int trackIndex, uint trackID, int playlistItemIndex), WwiseLoopPointData> loopData)
        {
            // Do some edits on the loop data for MusicTracks
            foreach (var tracks in splitTracks)
            {
                foreach (var ((i, j, id, k), l) in loopData)
                {
                    if (l != null && tracks.Count > i && tracks[i].Count > j && tracks[i][j].id == id && tracks[i][j].playlist.Count > k)
                    {
                        tracks[i][j].playlist[k].playAt = l.PlayAt;
                        tracks[i][j].playlist[k].beginTrimOffset = l.BeginTrimOffset;
                        tracks[i][j].playlist[k].endTrimOffset = l.EndTrimOffset;
                        tracks[i][j].playlist[k].srcDuration = l.SrcDuration;
                    }
                }
            }
        }

        protected void GenerateNewMusicTrackAndSourceIDs(WwiseData wd, List<MusicTrack> mts, Dictionary<uint, uint> update, uint oldRegularSourceID, uint oldDSSourceID)
        {
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

                    if (oldSourceID == oldRegularSourceID)
                        engine.Log($"Source {oldSourceID} cloned to {newSourceID} [Regular]", LogLevel.Information);
                    else if (oldSourceID == oldDSSourceID)
                        engine.Log($"Source {oldSourceID} cloned to {newSourceID} [DS]", LogLevel.Information);
                    else
                        engine.Log($"Source {oldSourceID} cloned to {newSourceID} [Unknown]", LogLevel.Information);
                }
            }
        }

        protected void UpdateAllFinalIDs(List<MusicSwitchCntr> mscs, List<MusicRanSeqCntr> mrscs, List<MusicRanSeqPlaylistItem> mrspis, List<MusicSegment> mss, List<MusicTrack> mts, Dictionary<uint, uint> update)
        {
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

        protected void AddEventNameAndHashToDict(Dictionary<string, uint> dict, string eventName)
        {
            dict.Add(eventName, engine.FNV132Hash(eventName));
        }

        protected void GenerateNewSoundAndSourceIDs(WwiseData wd, List<Sound> sounds, Dictionary<uint, uint> update)
        {
            foreach (Sound sound in sounds)
            {
                // Generate new IDs for the Sounds
                uint newID = GenerateNewID(wd);
                update.Add(sound.id, newID);
                sound.id = newID;
                AddHirc(wd, sound, newID);

                // Only generate a new ID for a source if it hasn't already had one
                uint oldSourceID = sound.bankSourceData.mediaInformation.sourceID;
                if (!update.ContainsKey(oldSourceID))
                {
                    uint newSourceID = GenerateNewID(wd);
                    update.Add(oldSourceID, newSourceID);
                    engine.Log($"Source {oldSourceID} cloned to {newSourceID}", LogLevel.Information);
                }
            }
        }

        protected void CloneActorMixer(WwiseData wd, List<Sound> sounds, uint oldActorMixerID, uint parentActorMixerID, Dictionary<uint, uint> update)
        {
            // Clone the original ActorMixer
            uint newActorMixerID = GenerateNewID(wd);
            var mixer = ((ActorMixer)wd.objectsByID[oldActorMixerID]).Clone();
            update.Add(mixer.id, newActorMixerID);
            mixer.id = newActorMixerID;
            mixer.children.childIDs = sounds.Select(s => s.id).ToList();
            mixer.nodeBaseParams.directParentID = parentActorMixerID;
            AddHirc(wd, mixer, newActorMixerID);

            // Add ActorMixer to parent
            var parent = (ActorMixer)wd.objectsByID[parentActorMixerID];
            parent.children.childIDs.Add(mixer.id);

            engine.Log($"ActorMixer {oldActorMixerID} cloned to {newActorMixerID}, with parent {parentActorMixerID}", LogLevel.Information);
        }

        protected void AddHirc(WwiseData wd, HircItem hi, uint id)
        {
            //engine.Log($"Adding new HircItem {id} based off of HircItem {hi.id}", LogLevel.Information);

            hi.id = id;
            ((HircChunk)wd.banks[0].chunks.First(c => c is HircChunk)).loadedItem.Add(hi);
            wd.objectsByID.Add(id, hi);
        }

        protected uint GenerateNewID(WwiseData wd)
        {
            uint id;
            do
                id = (uint)Random.Shared.NextInt64(uint.MaxValue + 1L);
            while (wd.objectsByID.ContainsKey(id));

            //engine.Log($"Generated new ID {id}", LogLevel.Information);

            return id;
        }

        protected List<(Node, int)> GetTargetNodes(MusicSwitchCntr msc, uint groupID)
        {
            List<(Node parent, int childIdx)> targetNodes = msc.decisionTree.nodes.Select((n, i) => (msc.decisionTree, i)).ToList();
            int targetDepth = msc.arguments.Select(gs => gs.group).ToList().IndexOf(groupID);

            for (int i = 0; i < targetDepth; i++)
            {
                targetNodes = targetNodes.SelectMany(t => t.parent.nodes[t.childIdx].nodes.Select((n, j) =>
                  (t.parent.nodes[t.childIdx], j))).ToList();
            }

            return targetNodes;
        }

        protected uint GetNewID(uint id, Dictionary<uint, uint> update)
        {
            if (update.ContainsKey(id))
                return update[id];

            return id;
        }

        protected void UpdateIDs(List<uint> idList, Dictionary<uint, uint> update)
        {
            for (int i = 0; i < idList.Count; i++)
                idList[i] = GetNewID(idList[i], update);
        }

        protected void AddNewIDs(List<uint> idList, Dictionary<uint, uint> update)
        {
            for (int i = 0; i < idList.Count; i++)
            {
                if (update.ContainsKey(idList[i]))
                    idList.Add(update[idList[i]]);
            }
        }

        protected void GenerateNewPlaylistItemIDs(WwiseData wd, List<MusicRanSeqPlaylistItem> playlistItems, Dictionary<uint, uint> update)
        {
            foreach (var playlistItem in playlistItems)
            {
                uint newID = GenerateNewID(wd);
                engine.Log($"Playlist Item {playlistItem.playlistItemID} cloned to {newID}", LogLevel.Information);
                update.Add(playlistItem.playlistItemID, newID);
                playlistItem.playlistItemID = newID;

                // Call recursively
                GenerateNewPlaylistItemIDs(wd, playlistItem.playList, update);
            }
        }
    }
}
