namespace LumiTool.Data.Wwise
{
    public class MusicTransDstRule : ISerializable
    {
        public int transitionTime;
        public uint fadeCurve;
        public int fadeOffset;
        public uint cueFilterHash;
        public uint jumpToID;
        public ushort jumpToType;
        public ushort entryType;
        public byte playPreEntry;
        public byte destMatchSourceCueName;

        public MusicTransDstRule Clone()
        {
            return (MusicTransDstRule)this.MemberwiseClone();
        }

        public void Deserialize(WwiseData wd)
        {
            transitionTime = Utils.ReadInt32(wd);
            fadeCurve = Utils.ReadUInt32(wd);
            fadeOffset = Utils.ReadInt32(wd);
            cueFilterHash = Utils.ReadUInt32(wd);
            jumpToID = Utils.ReadUInt32(wd);
            jumpToType = Utils.ReadUInt16(wd);
            entryType = Utils.ReadUInt16(wd);
            playPreEntry = Utils.ReadUInt8(wd);
            destMatchSourceCueName = Utils.ReadUInt8(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(transitionTime));
            b.AddRange(Utils.GetBytes(fadeCurve));
            b.AddRange(Utils.GetBytes(fadeOffset));
            b.AddRange(Utils.GetBytes(cueFilterHash));
            b.AddRange(Utils.GetBytes(jumpToID));
            b.AddRange(Utils.GetBytes(jumpToType));
            b.AddRange(Utils.GetBytes(entryType));
            b.Add(playPreEntry);
            b.Add(destMatchSourceCueName);
            return b;
        }
    }
}
