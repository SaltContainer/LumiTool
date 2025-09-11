namespace LumiTool.Data.Wwise
{
    public class SwitchParams : ISerializable
    {
        public byte groupType;
        public uint groupID;
        public uint defaultSwitch;
        public uint switchAssocCount;
        public List<TrackSwitchAssoc> switchAssoc;

        public SwitchParams Clone()
        {
            SwitchParams sp = (SwitchParams)this.MemberwiseClone();
            sp.switchAssoc = new();
            foreach (TrackSwitchAssoc tsa in switchAssoc)
                sp.switchAssoc.Add(tsa.Clone());
            return sp;
        }

        public void Deserialize(WwiseData wd)
        {
            switchAssoc = new();
            groupType = Utils.ReadUInt8(wd);
            groupID = Utils.ReadUInt32(wd);
            defaultSwitch = Utils.ReadUInt32(wd);
            switchAssocCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < switchAssocCount; i++)
            {
                TrackSwitchAssoc tsa = new();
                tsa.Deserialize(wd);
                switchAssoc.Add(tsa);
            }
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.Add(groupType);
            b.AddRange(Utils.GetBytes(groupID));
            b.AddRange(Utils.GetBytes(defaultSwitch));
            switchAssocCount = (uint)switchAssoc.Count;
            b.AddRange(Utils.GetBytes(switchAssocCount));
            foreach (TrackSwitchAssoc tsa in switchAssoc)
                b.AddRange(tsa.Serialize());
            return b;
        }
    }
}
