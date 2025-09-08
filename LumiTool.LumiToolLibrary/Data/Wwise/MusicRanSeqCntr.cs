namespace LumiTool.Data.Wwise
{
    public class MusicRanSeqCntr : HircItem
    {
        public MusicTransNodeParams musicTransNodeParams;
        public uint playlistItemsCount;
        public List<MusicRanSeqPlaylistItem> playList;

        public MusicRanSeqCntr Clone()
        {
            MusicRanSeqCntr mrsc = (MusicRanSeqCntr)this.MemberwiseClone();
            mrsc.musicTransNodeParams = musicTransNodeParams.Clone();
            mrsc.playList = new();
            foreach (MusicRanSeqPlaylistItem mrspi in playList)
                mrsc.playList.Add(mrspi.Clone());
            return mrsc;
        }

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            musicTransNodeParams = new();
            playList = new();
            musicTransNodeParams.Deserialize(wd);
            playlistItemsCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < playlistItemsCount; i++)
            {
                MusicRanSeqPlaylistItem mrspi = new();
                mrspi.Deserialize(wd);
                i += mrspi.GetChildrenCount();
                playList.Add(mrspi);
            }
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            b0.AddRange(musicTransNodeParams.Serialize());
            playlistItemsCount = 0;
            foreach (MusicRanSeqPlaylistItem mrspi in playList)
                playlistItemsCount += 1 + (uint)mrspi.GetChildrenCount();
            b0.AddRange(Utils.GetBytes(playlistItemsCount));
            foreach (MusicRanSeqPlaylistItem mrspi in playList)
                b0.AddRange(mrspi.Serialize());
            sectionSize = (uint)(b0.Count + 4);

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
