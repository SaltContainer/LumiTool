namespace LumiTool.Data.Wwise
{
    public class NodeInitialParams : ISerializable
    {
        public PropBundle0 propBundle0;
        public PropBundle2 propBundle2;

        public NodeInitialParams Clone()
        {
            NodeInitialParams nip = (NodeInitialParams)this.MemberwiseClone();
            nip.propBundle0 = propBundle0.Clone();
            nip.propBundle2 = propBundle2.Clone();
            return nip;
        }

        public void Deserialize(WwiseData wd)
        {
            propBundle0 = new();
            propBundle2 = new();
            propBundle0.Deserialize(wd);
            propBundle2.Deserialize(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(propBundle0.Serialize());
            b.AddRange(propBundle2.Serialize());
            return b;
        }
    }
}
