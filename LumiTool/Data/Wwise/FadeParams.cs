namespace LumiTool.Data.Wwise
{
    public class FadeParams : ISerializable
    {
        public int transitionTime;
        public uint fadeCurve;
        public int fadeOffset;

        public FadeParams Clone()
        {
            return (FadeParams)this.MemberwiseClone();
        }

        public void Deserialize(WwiseData wd)
        {
            transitionTime = Utils.ReadInt32(wd);
            fadeCurve = Utils.ReadUInt32(wd);
            fadeOffset = Utils.ReadInt32(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(transitionTime));
            b.AddRange(Utils.GetBytes(fadeCurve));
            b.AddRange(Utils.GetBytes(fadeOffset));
            return b;
        }
    }
}
