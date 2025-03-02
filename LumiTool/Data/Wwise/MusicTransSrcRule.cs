namespace LumiTool.Data.Wwise
{
    public class MusicTransSrcRule : ISerializable
    {
        public int transitionTime;
        public uint fadeCurve;
        public int fadeOffset;
        public uint syncType;
        public uint cueFilterHash;
        public byte playPostExit;

        public MusicTransSrcRule Clone()
        {
            return (MusicTransSrcRule)this.MemberwiseClone();
        }

        public void Deserialize(WwiseData wd)
        {
            transitionTime = Utils.ReadInt32(wd);
            fadeCurve = Utils.ReadUInt32(wd);
            fadeOffset = Utils.ReadInt32(wd);
            syncType = Utils.ReadUInt32(wd);
            cueFilterHash = Utils.ReadUInt32(wd);
            playPostExit = Utils.ReadUInt8(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(transitionTime));
            b.AddRange(Utils.GetBytes(fadeCurve));
            b.AddRange(Utils.GetBytes(fadeOffset));
            b.AddRange(Utils.GetBytes(syncType));
            b.AddRange(Utils.GetBytes(cueFilterHash));
            b.Add(playPostExit);
            return b;
        }
    }
}
