using LumiTool.Data.Wwise;

namespace LumiTool.Engine
{
    public class WwiseEngine
    {
        private LumiToolEngine engine;

        public WwiseEngine(LumiToolEngine engine)
        {
            this.engine = engine;
        }

        public WwiseData LoadBank(string path)
        {
            return new WwiseData(File.ReadAllBytes(path));
        }

        public void SaveBank(WwiseData wd, string path)
        {
            using FileStream fs = File.OpenWrite(path);
            fs.Write(wd.GetBytes());
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
            uint oldEventID = FNV132Hash(oldEventName);
            uint newEventID = FNV132Hash(newEventName);
            uint groupID = FNV132Hash(groupName);

            Event e = ((Event)wd.objectsByID[oldEventID]).Clone();
            AddHirc(wd, e, newEventID);

            List<uint> oldActionIDs = new List<uint>();
            List<uint> newActionIDs = new List<uint>();

            for (int i=0; i<e.actionIDs.Count; i++)
            {
                oldActionIDs.Add(e.actionIDs[i]);
                newActionIDs.Add(oldActionIDs[i] + 1);
                e.actionIDs[e.actionIDs.IndexOf(oldActionIDs[i])] = newActionIDs[i];

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
                    throw new NotImplementedException();
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

                    while (leaf.nodes.Count > 0)
                        leaf = leaf.nodes.First();

                    newMusicRanSeqCntrID = leaf.audioNodeId + 1;
                    if (!update.ContainsKey(leaf.audioNodeId))
                    {
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
                    uint newID = mrspis[i].playlistItemID + 1;
                    update.Add(mrspis[i].playlistItemID, newID);
                    mrspis[i].playlistItemID = newID;
                    wd.objectsByID.Add(newID, mrspis[i]);
                }
                mrspis.AddRange(mrspis[i].playList);
            }

            List<MusicSegment> mss = mrscs.SelectMany(mrsc => mrsc.musicTransNodeParams.musicNodeParams.children.childIDs)
                .Distinct()
                .Select(i => ((MusicSegment)wd.objectsByID[i]).Clone())
                .ToList();

            // Loop work
            if (loopEdit)
            {
                mss[2].duration = loopStart - initDelay;
                mss[2].arrayMarkers[1].position = loopStart - initDelay;

                mss[3].duration = loopEnd - loopStart;
                mss[3].arrayMarkers[1].position = loopEnd - loopStart;
            }

            foreach (MusicSegment ms in mss)
            {
                uint newID = ms.id + 1;
                update.Add(ms.id, newID);
                AddHirc(wd, ms, newID);
            }

            List<MusicTrack> mts = mss.SelectMany(ms => ms.musicNodeParams.children.childIDs)
                .Distinct()
                .Select(i => ((MusicTrack)wd.objectsByID[i]).Clone())
                .ToList();

            List<(uint oldID, uint newID)> audioSources = new();

            // Loop work
            if (loopEdit)
            {
                switch (mts.Count)
                {
                    case 4:
                        mts[2].playlist[0].playAt = -(initDelay);
                        mts[2].playlist[0].beginTrimOffset = initDelay;
                        mts[2].playlist[0].endTrimOffset = -(totalDuration - loopStart);
                        mts[2].playlist[0].srcDuration = totalDuration;

                        mts[3].playlist[0].playAt = -(loopStart);
                        mts[3].playlist[0].beginTrimOffset = loopStart;
                        mts[3].playlist[0].endTrimOffset = -0;
                        mts[3].playlist[0].srcDuration = totalDuration;
                        break;

                    case 6:
                        mts[4].playlist[0].playAt = -(initDelay);
                        mts[4].playlist[0].beginTrimOffset = initDelay;
                        mts[4].playlist[0].endTrimOffset = -(totalDuration - loopStart);
                        mts[4].playlist[0].srcDuration = totalDuration;

                        mts[5].playlist[0].playAt = -(loopStart);
                        mts[5].playlist[0].beginTrimOffset = loopStart;
                        mts[5].playlist[0].endTrimOffset = -0;
                        mts[5].playlist[0].srcDuration = totalDuration;
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }

            foreach (MusicTrack mt in mts)
            {
                uint newID = mt.id + 1;
                update.Add(mt.id, newID);
                AddHirc(wd, mt, newID);

                uint oldSourceID = mt.source.First().mediaInformation.sourceID;
                if (!update.ContainsKey(oldSourceID))
                {
                    uint newSourceID = oldSourceID + 1;
                    audioSources.Add((oldSourceID, newSourceID));
                    update.Add(oldSourceID, newSourceID);
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
        }

        private void AddHirc(WwiseData wd, HircItem hi, uint id)
        {
            hi.id = id;
            ((HircChunk)wd.banks[0].chunks.First(c => c is HircChunk)).loadedItem.Add(hi);
            wd.objectsByID.Add(id, hi);
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
