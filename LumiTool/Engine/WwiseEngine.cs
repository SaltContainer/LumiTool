using LumiTool.Data.Wwise;

namespace LumiTool.Engine
{
    public class WwiseEngine
    {
        private LumiToolEngine engine;
        private List<string> logs;

        public WwiseEngine(LumiToolEngine engine)
        {
            this.engine = engine;
            logs = new List<string>();
        }

        public WwiseData LoadBank(string path)
        {
            logs.Clear();
            return new WwiseData(File.ReadAllBytes(path));
        }

        public void SaveBank(WwiseData wd, string path)
        {
            using FileStream fs = File.OpenWrite(path);
            fs.Write(wd.GetBytes());

            var logPath = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + "-log.log");
            using var fsLog = new FileStream(logPath, FileMode.Create);
            using var swLog = new StreamWriter(fs);
            foreach (var log in logs)
                swLog.WriteLine(log);
        }

        public uint FNV132Hash(string data)
        {
            data = data.ToLower();
            uint hash = 0x811c9dc5;
            foreach (char c in data)
            {
                hash *= 0x01000193;
                hash ^= (byte)c;
            }
            return hash;
        }

        public void CloneHircEvent(WwiseData wd, string oldEventName, string newEventName, string groupName, bool loopEdit = false, double initDelay = 0, double loopStart = 0, double loopEnd = 0, double totalDuration = 0)
        {
            var debugLogging = string.Empty;

            uint oldEventID = FNV132Hash(oldEventName);
            uint newEventID = FNV132Hash(newEventName);
            uint groupID = FNV132Hash(groupName);

            debugLogging += $"Cloning {oldEventID} ({oldEventName}) in group {groupID} ({groupName}) to {newEventID} ({newEventName})\n";

            Event e = ((Event)wd.objectsByID[oldEventID]).Clone();
            AddHirc(wd, e, newEventID);

            List<uint> oldActionIDs = new List<uint>();
            List<uint> newActionIDs = new List<uint>();

            for (int i=0; i<e.actionIDs.Count; i++)
            {
                oldActionIDs.Add(e.actionIDs[i]);
                newActionIDs.Add(GenerateNewID(wd));
                e.actionIDs[e.actionIDs.IndexOf(oldActionIDs[i])] = newActionIDs[i];
                debugLogging += $"Action {oldActionIDs[i]} cloned to {newActionIDs[i]}\n";

                if (wd.objectsByID[oldActionIDs[i]] is ActionSetState ass)
                {
                    ass = ((ActionSetState)wd.objectsByID[oldActionIDs[i]]).Clone();
                    AddHirc(wd, ass, newActionIDs[i]);
                    ass.targetStateID = newEventID;
                    ass.idExt = newEventID;
                }
                else if (wd.objectsByID[oldActionIDs[i]] is ActionPause ap)
                {
                    ap = ((ActionPause)wd.objectsByID[oldActionIDs[i]]).Clone();
                    AddHirc(wd, ap, newActionIDs[i]);
                    ap.idExt = newEventID;
                }
                else if (wd.objectsByID[oldActionIDs[i]] is ActionSetAkProp asap)
                {
                    asap = ((ActionSetAkProp)wd.objectsByID[oldActionIDs[i]]).Clone();
                    AddHirc(wd, asap, newActionIDs[i]);
                    asap.idExt = newEventID;
                }
                else
                {
                    throw new NotImplementedException($"Type {wd.objectsByID[oldActionIDs[i]].GetType()} is not supported at this time.");
                }
            }

            HircChunk hc = (HircChunk)wd.banks[0].chunks.First(c => c is HircChunk);
            List<MusicSwitchCntr> mscs = hc.loadedItem.Where(hi => hi is MusicSwitchCntr msc && msc.arguments
                .Any(gs => gs.group == groupID))
                .Cast<MusicSwitchCntr>()
                .ToList();

            List<uint> oldMusicRanSeqCntrIDs = new();
            Dictionary<uint, uint> update = new();
            foreach (MusicSwitchCntr msc in mscs)
            {
                debugLogging += $"Editing MusicSwitchCntr {msc.id}\n";

                List<(Node parent, int childIdx)> targetNodes = GetTargetNodes(msc, groupID);
                uint newMusicRanSeqCntrID = 0;
                foreach ((Node parent, int childIdx) in targetNodes)
                {
                    Node n = parent.nodes[childIdx];
                    if (n.key != oldEventID)
                        continue;

                    Node newNode = n.Clone();
                    parent.nodes.Add(newNode);
                    newNode.key = newEventID;
                    Node leaf = newNode;

                    // Grabbing the first child of the last depth of this new node
                    while (leaf.nodes.Count > 0)
                        leaf = leaf.nodes.First();

                    newMusicRanSeqCntrID = GenerateNewID(wd);
                    if (!update.ContainsKey(leaf.audioNodeId))
                    {
                        debugLogging += $"Node with audioId {leaf.audioNodeId} cloned to {newMusicRanSeqCntrID}\n";
                        oldMusicRanSeqCntrIDs.Add(leaf.audioNodeId);
                        update.Add(leaf.audioNodeId, newMusicRanSeqCntrID);
                    }

                    leaf.audioNodeId = newMusicRanSeqCntrID;
                }

                if (newMusicRanSeqCntrID != 0)
                    msc.musicTransNodeParams.musicNodeParams.children.childIDs.Add(newMusicRanSeqCntrID);
            }

            update.Add(oldEventID, newEventID);

            for (int i=0; i<e.actionIDs.Count; i++)
                update.Add(oldActionIDs[i], newActionIDs[i]);

            List<MusicRanSeqCntr> mrscs = oldMusicRanSeqCntrIDs.Select(i => ((MusicRanSeqCntr)wd.objectsByID[i]).Clone()).ToList();

            List<MusicRanSeqPlaylistItem> mrspis = new();
            foreach (MusicRanSeqCntr mrsc in mrscs)
            {
                AddHirc(wd, mrsc, update[mrsc.id]);
                mrspis.AddRange(mrsc.playList);
            }
            for (int i = 0; i < mrspis.Count; i++)
            {
                if (mrspis[i].playlistItemID != 0)
                {
                    uint newID = GenerateNewID(wd);
                    debugLogging += $"Playlist Item {mrspis[i].playlistItemID} cloned to {newID}\n";
                    update.Add(mrspis[i].playlistItemID, newID);
                    mrspis[i].playlistItemID = newID;
                    wd.objectsByID.Add(newID, mrspis[i]);
                }
                mrspis.AddRange(mrspis[i].playList);
            }

            // Each MusicRanSeqCntr, containing MusicSegments
            var splitSegments = mrscs.Select(mrsc => mrsc.musicTransNodeParams.musicNodeParams.children.childIDs
                    .Select(i => ((MusicSegment)wd.objectsByID[i]).Clone())
                    .ToList())
                .ToList();

            List<MusicSegment> mss = splitSegments.SelectMany(x => x).ToList();

            // Loop work
            if (loopEdit)
            {
                foreach (var segments in splitSegments)
                {
                    segments[0].duration = loopStart - initDelay;
                    segments[0].arrayMarkers[1].position = loopStart - initDelay;

                    segments[1].duration = loopEnd - loopStart;
                    segments[1].arrayMarkers[1].position = loopEnd - loopStart;
                }
            }

            foreach (MusicSegment ms in mss)
            {
                uint newID = GenerateNewID(wd);
                update.Add(ms.id, newID);
                AddHirc(wd, ms, newID);
            }

            // Each MusicRanSeqCntr, containing MusicSegments, which each contain MusicTracks
            var splitTracks = splitSegments.Select(mrsc => mrsc.Select(ms => ms.musicNodeParams.children.childIDs
                        .Select(i => ((MusicTrack)wd.objectsByID[i]).Clone())
                        .ToList())
                    .ToList())
                .ToList();

            List<MusicTrack> mts = splitTracks.SelectMany(x => x).SelectMany(x => x).ToList();

            List<(uint oldID, uint newID)> audioSources = new();

            // Loop work
            if (loopEdit)
            {
                foreach (var segments in splitTracks)
                {
                    // First segment, first track
                    segments[0][0].playlist[0].playAt = -initDelay;
                    segments[0][0].playlist[0].beginTrimOffset = initDelay;
                    segments[0][0].playlist[0].endTrimOffset = loopStart;
                    segments[0][0].playlist[0].srcDuration = totalDuration;

                    // Second segment, first track
                    segments[1][0].playlist[0].playAt = initDelay - loopStart;
                    segments[1][0].playlist[0].beginTrimOffset = loopStart;
                    segments[1][0].playlist[0].endTrimOffset = loopEnd;
                    segments[1][0].playlist[0].srcDuration = totalDuration;
                }
            }

            foreach (MusicTrack mt in mts)
            {
                uint newID = GenerateNewID(wd);
                update.Add(mt.id, newID);
                AddHirc(wd, mt, newID);

                uint oldSourceID = mt.source.First().mediaInformation.sourceID;
                if (!update.ContainsKey(oldSourceID))
                {
                    uint newSourceID = GenerateNewID(wd);
                    audioSources.Add((oldSourceID, newSourceID));
                    update.Add(oldSourceID, newSourceID);

                    debugLogging += $"Source {oldSourceID} cloned to {newSourceID}\n";
                }
            }

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
                {
                    tsi.sourceID = GetNewID(tsi.sourceID, update);
                    tsi.eventID = GetNewID(tsi.eventID, update);
                }

                mt.nodeBaseParams.directParentID = GetNewID(mt.nodeBaseParams.directParentID, update);
            }

            logs.Add(debugLogging);
            MessageBox.Show(debugLogging, "Debug Output", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddHirc(WwiseData wd, HircItem hi, uint id)
        {
            hi.id = id;
            ((HircChunk)wd.banks[0].chunks.First(c => c is HircChunk)).loadedItem.Add(hi);
            wd.objectsByID.Add(id, hi);
        }

        private uint GenerateNewID(WwiseData wd)
        {
            uint id;
            do
                id = (uint)Random.Shared.NextInt64(uint.MaxValue+1L);
            while (wd.objectsByID.ContainsKey(id));

            return id;
        }

        private List<(Node, int)> GetTargetNodes(MusicSwitchCntr msc, uint groupID)
        {
            List<(Node parent, int childIdx)> targetNodes = msc.decisionTree.nodes.Select((n, i) => (msc.decisionTree, i)).ToList();
            int targetDepth = msc.arguments.Select(gs => gs.group).ToList().IndexOf(groupID);

            for (int i=0; i<targetDepth; i++)
            {
                targetNodes = targetNodes.SelectMany(t => t.parent.nodes[t.childIdx].nodes.Select((n, j) =>
                  (t.parent.nodes[t.childIdx], j))).ToList();
            }

            return targetNodes;
        }

        private uint GetNewID(uint id, Dictionary<uint, uint> update)
        {
            if (update.ContainsKey(id))
                return update[id];

            return id;
        }

        private void UpdateIDs(List<uint> idList, Dictionary<uint, uint> update)
        {
            for (int i=0; i<idList.Count; i++)
                idList[i] = GetNewID(idList[i], update);
        }

        private void AddNewIDs(List<uint> idList, Dictionary<uint, uint> update)
        {
            for (int i=0; i<idList.Count; i++)
            {
                if (update.ContainsKey(idList[i]))
                    idList.Add(update[idList[i]]);
            }
        }
    }
}
