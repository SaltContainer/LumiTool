namespace LumiTool.Data.Wwise
{
    public class EQModuleParams : ISerializable
    {
        public uint filterType;
        public float gain;
        public float frequency;
        public float qFactor;
        public byte onOff;

        public void Deserialize(WwiseData wd)
        {
            filterType = Utils.ReadUInt32(wd);
            gain = Utils.ReadSingle(wd);
            frequency = Utils.ReadSingle(wd);
            qFactor = Utils.ReadSingle(wd);
            onOff = Utils.ReadUInt8(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(filterType));
            b.AddRange(Utils.GetBytes(gain));
            b.AddRange(Utils.GetBytes(frequency));
            b.AddRange(Utils.GetBytes(qFactor));
            b.Add(onOff);
            return b;
        }
    }
}
