namespace LumiTool.Data.Wwise
{
    public class RTPCGraphPoint : ISerializable
    {
        public float from;
        public float to;
        public uint interp;

        public RTPCGraphPoint Clone()
        {
            return (RTPCGraphPoint)this.MemberwiseClone();
        }

        public void Deserialize(WwiseData wd)
        {
            from = Utils.ReadSingle(wd);
            to = Utils.ReadSingle(wd);
            interp = Utils.ReadUInt32(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(from));
            b.AddRange(Utils.GetBytes(to));
            b.AddRange(Utils.GetBytes(interp));
            return b;
        }
    }
}
