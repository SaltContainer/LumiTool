namespace LumiTool.Data.Wwise
{
    public class LayerInitialValues : ISerializable
    {
        public InitialRTPC initialRTPC;
        public uint rtpcID;
        public byte rtpcType;
        public uint assocCount;
        public List<AssociatedChildData> assocs;

        public void Deserialize(WwiseData wd)
        {
            initialRTPC = new();
            assocs = new();
            initialRTPC.Deserialize(wd);
            rtpcID = Utils.ReadUInt32(wd);
            rtpcType = Utils.ReadUInt8(wd);
            assocCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < assocCount; i++)
            {
                AssociatedChildData acd = new();
                acd.Deserialize(wd);
                assocs.Add(acd);
            }
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(initialRTPC.Serialize());
            b.AddRange(Utils.GetBytes(rtpcID));
            b.Add(rtpcType);
            assocCount = (uint)assocs.Count;
            b.AddRange(Utils.GetBytes(assocCount));
            foreach (AssociatedChildData acd in assocs)
                b.AddRange(acd.Serialize());
            return b;
        }
    }
}
