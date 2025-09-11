namespace LumiTool.Data.Wwise
{
    public class MusicSwitchCntr : HircItem
    {
        public MusicTransNodeParams musicTransNodeParams;
        public byte isContinuePlayback;
        public uint treeDepth;
        public List<GameSync> arguments;
        public uint treeDataSize;
        public byte mode;
        public Node decisionTree;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            musicTransNodeParams = new();
            arguments = new();
            musicTransNodeParams.Deserialize(wd);
            isContinuePlayback = Utils.ReadUInt8(wd);
            treeDepth = Utils.ReadUInt32(wd);
            for (int i = 0; i < treeDepth; i++)
            {
                GameSync gs = new();
                gs.Deserialize(wd);
                arguments.Add(gs);
            }
            foreach (GameSync gs in arguments)
                gs.DeserializeGroupType(wd);
            treeDataSize = Utils.ReadUInt32(wd);
            mode = Utils.ReadUInt8(wd);
            decisionTree = new((int)treeDepth);
            decisionTree.Deserialize(wd);
            decisionTree.DeserializeChildren(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            b0.AddRange(musicTransNodeParams.Serialize());
            b0.Add(isContinuePlayback);
            b0.AddRange(Utils.GetBytes(treeDepth));
            foreach (GameSync gs in arguments)
                b0.AddRange(gs.Serialize());
            foreach (GameSync gs in arguments)
                b0.AddRange(gs.SerializeGroupType());

            List<byte> b1 = new();
            decisionTree.childrenIdx = 1;
            b1.AddRange(decisionTree.Serialize());
            b1.AddRange(decisionTree.SerializeChildren());
            treeDataSize = (uint)b1.Count;
            b0.AddRange(Utils.GetBytes(treeDataSize));

            b0.Add(mode);
            b0.AddRange(b1);
            sectionSize = (uint)(b0.Count + 4);

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
