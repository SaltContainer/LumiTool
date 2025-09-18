namespace LumiTool.Data.Wwise
{
    public class AkPropActionSpecificParams : ISerializable
    {
        public byte valueMeaning;
        public RandomizerModifier randomizerModifier;

        public AkPropActionSpecificParams()
        {
            randomizerModifier = new RandomizerModifier();
        }

        public void Deserialize(WwiseData wd)
        {
            randomizerModifier = new();
            valueMeaning = Utils.ReadUInt8(wd);
            randomizerModifier.Deserialize(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.Add(valueMeaning);
            b.AddRange(randomizerModifier.Serialize());
            return b;
        }
    }
}
