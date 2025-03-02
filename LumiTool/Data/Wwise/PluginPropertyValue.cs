namespace LumiTool.Data.Wwise
{
    public class PluginPropertyValue : ISerializable
    {
        public ulong propertyID;
        public byte rtpcAccum;
        public float value;

        public void Deserialize(WwiseData wd)
        {
            propertyID = Utils.ReadVariableInt(wd);
            rtpcAccum = Utils.ReadUInt8(wd);
            value = Utils.ReadSingle(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetVariableIntBytes(propertyID));
            b.Add(rtpcAccum);
            b.AddRange(Utils.GetBytes(value));
            return b;
        }
    }
}
