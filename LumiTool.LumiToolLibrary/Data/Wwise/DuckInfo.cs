namespace LumiTool.Data.Wwise
{
    public class DuckInfo : ISerializable
    {
        public uint busID;
        public float duckVolume;
        public int fadeOutTime;
        public int fadeInTime;
        public byte fadeCurve;
        public byte targetProp;

        public void Deserialize(WwiseData wd)
        {
            busID = Utils.ReadUInt32(wd);
            duckVolume = Utils.ReadSingle(wd);
            fadeOutTime = Utils.ReadInt32(wd);
            fadeInTime = Utils.ReadInt32(wd);
            fadeCurve = Utils.ReadUInt8(wd);
            targetProp = Utils.ReadUInt8(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(busID));
            b.AddRange(Utils.GetBytes(duckVolume));
            b.AddRange(Utils.GetBytes(fadeOutTime));
            b.AddRange(Utils.GetBytes(fadeInTime));
            b.Add(fadeCurve);
            b.Add(targetProp);
            return b;
        }
    }
}
