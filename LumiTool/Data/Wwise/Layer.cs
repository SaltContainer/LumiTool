namespace LumiTool.Data.Wwise
{
    public class Layer : ISerializable
    {
        public uint layerID;
        public LayerInitialValues layerInitialValues;

        public void Deserialize(WwiseData wd)
        {
            layerInitialValues = new();
            layerID = Utils.ReadUInt32(wd);
            layerInitialValues.Deserialize(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(layerID));
            b.AddRange(layerInitialValues.Serialize());
            return b;
        }
    }
}
