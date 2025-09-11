namespace LumiTool.Data.Wwise
{
    public interface ISerializable
    {
        public abstract void Deserialize(WwiseData wd);
        public abstract IEnumerable<byte> Serialize();
    }
}
