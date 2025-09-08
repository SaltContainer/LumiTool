namespace LumiTool.Data.Wwise
{
    public class TrackSrcInfo : ISerializable
    {
        public uint trackID;
        public uint sourceID;
        public uint eventID;
        public double playAt;
        public double beginTrimOffset;
        public double endTrimOffset;
        public double srcDuration;

        public TrackSrcInfo Clone()
        {
            return (TrackSrcInfo)this.MemberwiseClone();
        }

        public void Deserialize(WwiseData wd)
        {
            trackID = Utils.ReadUInt32(wd);
            sourceID = Utils.ReadUInt32(wd);
            eventID = Utils.ReadUInt32(wd);
            playAt = Utils.ReadDouble(wd);
            beginTrimOffset = Utils.ReadDouble(wd);
            endTrimOffset = Utils.ReadDouble(wd);
            srcDuration = Utils.ReadDouble(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(trackID));
            b.AddRange(Utils.GetBytes(sourceID));
            b.AddRange(Utils.GetBytes(eventID));
            b.AddRange(Utils.GetBytes(playAt));
            b.AddRange(Utils.GetBytes(beginTrimOffset));
            b.AddRange(Utils.GetBytes(endTrimOffset));
            b.AddRange(Utils.GetBytes(srcDuration));
            return b;
        }
    }
}
