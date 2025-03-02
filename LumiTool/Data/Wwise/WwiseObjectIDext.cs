namespace LumiTool.Data.Wwise
{
    public class WwiseObjectIDext : ISerializable
    {
        public uint id;
        public byte isBus;

        public void Deserialize(WwiseData wd)
        {
            id = Utils.ReadUInt32(wd);
            isBus = Utils.ReadUInt8(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(id));
            b.Add(isBus);
            return b;
        }
    }
}
