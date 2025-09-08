namespace LumiTool.Data.Wwise
{
    public class AudioDevice : HircItem
    {
        public uint fxID;
        public uint size;
        public byte bankDataCount;
        public List<Unk> media;
        public InitialRTPC initialRTPC;
        public StateChunk stateChunk;
        public ushort valuesCount;
        public List<Unk> propertyValues;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            media = new();
            initialRTPC = new();
            stateChunk = new();
            propertyValues = new();
            fxID = Utils.ReadUInt32(wd);
            size = Utils.ReadUInt32(wd);
            bankDataCount = Utils.ReadUInt8(wd);
            for (int i = 0; i < bankDataCount; i++)
            {
                Unk u = new();
                u.Deserialize(wd);
                media.Add(u);
            }
            initialRTPC.Deserialize(wd);
            stateChunk.Deserialize(wd);
            valuesCount = Utils.ReadUInt16(wd);
            for (int i = 0; i < valuesCount; i++)
            {
                Unk u = new();
                u.Deserialize(wd);
                propertyValues.Add(u);
            }
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            b0.AddRange(Utils.GetBytes(fxID));
            b0.AddRange(Utils.GetBytes(size));
            bankDataCount = (byte)media.Count;
            b0.Add(bankDataCount);
            foreach (Unk u in media)
                b0.AddRange(u.Serialize());
            b0.AddRange(initialRTPC.Serialize());
            b0.AddRange(stateChunk.Serialize());
            valuesCount = (ushort)propertyValues.Count;
            b0.AddRange(Utils.GetBytes(valuesCount));
            foreach (Unk u in propertyValues)
                b0.AddRange(u.Serialize());
            sectionSize = (uint)(b0.Count + 4);

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
