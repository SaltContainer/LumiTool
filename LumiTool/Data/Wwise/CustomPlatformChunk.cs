namespace LumiTool.Data.Wwise
{
    public class CustomPlatformChunk : Chunk
    {
        public uint stringSize;
        public string customPlatformName;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            stringSize = Utils.ReadUInt32(wd);
            customPlatformName = Utils.ReadString(wd, (int)stringSize);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            b0.AddRange(Utils.GetBytes(stringSize));
            b0.AddRange(Utils.GetBytes(customPlatformName));
            chunkSize = (uint)b0.Count;

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
