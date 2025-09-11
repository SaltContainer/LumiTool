namespace LumiTool.Data.Wwise
{
    public class MusicTransNodeParams : ISerializable
    {
        public MusicNodeParams musicNodeParams;
        public uint rulesCount;
        public List<MusicTransitionRule> rules;

        public MusicTransNodeParams Clone()
        {
            MusicTransNodeParams mtnp = (MusicTransNodeParams)this.MemberwiseClone();
            mtnp.musicNodeParams = musicNodeParams.Clone();
            mtnp.rules = new();
            foreach (MusicTransitionRule mtr in rules)
                mtnp.rules.Add(mtr.Clone());
            return mtnp;
        }

        public void Deserialize(WwiseData wd)
        {
            musicNodeParams = new();
            rules = new();
            musicNodeParams.Deserialize(wd);
            rulesCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < rulesCount; i++)
            {
                MusicTransitionRule mtr = new();
                mtr.Deserialize(wd);
                rules.Add(mtr);
            }
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(musicNodeParams.Serialize());
            rulesCount = (uint)rules.Count;
            b.AddRange(Utils.GetBytes(rulesCount));
            foreach (MusicTransitionRule mtr in rules)
                b.AddRange(mtr.Serialize());
            return b;
        }
    }
}
