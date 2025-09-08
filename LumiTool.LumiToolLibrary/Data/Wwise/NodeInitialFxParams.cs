namespace LumiTool.Data.Wwise
{
    public class NodeInitialFxParams : ISerializable
    {
        public byte isOverrideParentFX;
        public byte numFx;

        public NodeInitialFxParams Clone()
        {
            return (NodeInitialFxParams)this.MemberwiseClone();
        }

        public void Deserialize(WwiseData wd)
        {
            isOverrideParentFX = Utils.ReadUInt8(wd);
            numFx = Utils.ReadUInt8(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.Add(isOverrideParentFX);
            b.Add(numFx);
            return b;
        }
    }
}
