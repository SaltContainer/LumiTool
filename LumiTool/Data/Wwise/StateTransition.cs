namespace LumiTool.Data.Wwise
{
    public class StateTransition : ISerializable
    {
        public uint stateFrom;
        public uint stateTo;
        public uint transitionTime;

        public void Deserialize(WwiseData wd)
        {
            stateFrom = Utils.ReadUInt32(wd);
            stateTo = Utils.ReadUInt32(wd);
            transitionTime = Utils.ReadUInt32(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(stateFrom));
            b.AddRange(Utils.GetBytes(stateTo));
            b.AddRange(Utils.GetBytes(transitionTime));
            return b;
        }
    }
}
