namespace LumiTool.Data.Wwise
{
    public class MusicRanSeqPlaylistItem : WwiseObject
    {
        public uint segmentID;
        public uint playlistItemID;
        public uint childrenCount;
        public uint rsType;
        public short loop;
        public short loopMin;
        public short loopMax;
        public uint weight;
        public ushort avoidRepeatCount;
        public byte isUsingWeight;
        public byte isShuffle;
        public List<MusicRanSeqPlaylistItem> playList;

        public MusicRanSeqPlaylistItem Clone()
        {
            MusicRanSeqPlaylistItem mrspi = (MusicRanSeqPlaylistItem)this.MemberwiseClone();
            mrspi.playList = new();
            foreach (MusicRanSeqPlaylistItem mrspi0 in playList)
                mrspi.playList.Add(mrspi0.Clone());
            return mrspi;
        }

        public override void Deserialize(WwiseData wd)
        {
            playList = new();
            segmentID = Utils.ReadUInt32(wd);
            playlistItemID = Utils.ReadUInt32(wd);
            wd.objectsByID[playlistItemID] = this;
            childrenCount = Utils.ReadUInt32(wd);
            rsType = Utils.ReadUInt32(wd);
            loop = Utils.ReadInt16(wd);
            loopMin = Utils.ReadInt16(wd);
            loopMax = Utils.ReadInt16(wd);
            weight = Utils.ReadUInt32(wd);
            avoidRepeatCount = Utils.ReadUInt16(wd);
            isUsingWeight = Utils.ReadUInt8(wd);
            isShuffle = Utils.ReadUInt8(wd);
            for (int i = 0; i < childrenCount; i++)
            {
                MusicRanSeqPlaylistItem mrspi = new();
                mrspi.Deserialize(wd);
                playList.Add(mrspi);
            }
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(segmentID));
            b.AddRange(Utils.GetBytes(playlistItemID));
            childrenCount = (uint)playList.Count;
            b.AddRange(Utils.GetBytes(childrenCount));
            b.AddRange(Utils.GetBytes(rsType));
            b.AddRange(Utils.GetBytes(loop));
            b.AddRange(Utils.GetBytes(loopMin));
            b.AddRange(Utils.GetBytes(loopMax));
            b.AddRange(Utils.GetBytes(weight));
            b.AddRange(Utils.GetBytes(avoidRepeatCount));
            b.Add(isUsingWeight);
            b.Add(isShuffle);
            foreach (MusicRanSeqPlaylistItem mrspi in playList)
                b.AddRange(mrspi.Serialize());
            return b;
        }

        public int GetChildrenCount()
        {
            int n = 0;
            foreach (MusicRanSeqPlaylistItem mrspi in playList)
                n += 1 + mrspi.GetChildrenCount();
            return n;
        }
    }
}
