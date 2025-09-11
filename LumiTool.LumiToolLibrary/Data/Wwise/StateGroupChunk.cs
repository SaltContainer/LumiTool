namespace LumiTool.Data.Wwise
{
    public class StateGroupChunk : ISerializable
    {
        public uint stateGroupID;
        public byte stateSyncType;
        public ulong statesCount;
        public List<AkState> states;

        public StateGroupChunk Clone()
        {
            StateGroupChunk sgc = (StateGroupChunk)this.MemberwiseClone();
            sgc.states = new();
            foreach (AkState akState in states)
                sgc.states.Add(akState.Clone());
            return sgc;
        }

        public void Deserialize(WwiseData wd)
        {
            states = new();
            stateGroupID = Utils.ReadUInt32(wd);
            stateSyncType = Utils.ReadUInt8(wd);
            statesCount = Utils.ReadVariableInt(wd);
            for (ulong i = 0; i < statesCount; i++)
            {
                AkState s = new();
                s.Deserialize(wd);
                states.Add(s);
            }
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(stateGroupID));
            b.Add(stateSyncType);
            statesCount = (ulong)states.Count;
            b.AddRange(Utils.GetVariableIntBytes(statesCount));
            foreach (AkState s in states)
                b.AddRange(s.Serialize());
            return b;
        }
    }
}
