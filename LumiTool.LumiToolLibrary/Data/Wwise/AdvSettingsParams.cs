namespace LumiTool.Data.Wwise
{
    public class AdvSettingsParams : ISerializable
    {
        public bool killNewest;
        public bool useVirtualBehavior;
        public bool unkFlag2;
        public bool ignoreParentMaxNumInst;
        public bool isVVoicesOptOverrideParent;
        public byte virtualQueueBehavior;
        public ushort maxNumInstance;
        public byte belowThresholdBehavior;
        public bool overrideHdrEnvelope;
        public bool overrideAnalysis;
        public bool normalizeLoudness;
        public bool enableEnvelope;

        public AdvSettingsParams Clone()
        {
            return (AdvSettingsParams)this.MemberwiseClone();
        }

        public void Deserialize(WwiseData wd)
        {
            bool[] flags0 = Utils.ReadFlags(wd);
            killNewest = flags0[0];
            useVirtualBehavior = flags0[1];
            unkFlag2 = flags0[2];
            ignoreParentMaxNumInst = flags0[3];
            isVVoicesOptOverrideParent = flags0[4];
            virtualQueueBehavior = Utils.ReadUInt8(wd);
            maxNumInstance = Utils.ReadUInt16(wd);
            belowThresholdBehavior = Utils.ReadUInt8(wd);
            bool[] flags1 = Utils.ReadFlags(wd);
            overrideHdrEnvelope = flags1[0];
            overrideAnalysis = flags1[1];
            normalizeLoudness = flags1[2];
            enableEnvelope = flags1[3];
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            bool[] flags0 = {
                    killNewest,
                    useVirtualBehavior,
                    unkFlag2,
                    ignoreParentMaxNumInst,
                    isVVoicesOptOverrideParent
                };
            b.Add(Utils.GetByte(flags0));
            b.Add(virtualQueueBehavior);
            b.AddRange(Utils.GetBytes(maxNumInstance));
            b.Add(belowThresholdBehavior);
            bool[] flags1 = {
                    overrideHdrEnvelope,
                    overrideAnalysis,
                    normalizeLoudness,
                    enableEnvelope
                };
            b.Add(Utils.GetByte(flags1));
            return b;
        }
    }
}
