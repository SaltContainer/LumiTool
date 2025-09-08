namespace LumiTool.Data.Wwise
{
    public class FXChunk : ISerializable
    {
        public byte fxIndex;
        public uint fxID;
        public byte isShareSet;
        public byte isRendered;

        public void Deserialize(WwiseData wd)
        {
            fxIndex = Utils.ReadUInt8(wd);
            fxID = Utils.ReadUInt32(wd);
            isShareSet = Utils.ReadUInt8(wd);
            isRendered = Utils.ReadUInt8(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.Add(fxIndex);
            b.AddRange(Utils.GetBytes(fxID));
            b.Add(isShareSet);
            b.Add(isRendered);
            return b;
        }
    }
}
