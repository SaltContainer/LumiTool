namespace LumiTool.Data.Wwise
{
    public abstract class WwiseObject : ISerializable
    {
        public abstract void Deserialize(WwiseData wd);
        public abstract IEnumerable<byte> Serialize();
    }
}
