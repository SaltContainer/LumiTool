namespace LumiTool.Data.Wwise
{
    public class ConversionTable : ISerializable
    {
        public byte scaling;
        public ushort size;
        public List<RTPCGraphPoint> pRTPCMgr;

        public void Deserialize(WwiseData wd)
        {
            pRTPCMgr = new();
            scaling = Utils.ReadUInt8(wd);
            size = Utils.ReadUInt16(wd);
            for (int i = 0; i < size; i++)
            {
                RTPCGraphPoint rtpcgp = new();
                rtpcgp.Deserialize(wd);
                pRTPCMgr.Add(rtpcgp);
            }
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.Add(scaling);
            size = (ushort)pRTPCMgr.Count;
            b.AddRange(Utils.GetBytes(size));
            foreach (RTPCGraphPoint rtpcgp in pRTPCMgr)
                b.AddRange(rtpcgp.Serialize());
            return b;
        }
    }
}
