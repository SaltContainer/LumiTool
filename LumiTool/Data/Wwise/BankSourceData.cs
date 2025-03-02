namespace LumiTool.Data.Wwise
{
    public class BankSourceData : ISerializable
    {
        public uint pluginID;
        public byte streamType;
        public MediaInformation mediaInformation;

        public BankSourceData Clone()
        {
            BankSourceData bsd = (BankSourceData)this.MemberwiseClone();
            bsd.mediaInformation = mediaInformation.Clone();
            return bsd;
        }

        public void Deserialize(WwiseData wd)
        {
            mediaInformation = new();
            pluginID = Utils.ReadUInt32(wd);
            streamType = Utils.ReadUInt8(wd);
            mediaInformation.Deserialize(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(pluginID));
            b.Add(streamType);
            b.AddRange(mediaInformation.Serialize());
            return b;
        }
    }
}
