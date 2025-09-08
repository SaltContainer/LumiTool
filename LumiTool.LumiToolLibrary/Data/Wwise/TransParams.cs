namespace LumiTool.Data.Wwise
{
    public class TransParams : ISerializable
    {
        public FadeParams srcFadeParams;
        public uint syncType;
        public uint cueFilterHash;
        public FadeParams destFadeParams;

        public TransParams Clone()
        {
            TransParams tp = (TransParams)this.MemberwiseClone();
            tp.srcFadeParams = srcFadeParams.Clone();
            tp.destFadeParams = destFadeParams.Clone();
            return tp;
        }

        public void Deserialize(WwiseData wd)
        {
            srcFadeParams = new();
            destFadeParams = new();
            srcFadeParams.Deserialize(wd);
            syncType = Utils.ReadUInt32(wd);
            cueFilterHash = Utils.ReadUInt32(wd);
            destFadeParams.Deserialize(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(srcFadeParams.Serialize());
            b.AddRange(Utils.GetBytes(syncType));
            b.AddRange(Utils.GetBytes(cueFilterHash));
            b.AddRange(destFadeParams.Serialize());
            return b;
        }
    }
}
