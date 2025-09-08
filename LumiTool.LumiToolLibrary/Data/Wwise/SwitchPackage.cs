namespace LumiTool.Data.Wwise
{
    public class SwitchPackage : WwiseObject
    {
        public uint switchID;
        public uint itemsCount;
        public List<uint> nodeIDs;

        public override void Deserialize(WwiseData wd)
        {
            nodeIDs = new();
            switchID = Utils.ReadUInt32(wd);
            wd.objectsByID[switchID] = this;
            itemsCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < itemsCount; i++)
                nodeIDs.Add(Utils.ReadUInt32(wd));
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(switchID));
            itemsCount = (uint)nodeIDs.Count;
            b.AddRange(Utils.GetBytes(itemsCount));
            foreach (uint i in nodeIDs)
                b.AddRange(Utils.GetBytes(i));
            return b;
        }
    }
}
