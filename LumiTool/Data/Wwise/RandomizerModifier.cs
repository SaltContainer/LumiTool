namespace LumiTool.Data.Wwise
{
    public class RandomizerModifier : ISerializable
    {
        public float _base;
        public float min;
        public float max;

        public void Deserialize(WwiseData wd)
        {
            _base = Utils.ReadSingle(wd);
            min = Utils.ReadSingle(wd);
            max = Utils.ReadSingle(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(_base));
            b.AddRange(Utils.GetBytes(min));
            b.AddRange(Utils.GetBytes(max));
            return b;
        }
    }
}
