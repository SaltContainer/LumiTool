namespace LumiTool.Data.Wwise
{
    public class MediaInformation : ISerializable
    {
        public uint sourceID;
        public uint inMemoryMediaSize;
        public bool isLanguageSpecific;
        public bool prefetch;
        public bool nonCachable;
        public bool hasSource;

        public MediaInformation Clone()
        {
            return (MediaInformation)this.MemberwiseClone();
        }

        public void Deserialize(WwiseData wd)
        {
            sourceID = Utils.ReadUInt32(wd);
            inMemoryMediaSize = Utils.ReadUInt32(wd);
            bool[] flags = Utils.ReadFlags(wd);
            isLanguageSpecific = flags[0];
            prefetch = flags[1];
            nonCachable = flags[3];
            hasSource = flags[7];
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(sourceID));
            b.AddRange(Utils.GetBytes(inMemoryMediaSize));
            bool[] flags = {
                    isLanguageSpecific,
                    prefetch,
                    false,
                    nonCachable,
                    false, false, false,
                    hasSource
                };
            b.Add(Utils.GetByte(flags));
            return b;
        }
    }
}
