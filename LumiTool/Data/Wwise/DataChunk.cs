namespace LumiTool.Data.Wwise
{
    public class DataChunk : Chunk
    {
        public byte[] data;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            data = Utils.ReadUInt8Array(wd, (int)chunkSize);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            b0.AddRange(data);
            chunkSize = (uint)b0.Count;

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
