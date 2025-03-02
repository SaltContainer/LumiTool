namespace LumiTool.Data.Wwise
{
    public class WwiseData
    {
        internal byte[] buffer;
        internal int offset;
        public readonly Dictionary<uint, WwiseObject> objectsByID;
        public List<Bank> banks;

        public WwiseData()
        {
            objectsByID = new Dictionary<uint, WwiseObject>();
            banks = new();
        }

        public WwiseData(byte[] buffer)
        {
            this.buffer = buffer;
            offset = 0;
            objectsByID = new Dictionary<uint, WwiseObject>();
            banks = new();
            Bank b = new();
            b.Deserialize(this);
            banks.Add(b);
        }

        public void Parse(byte[] buffer)
        {
            this.buffer = buffer;
            offset = 0;
            Bank b = new();
            b.Deserialize(this);
            banks.Add(b);
        }

        public byte[] GetBytes()
        {
            return banks.First().Serialize().ToArray();
        }

        public byte[] GetBytes(uint id)
        {
            return objectsByID[id].Serialize().ToArray();
        }
    }
}
