namespace LumiTool.Data.Wwise
{
    public class MediaHeader : WwiseObject
    {
        public uint id;
        public uint offset;
        public uint size;

        public override void Deserialize(WwiseData wd)
        {
            id = Utils.ReadUInt32(wd);
            wd.objectsByID[id] = this;
            offset = Utils.ReadUInt32(wd);
            size = Utils.ReadUInt32(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(id));
            b.AddRange(Utils.GetBytes(offset));
            b.AddRange(Utils.GetBytes(size));
            return b;
        }
    }
}
