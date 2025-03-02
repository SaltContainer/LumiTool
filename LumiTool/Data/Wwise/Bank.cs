namespace LumiTool.Data.Wwise
{
    public class Bank : WwiseObject
    {
        public List<Chunk> chunks;

        public override void Deserialize(WwiseData wd)
        {
            chunks = new();
            while (wd.offset < wd.buffer.Length)
            {
                Chunk c = Chunk.Create(wd);
                chunks.Add(c);
                if (c is BankHeader bh)
                    wd.objectsByID[bh.akBankHeader.soundBankID] = this;
            }
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            foreach (Chunk c in chunks)
                b.AddRange(c.Serialize());
            return b;
        }
    }
}
