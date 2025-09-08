namespace LumiTool.Data.Wwise
{
    public class LayerCntr : HircItem
    {
        public NodeBaseParams nodeBaseParams;
        public Children children;
        public uint layersCount;
        public List<Layer> layers;
        public byte isContinuousValidation;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            nodeBaseParams = new();
            children = new();
            layers = new();
            nodeBaseParams.Deserialize(wd);
            children.Deserialize(wd);
            layersCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < layersCount; i++)
            {
                Layer l = new();
                l.Deserialize(wd);
                layers.Add(l);
            }
            isContinuousValidation = Utils.ReadUInt8(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            b0.AddRange(nodeBaseParams.Serialize());
            b0.AddRange(children.Serialize());
            layersCount = (uint)layers.Count;
            b0.AddRange(Utils.GetBytes(layersCount));
            foreach (Layer l in layers)
                b0.AddRange(l.Serialize());
            b0.Add(isContinuousValidation);
            sectionSize = (uint)(b0.Count + 4);

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
