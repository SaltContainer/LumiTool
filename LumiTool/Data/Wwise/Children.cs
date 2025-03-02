namespace LumiTool.Data.Wwise
{
    public class Children : ISerializable
    {
        public uint childsCount;
        public List<uint> childIDs;

        public Children Clone()
        {
            Children c = (Children)this.MemberwiseClone();
            c.childIDs = new();
            c.childIDs.AddRange(childIDs);
            return c;
        }

        public void Deserialize(WwiseData wd)
        {
            childIDs = new();
            childsCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < childsCount; i++)
                childIDs.Add(Utils.ReadUInt32(wd));
        }

        public IEnumerable<byte> Serialize()
        {
            childIDs.Sort();

            List<byte> b = new();
            childsCount = (uint)childIDs.Count;
            b.AddRange(Utils.GetBytes(childsCount));
            foreach (uint i in childIDs)
                b.AddRange(Utils.GetBytes(i));
            return b;
        }
    }
}
