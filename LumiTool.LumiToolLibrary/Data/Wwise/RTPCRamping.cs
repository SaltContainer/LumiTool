namespace LumiTool.Data.Wwise
{
    public class RTPCRamping : WwiseObject
    {
        public uint rtpcID;
        public float value;
        public uint rampType;
        public float rampUp;
        public float rampDown;
        public byte bindToBuiltInParam;

        public override void Deserialize(WwiseData wd)
        {
            rtpcID = Utils.ReadUInt32(wd);
            wd.objectsByID[rtpcID] = this;
            value = Utils.ReadSingle(wd);
            rampType = Utils.ReadUInt32(wd);
            rampUp = Utils.ReadSingle(wd);
            rampDown = Utils.ReadSingle(wd);
            bindToBuiltInParam = Utils.ReadUInt8(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(rtpcID));
            b.AddRange(Utils.GetBytes(value));
            b.AddRange(Utils.GetBytes(rampType));
            b.AddRange(Utils.GetBytes(rampUp));
            b.AddRange(Utils.GetBytes(rampDown));
            b.Add(bindToBuiltInParam);
            return b;
        }
    }
}
