namespace LumiTool.Data.Wwise
{
    public class PlayList : ISerializable
    {
        public ushort playListItem;
        public List<PlaylistItem> items;

        public void Deserialize(WwiseData wd)
        {
            items = new();
            playListItem = Utils.ReadUInt16(wd);
            for (int i = 0; i < playListItem; i++)
            {
                PlaylistItem pli = new();
                pli.Deserialize(wd);
                items.Add(pli);
            }
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            playListItem = (ushort)items.Count;
            b.AddRange(Utils.GetBytes(playListItem));
            foreach (PlaylistItem pli in items)
                b.AddRange(pli.Serialize());
            return b;
        }
    }
}
