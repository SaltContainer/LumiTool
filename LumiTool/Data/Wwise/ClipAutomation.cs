namespace LumiTool.Data.Wwise
{
    public class ClipAutomation : ISerializable
    {
        public uint clipIndex;
        public uint autoType;
        public uint pointsCount;
        public List<RTPCGraphPoint> graphPoints;

        public ClipAutomation Clone()
        {
            ClipAutomation ca = (ClipAutomation)this.MemberwiseClone();
            ca.graphPoints = new();
            foreach (RTPCGraphPoint rtpcgc in graphPoints)
                ca.graphPoints.Add(rtpcgc.Clone());
            return ca;
        }

        public void Deserialize(WwiseData wd)
        {
            graphPoints = new();
            clipIndex = Utils.ReadUInt32(wd);
            autoType = Utils.ReadUInt32(wd);
            pointsCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < pointsCount; i++)
            {
                RTPCGraphPoint rtpcgp = new();
                rtpcgp.Deserialize(wd);
                graphPoints.Add(rtpcgp);
            }
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(clipIndex));
            b.AddRange(Utils.GetBytes(autoType));
            pointsCount = (uint)graphPoints.Count;
            b.AddRange(Utils.GetBytes(pointsCount));
            foreach (RTPCGraphPoint rtpcgp in graphPoints)
                b.AddRange(rtpcgp.Serialize());
            return b;
        }
    }
}
