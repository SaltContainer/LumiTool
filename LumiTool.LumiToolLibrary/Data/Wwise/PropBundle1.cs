namespace LumiTool.Data.Wwise
{
    public class PropBundle1 : ISerializable
    {
        public byte id;
        public float value;

        public PropBundle1 Clone()
        {
            return (PropBundle1)this.MemberwiseClone();
        }

        public void Deserialize(WwiseData wd)
        {
            id = Utils.ReadUInt8(wd);
        }

        public void DeserializeValue(WwiseData wd)
        {
            value = Utils.ReadSingle(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            return new byte[] { id };
        }

        public IEnumerable<byte> SerializeValue()
        {
            return Utils.GetBytes(value);
        }

        public override string ToString()
        {
            return $"{id} : {value}";
        }
    }
}
