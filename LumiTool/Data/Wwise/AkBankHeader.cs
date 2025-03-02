namespace LumiTool.Data.Wwise
{
    public class AkBankHeader : ISerializable
    {
        public uint bankGeneratorVersion;
        public uint soundBankID;
        public uint languageID;
        public ushort unused;
        public ushort deviceAllocated;
        public uint projectID;

        public void Deserialize(WwiseData wd)
        {
            bankGeneratorVersion = Utils.ReadUInt32(wd);
            soundBankID = Utils.ReadUInt32(wd);
            languageID = Utils.ReadUInt32(wd);
            unused = Utils.ReadUInt16(wd);
            deviceAllocated = Utils.ReadUInt16(wd);
            projectID = Utils.ReadUInt32(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(bankGeneratorVersion));
            b.AddRange(Utils.GetBytes(soundBankID));
            b.AddRange(Utils.GetBytes(languageID));
            b.AddRange(Utils.GetBytes(unused));
            b.AddRange(Utils.GetBytes(deviceAllocated));
            b.AddRange(Utils.GetBytes(projectID));
            return b;
        }
    }
}
