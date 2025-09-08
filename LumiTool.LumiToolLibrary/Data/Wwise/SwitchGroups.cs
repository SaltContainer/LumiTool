namespace LumiTool.Data.Wwise
{
    public class SwitchGroups : ISerializable
    {
        public uint switchGroupID;
        public uint rtpcID;
        public byte rtpcType;
        public uint size;
        public List<RTPCGraphPoint> switchMgr;

        public void Deserialize(WwiseData wd)
        {
            switchMgr = new();
            switchGroupID = Utils.ReadUInt32(wd);
            rtpcID = Utils.ReadUInt32(wd);
            rtpcType = Utils.ReadUInt8(wd);
            size = Utils.ReadUInt32(wd);
            for (int i = 0; i < size; i++)
            {
                RTPCGraphPoint rtcpgp = new();
                rtcpgp.Deserialize(wd);
                switchMgr.Add(rtcpgp);
            }
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(switchGroupID));
            b.AddRange(Utils.GetBytes(rtpcID));
            b.Add(rtpcType);
            size = (uint)switchMgr.Count;
            b.AddRange(Utils.GetBytes(size));
            foreach (RTPCGraphPoint rtcpgp in switchMgr)
                b.AddRange(rtcpgp.Serialize());
            return b;
        }
    }
}
