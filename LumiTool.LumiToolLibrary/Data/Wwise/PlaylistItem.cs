namespace LumiTool.Data.Wwise
{
    public class PlaylistItem : ISerializable
    {
        public uint playID;
        public int weight;

        public void Deserialize(WwiseData wd)
        {
            playID = Utils.ReadUInt32(wd);
            weight = Utils.ReadInt32(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(playID));
            b.AddRange(Utils.GetBytes(weight));
            return b;
        }
    }
}
