using LumiTool.Data.Wwise;
using LumiTool.Data;

namespace LumiTool.Engine.BDSPWwiseCloners
{
    public abstract class BaseCloner
    {
        protected LumiToolEngine engine;

        public BaseCloner(LumiToolEngine engine)
        {
            this.engine = engine;
        }

        public abstract void ExecuteClone(WwiseData wd, string newEventName, WwiseLoopPointData loopData, WwiseLoopPointData dsLoopData);

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
