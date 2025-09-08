namespace LumiTool.Data.Wwise
{
    public class InitialRTPC : ISerializable
    {
        public ushort rtpcCount;
        public List<RTPC> pRTPCMgr;

        public InitialRTPC Clone()
        {
            InitialRTPC irtpc = (InitialRTPC)this.MemberwiseClone();
            irtpc.pRTPCMgr = new();
            foreach (RTPC rtpc in pRTPCMgr)
                irtpc.pRTPCMgr.Add(rtpc.Clone());
            return irtpc;
        }

        public void Deserialize(WwiseData wd)
        {
            pRTPCMgr = new();
            rtpcCount = Utils.ReadUInt16(wd);
            for (int i = 0; i < rtpcCount; i++)
            {
                RTPC rtpc = new();
                rtpc.Deserialize(wd);
                pRTPCMgr.Add(rtpc);
            }
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            rtpcCount = (ushort)pRTPCMgr.Count;
            b.AddRange(Utils.GetBytes(rtpcCount));
            foreach (RTPC rtpc in pRTPCMgr)
                b.AddRange(rtpc.Serialize());
            return b;
        }
    }
}
