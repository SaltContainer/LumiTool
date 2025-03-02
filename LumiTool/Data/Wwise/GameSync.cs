namespace LumiTool.Data.Wwise
{
    public class GameSync : ISerializable
    {
        public uint group;
        public byte groupType;

        public void Deserialize(WwiseData wd)
        {
            group = Utils.ReadUInt32(wd);
        }

        public void DeserializeGroupType(WwiseData wd)
        {
            groupType = Utils.ReadUInt8(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            return Utils.GetBytes(group);
        }

        public IEnumerable<byte> SerializeGroupType()
        {
            return new byte[] { groupType };
        }
    }
}
