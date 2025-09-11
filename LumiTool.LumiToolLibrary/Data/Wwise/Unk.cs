namespace LumiTool.Data.Wwise
{
    public class Unk : ISerializable
    {
        public Unk Clone() => new();

        public void Deserialize(WwiseData wd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<byte> Serialize()
        {
            throw new NotImplementedException();
        }
    }
}
