namespace LumiTool.Data.Wwise
{
    public class ExceptParams : ISerializable
    {
        public ulong exceptionListSize;
        public List<WwiseObjectIDext> listElementException;

        public ExceptParams()
        {
            listElementException = new List<WwiseObjectIDext>();
        }

        public void Deserialize(WwiseData wd)
        {
            listElementException = new();
            exceptionListSize = Utils.ReadVariableInt(wd);
            for (ulong i = 0; i < exceptionListSize; i++)
            {
                WwiseObjectIDext woid = new();
                woid.Deserialize(wd);
                listElementException.Add(woid);
            }
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            exceptionListSize = (ulong)listElementException.Count;
            b.AddRange(Utils.GetVariableIntBytes(exceptionListSize));
            foreach (WwiseObjectIDext woid in listElementException)
                b.AddRange(woid.Serialize());
            return b;
        }
    }
}
