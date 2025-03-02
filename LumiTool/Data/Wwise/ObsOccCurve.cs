namespace LumiTool.Data.Wwise
{
    public class ObsOccCurve : ISerializable
    {
        public byte curveEnabled;
        public byte curveScaling;
        public ushort curveSize;
        public List<RTPCGraphPoint> points;

        public void Deserialize(WwiseData wd)
        {
            points = new();
            curveEnabled = Utils.ReadUInt8(wd);
            curveScaling = Utils.ReadUInt8(wd);
            curveSize = Utils.ReadUInt16(wd);
            for (int i = 0; i < curveSize; i++)
            {
                RTPCGraphPoint rtpcgp = new();
                rtpcgp.Deserialize(wd);
                points.Add(rtpcgp);
            }
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.Add(curveEnabled);
            b.Add(curveScaling);
            curveSize = (ushort)points.Count;
            b.AddRange(Utils.GetBytes(curveSize));
            foreach (RTPCGraphPoint rtpcgp in points)
                b.AddRange(rtpcgp.Serialize());
            return b;
        }
    }
}
