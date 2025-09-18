namespace LumiTool.Data.Wwise
{
    public class GameParameterActionSpecificParams : ISerializable
    {
        public byte bypassTransition;
        public byte valueMeaning;
        public RangedParameter rangedParameter;

        public GameParameterActionSpecificParams()
        {
            rangedParameter = new RangedParameter();
        }

        public void Deserialize(WwiseData wd)
        {
            rangedParameter = new();
            bypassTransition = Utils.ReadUInt8(wd);
            valueMeaning = Utils.ReadUInt8(wd);
            rangedParameter.Deserialize(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.Add(bypassTransition);
            b.Add(valueMeaning);
            b.AddRange(rangedParameter.Serialize());
            return b;
        }
    }
}
