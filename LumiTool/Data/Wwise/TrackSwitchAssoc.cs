namespace LumiTool.Data.Wwise
{
    public class TrackSwitchAssoc : ISerializable
    {
        public uint switchAssoc;

        public TrackSwitchAssoc Clone()
        {
            return (TrackSwitchAssoc)this.MemberwiseClone();
        }

        public void Deserialize(WwiseData wd)
        {
            switchAssoc = Utils.ReadUInt32(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            return Utils.GetBytes(switchAssoc);
        }
    }
}
