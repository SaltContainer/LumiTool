namespace LumiTool.Data.Wwise
{
    public class StateGroup : WwiseObject
    {
        public uint stateGroupID;
        public uint defaultTransitionTime;
        public uint transitionsCount;
        public List<StateTransition> mapTransitions;

        public override void Deserialize(WwiseData wd)
        {
            mapTransitions = new();
            stateGroupID = Utils.ReadUInt32(wd);
            wd.objectsByID[stateGroupID] = this;
            defaultTransitionTime = Utils.ReadUInt32(wd);
            transitionsCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < transitionsCount; i++)
            {
                StateTransition st = new();
                st.Deserialize(wd);
                mapTransitions.Add(st);
            }
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(stateGroupID));
            b.AddRange(Utils.GetBytes(defaultTransitionTime));
            transitionsCount = (uint)mapTransitions.Count;
            b.AddRange(Utils.GetBytes(transitionsCount));
            foreach (StateTransition st in mapTransitions)
                b.AddRange(st.Serialize());
            return b;
        }
    }
}
