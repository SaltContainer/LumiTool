namespace LumiTool.Data.Wwise
{
    public class Node : ISerializable
    {
        public uint key;
        public ushort childrenIdx;
        public ushort childrenCount;
        public uint audioNodeId;
        public ushort weight;
        public ushort probability;
        public List<Node> nodes;

        public int level;

        public Node(int level)
        {
            this.level = level;
        }

        public Node Clone()
        {
            Node n = (Node)this.MemberwiseClone();
            n.nodes = new();
            foreach (Node oldN in nodes)
                n.nodes.Add(oldN.Clone());
            return n;
        }

        public void Deserialize(WwiseData wd)
        {
            nodes = new();
            key = Utils.ReadUInt32(wd);
            if (level > 0)
            {
                childrenIdx = Utils.ReadUInt16(wd);
                childrenCount = Utils.ReadUInt16(wd);
            }
            else
                audioNodeId = Utils.ReadUInt32(wd);
            weight = Utils.ReadUInt16(wd);
            probability = Utils.ReadUInt16(wd);
            for (int i = 0; level > 0 && i < childrenCount; i++)
                nodes.Add(new(level - 1));
        }

        public void DeserializeChildren(WwiseData wd)
        {
            if (level == 0)
                return;
            foreach (Node n in nodes)
                n.Deserialize(wd);
            foreach (Node n in nodes)
                n.DeserializeChildren(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            nodes.Sort((o0, o1) => o0.key.CompareTo(o1.key));

            List<byte> b = new();
            b.AddRange(Utils.GetBytes(key));
            if (level > 0)
            {
                b.AddRange(Utils.GetBytes(childrenIdx));
                childrenCount = (ushort)nodes.Count;
                b.AddRange(Utils.GetBytes(childrenCount));
            }
            else
                b.AddRange(Utils.GetBytes(audioNodeId));
            b.AddRange(Utils.GetBytes(weight));
            b.AddRange(Utils.GetBytes(probability));
            return b;
        }

        public IEnumerable<byte> SerializeChildren()
        {
            List<byte> b = new();
            if (level == 0)
                return b;
            int nodeIdx = childrenIdx + childrenCount;
            foreach (Node n in nodes)
            {
                if (n.level > 0)
                    n.childrenIdx = (ushort)nodeIdx;
                b.AddRange(n.Serialize());
                nodeIdx += n.GetIdxIncrement();
            }
            foreach (Node n in nodes)
                b.AddRange(n.SerializeChildren());
            return b;
        }

        public int GetIdxIncrement()
        {
            if (level == 0)
                return 0;
            int inc = nodes.Count;
            foreach (Node n in nodes)
                inc += n.GetIdxIncrement();
            return inc;
        }
    }
}
