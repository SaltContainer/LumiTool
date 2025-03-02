namespace LumiTool.Data.Wwise
{
    public class StatePropertyInfo : ISerializable
    {
        public ulong propertyID;
        public byte accumType;
        public byte inDb;

        public StatePropertyInfo Clone()
        {
            return (StatePropertyInfo)this.MemberwiseClone();
        }

        public void Deserialize(WwiseData wd)
        {
            propertyID = Utils.ReadVariableInt(wd);
            accumType = Utils.ReadUInt8(wd);
            inDb = Utils.ReadUInt8(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetVariableIntBytes(propertyID));
            b.Add(accumType);
            b.Add(inDb);
            return b;
        }
    }
}
