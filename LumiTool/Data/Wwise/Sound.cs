namespace LumiTool.Data.Wwise
{
    public class Sound : HircItem
    {
        public BankSourceData bankSourceData;
        public NodeBaseParams nodeBaseParams;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            bankSourceData = new();
            nodeBaseParams = new();
            bankSourceData.Deserialize(wd);
            nodeBaseParams.Deserialize(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            b0.AddRange(bankSourceData.Serialize());
            b0.AddRange(nodeBaseParams.Serialize());
            sectionSize = (uint)(b0.Count + 4);

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
