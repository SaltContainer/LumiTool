namespace LumiTool.Data.Wwise
{
    public class ActorMixer : HircItem
    {
        public NodeBaseParams nodeBaseParams;
        public Children children;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            nodeBaseParams = new();
            children = new();
            nodeBaseParams.Deserialize(wd);
            children.Deserialize(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            b0.AddRange(nodeBaseParams.Serialize());
            b0.AddRange(children.Serialize());
            sectionSize = (uint)(b0.Count + 4);

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
