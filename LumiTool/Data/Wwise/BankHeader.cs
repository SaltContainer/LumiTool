namespace LumiTool.Data.Wwise
{
    public class BankHeader : Chunk
    {
        public AkBankHeader akBankHeader;
        public int padding;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            akBankHeader = new();
            int offset = wd.offset;
            akBankHeader.Deserialize(wd);
            padding = (int)(offset + chunkSize - wd.offset);
            wd.offset += padding;
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            b0.AddRange(akBankHeader.Serialize());
            b0.AddRange(new byte[padding]);
            chunkSize = (uint)b0.Count;

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
