namespace LumiTool.Data.Wwise
{
    public class StateChunk : ISerializable
    {
        public ulong statePropsCount;
        public List<StatePropertyInfo> stateProps;
        public ulong stateGroupsCount;
        public List<StateGroupChunk> stateChunks;

        public StateChunk Clone()
        {
            StateChunk sc = (StateChunk)this.MemberwiseClone();
            sc.stateProps = new();
            foreach (StatePropertyInfo spi in stateProps)
                sc.stateProps.Add(spi.Clone());
            sc.stateChunks = new();
            foreach (StateGroupChunk sgc in stateChunks)
                sc.stateChunks.Add(sgc.Clone());
            return sc;
        }

        public void Deserialize(WwiseData wd)
        {
            stateProps = new();
            stateChunks = new();
            statePropsCount = Utils.ReadVariableInt(wd);
            for (ulong i = 0; i < statePropsCount; i++)
            {
                StatePropertyInfo spi = new();
                spi.Deserialize(wd);
                stateProps.Add(spi);
            }
            stateGroupsCount = Utils.ReadVariableInt(wd);
            for (ulong i = 0; i < stateGroupsCount; i++)
            {
                StateGroupChunk sgc = new();
                sgc.Deserialize(wd);
                stateChunks.Add(sgc);
            }
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            statePropsCount = (ulong)stateProps.Count;
            b.AddRange(Utils.GetVariableIntBytes(statePropsCount));
            foreach (StatePropertyInfo spi in stateProps)
                b.AddRange(spi.Serialize());
            stateGroupsCount = (ulong)stateChunks.Count;
            b.AddRange(Utils.GetVariableIntBytes(stateGroupsCount));
            foreach (StateGroupChunk sgc in stateChunks)
                b.AddRange(sgc.Serialize());
            return b;
        }
    }
}
