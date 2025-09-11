namespace LumiTool.Data.Wwise
{
    public class RTPC : WwiseObject
    {
        public uint rtpcID;
        public byte rtpcType;
        public byte rtpcAccum;
        public ulong paramID;
        public uint rtpcCurveID;
        public byte scaling;
        public ushort size;
        public List<RTPCGraphPoint> pRTPCMgr;

        public RTPC Clone()
        {
            RTPC rtpc = (RTPC)this.MemberwiseClone();
            rtpc.pRTPCMgr = new();
            foreach (RTPCGraphPoint rtpcgp in pRTPCMgr)
                rtpc.pRTPCMgr.Add(rtpcgp.Clone());
            return rtpc;
        }

        public override void Deserialize(WwiseData wd)
        {
            pRTPCMgr = new();
            rtpcID = Utils.ReadUInt32(wd);
            rtpcType = Utils.ReadUInt8(wd);
            rtpcAccum = Utils.ReadUInt8(wd);
            paramID = Utils.ReadVariableInt(wd);
            rtpcCurveID = Utils.ReadUInt32(wd);
            wd.objectsByID[rtpcCurveID] = this;
            scaling = Utils.ReadUInt8(wd);
            size = Utils.ReadUInt16(wd);
            for (int i = 0; i < size; i++)
            {
                RTPCGraphPoint rtpcgp = new();
                rtpcgp.Deserialize(wd);
                pRTPCMgr.Add(rtpcgp);
            }
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(rtpcID));
            b.Add(rtpcType);
            b.Add(rtpcAccum);
            b.AddRange(Utils.GetVariableIntBytes(paramID));
            b.AddRange(Utils.GetBytes(rtpcCurveID));
            b.Add(scaling);
            size = (ushort)pRTPCMgr.Count;
            b.AddRange(Utils.GetBytes(size));
            foreach (RTPCGraphPoint rtpcgp in pRTPCMgr)
                b.AddRange(rtpcgp.Serialize());
            return b;
        }
    }
}
