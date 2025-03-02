namespace LumiTool.Data.Wwise
{
    public class MusicMarkerWwise : ISerializable
    {
        public uint id;
        public double position;
        public uint stringSize;

        public MusicMarkerWwise Clone()
        {
            return (MusicMarkerWwise)this.MemberwiseClone();
        }

        public void Deserialize(WwiseData wd)
        {
            id = Utils.ReadUInt32(wd);
            position = Utils.ReadDouble(wd);
            stringSize = Utils.ReadUInt32(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(id));
            b.AddRange(Utils.GetBytes(position));
            b.AddRange(Utils.GetBytes(stringSize));
            return b;
        }
    }
}
