namespace LumiTool.Data.Wwise
{
    public class AssociatedChildData : ISerializable
    {
        public uint associatedChildID;
        public uint curveSize;
        public List<RTPCGraphPoint> pRTPCMgr;

        public void Deserialize(WwiseData wd)
        {
            pRTPCMgr = new();
            associatedChildID = Utils.ReadUInt32(wd);
            curveSize = Utils.ReadUInt32(wd);
            for (int i = 0; i < curveSize; i++)
            {
                RTPCGraphPoint rtpcgp = new();
                rtpcgp.Deserialize(wd);
                pRTPCMgr.Add(rtpcgp);
            }
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(associatedChildID));
            curveSize = (uint)pRTPCMgr.Count;
            b.AddRange(Utils.GetBytes(curveSize));
            foreach (RTPCGraphPoint rtpcgp in pRTPCMgr)
                b.AddRange(rtpcgp.Serialize());
            return b;
        }
    }
}
