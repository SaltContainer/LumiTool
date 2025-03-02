namespace LumiTool.Data.Wwise
{
    public class BusInitialParams : ISerializable
    {
        public PropBundle0 propBundle0;
        public PositioningParams positioningParams;
        public AuxParams auxParams;
        public bool killNewest;
        public bool useVirtualBehavior;
        public bool isMaxNumInstIgnoreParent;
        public bool isBackgroundMusic;
        public ushort maxNumInstance;
        public uint channelConfig;
        public bool isHdrBus;
        public bool hdrReleaseModeExponential;

        public void Deserialize(WwiseData wd)
        {
            propBundle0 = new();
            positioningParams = new();
            auxParams = new();
            propBundle0.Deserialize(wd);
            positioningParams.Deserialize(wd);
            auxParams.Deserialize(wd);
            bool[] flags0 = Utils.ReadFlags(wd);
            killNewest = flags0[0];
            useVirtualBehavior = flags0[1];
            isMaxNumInstIgnoreParent = flags0[2];
            isBackgroundMusic = flags0[3];
            maxNumInstance = Utils.ReadUInt16(wd);
            channelConfig = Utils.ReadUInt32(wd);
            bool[] flags1 = Utils.ReadFlags(wd);
            isHdrBus = flags1[0];
            hdrReleaseModeExponential = flags1[1];
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(propBundle0.Serialize());
            b.AddRange(positioningParams.Serialize());
            b.AddRange(auxParams.Serialize());
            bool[] flags0 = {
                    killNewest,
                    useVirtualBehavior,
                    isMaxNumInstIgnoreParent,
                    isBackgroundMusic
                };
            b.Add(Utils.GetByte(flags0));
            b.AddRange(Utils.GetBytes(maxNumInstance));
            b.AddRange(Utils.GetBytes(channelConfig));
            bool[] flags1 = {
                    isHdrBus,
                    hdrReleaseModeExponential
                };
            b.Add(Utils.GetByte(flags1));
            return b;
        }
    }
}
