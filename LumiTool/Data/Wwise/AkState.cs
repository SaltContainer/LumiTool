namespace LumiTool.Data.Wwise
{
    public class AkState : ISerializable
    {
        public uint stateID;
        public uint stateInstanceID;

        public AkState Clone()
        {
            return (AkState)this.MemberwiseClone();
        }

        public void Deserialize(WwiseData wd)
        {
            stateID = Utils.ReadUInt32(wd);
            stateInstanceID = Utils.ReadUInt32(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(stateID));
            b.AddRange(Utils.GetBytes(stateInstanceID));
            return b;
        }
    }
}
