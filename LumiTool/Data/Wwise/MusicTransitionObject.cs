namespace LumiTool.Data.Wwise
{
    public class MusicTransitionObject : ISerializable
    {
        public uint segmentID;
        public FadeParams fadeInParams;
        public FadeParams fadeOutParams;
        public byte playPreEntry;
        public byte playPostExit;

        public MusicTransitionObject Clone()
        {
            MusicTransitionObject mto = (MusicTransitionObject)this.MemberwiseClone();
            mto.fadeInParams = fadeInParams.Clone();
            mto.fadeOutParams = fadeOutParams.Clone();
            return mto;
        }

        public void Deserialize(WwiseData wd)
        {
            fadeInParams = new();
            fadeOutParams = new();
            segmentID = Utils.ReadUInt32(wd);
            fadeInParams.Deserialize(wd);
            fadeOutParams.Deserialize(wd);
            playPreEntry = Utils.ReadUInt8(wd);
            playPostExit = Utils.ReadUInt8(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(segmentID));
            b.AddRange(fadeInParams.Serialize());
            b.AddRange(fadeOutParams.Serialize());
            b.Add(playPreEntry);
            b.Add(playPostExit);
            return b;
        }
    }
}
