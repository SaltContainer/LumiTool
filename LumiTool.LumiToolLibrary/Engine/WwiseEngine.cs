using LumiTool.Data;
using LumiTool.Data.Wwise;

namespace LumiTool.Engine
{
    public class WwiseEngine
    {
        private LumiToolEngine engine;
        private BDSPWwiseEngine bdspWwiseEngine;

        public WwiseEngine(LumiToolEngine engine)
        {
            this.engine = engine;
            this.bdspWwiseEngine = new BDSPWwiseEngine(engine);
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

        public void MakeNewBDSPWwiseEvent(WwiseData wd, BDSPWwiseEventType eventType, string newEventName, WwiseLoopPointData loopData, WwiseLoopPointData dsLoopData)
        {
            bdspWwiseEngine.MakeNewBDSPWwiseEvent(wd, eventType, newEventName, loopData, dsLoopData);
        }

        public List<Event> GetEventsOfBank(WwiseData wd)
        {
            HircChunk hc = (HircChunk)wd.banks[0].chunks.First(c => c is HircChunk);
            return hc.loadedItem.Where(hi => hi is Event).Cast<Event>().ToList();
        }

        public List<Data.Wwise.Action> GetActionsOfEvent(WwiseData wd, Event ev)
        {
            HircChunk hc = (HircChunk)wd.banks[0].chunks.First(c => c is HircChunk);
            return hc.loadedItem.Where(hi => hi is Data.Wwise.Action && ev.actionIDs.Contains(hi.id)).Cast<Data.Wwise.Action>().ToList();
        }

        public void AddActionToEvent(WwiseData wd, Event ev, Data.Wwise.Action action)
        {
            uint newID = GenerateNewID(wd);
            AddHirc(wd, action, newID);
            ev.actionIDs.Add(newID);
        }

        public void RemoveActionOfEvent(WwiseData wd, Event ev, Data.Wwise.Action action)
        {
            ev.actionIDs.Remove(action.id);
        }

        public List<MusicSwitchCntr> GetMusicSwitchCntrsOfBank(WwiseData wd)
        {
            HircChunk hc = (HircChunk)wd.banks[0].chunks.First(c => c is HircChunk);
            return hc.loadedItem.Where(hi => hi is MusicSwitchCntr).Cast<MusicSwitchCntr>().ToList();
        }

        private void AddHirc(WwiseData wd, HircItem hi, uint id)
        {
            //engine.Log($"Adding new HircItem {id} based off of HircItem {hi.id}", LogLevel.Information);

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

            //engine.Log($"Generated new ID {id}", LogLevel.Information);

            return id;
        }
    }
}
