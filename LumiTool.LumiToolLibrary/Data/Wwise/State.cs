namespace LumiTool.Data.Wwise
{
    public class State : HircItem
    {
        public PropBundle4 propBundle4;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            propBundle4 = new();
            propBundle4.Deserialize(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            b0.AddRange(propBundle4.Serialize());
            sectionSize = (uint)(b0.Count + 4);

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
