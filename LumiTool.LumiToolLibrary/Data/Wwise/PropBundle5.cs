namespace LumiTool.Data.Wwise
{
    public class PropBundle5 : ISerializable
    {
        public ushort id;
        public float value;

        public void Deserialize(WwiseData wd)
        {
            id = Utils.ReadUInt16(wd);
        }

        public void DeserializeValue(WwiseData wd)
        {
            value = Utils.ReadSingle(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            return Utils.GetBytes(id);
        }

        public IEnumerable<byte> SerializeValue()
        {
            return Utils.GetBytes(value);
        }
    }
}
