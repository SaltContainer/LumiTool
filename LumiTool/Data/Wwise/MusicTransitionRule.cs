namespace LumiTool.Data.Wwise
{
    public class MusicTransitionRule : ISerializable
    {
        public uint srcCount;
        public List<uint> srcIDs;
        public uint dstCount;
        public List<uint> dstIDs;
        public MusicTransSrcRule musicTransSrcRule;
        public MusicTransDstRule musicTransDstRule;
        public byte allocTransObjectFlag;
        public MusicTransitionObject musicTransitionObject;

        public MusicTransitionRule Clone()
        {
            MusicTransitionRule mtr = (MusicTransitionRule)this.MemberwiseClone();
            mtr.srcIDs = new();
            mtr.srcIDs.AddRange(srcIDs);
            mtr.dstIDs = new();
            mtr.dstIDs.AddRange(dstIDs);
            mtr.musicTransSrcRule = musicTransSrcRule.Clone();
            mtr.musicTransDstRule = musicTransDstRule.Clone();
            if (musicTransitionObject != null)
                mtr.musicTransitionObject = musicTransitionObject.Clone();
            return mtr;
        }

        public void Deserialize(WwiseData wd)
        {
            srcIDs = new();
            dstIDs = new();
            musicTransSrcRule = new();
            musicTransDstRule = new();
            srcCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < srcCount; i++)
                srcIDs.Add(Utils.ReadUInt32(wd));
            dstCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < dstCount; i++)
                dstIDs.Add(Utils.ReadUInt32(wd));
            musicTransSrcRule.Deserialize(wd);
            musicTransDstRule.Deserialize(wd);
            allocTransObjectFlag = Utils.ReadUInt8(wd);
            if (allocTransObjectFlag > 0)
            {
                musicTransitionObject = new();
                musicTransitionObject.Deserialize(wd);
            }
        }

        public IEnumerable<byte> Serialize()
        {
            srcIDs.Sort();
            dstIDs.Sort();

            List<byte> b = new();
            srcCount = (uint)srcIDs.Count;
            b.AddRange(Utils.GetBytes(srcCount));
            foreach (uint i in srcIDs)
                b.AddRange(Utils.GetBytes(i));
            dstCount = (uint)dstIDs.Count;
            b.AddRange(Utils.GetBytes(dstCount));
            foreach (uint i in dstIDs)
                b.AddRange(Utils.GetBytes(i));
            b.AddRange(musicTransSrcRule.Serialize());
            b.AddRange(musicTransDstRule.Serialize());
            b.Add(allocTransObjectFlag);
            if (musicTransitionObject != null)
                b.AddRange(musicTransitionObject.Serialize());
            return b;
        }
    }
}
