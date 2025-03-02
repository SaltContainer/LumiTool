namespace LumiTool.Data.Wwise
{
    public class PositioningParams : ISerializable
    {
        public bool positioningInfoOverrideParent;
        public bool hasListenerRelativeRouting;
        public bool pannerType;
        public bool _3DPositionType;
        public bool spatializationMode;
        public bool unkFlag1;
        public bool enableAttenuation;
        public bool holdEmitterPosAndOrient;
        public bool holdListenerOrient;
        public bool enableDiffraction;
        public bool unkFlag7;

        public PositioningParams Clone()
        {
            return (PositioningParams)this.MemberwiseClone();
        }

        public void Deserialize(WwiseData wd)
        {
            bool[] flags0 = Utils.ReadFlags(wd);
            positioningInfoOverrideParent = flags0[0];
            hasListenerRelativeRouting = flags0[1];
            pannerType = flags0[2];
            _3DPositionType = flags0[5];
            if (hasListenerRelativeRouting)
            {
                bool[] flags1 = Utils.ReadFlags(wd);
                spatializationMode = flags1[0];
                unkFlag1 = flags1[1];
                enableAttenuation = flags1[3];
                holdEmitterPosAndOrient = flags1[4];
                holdListenerOrient = flags1[5];
                enableDiffraction = flags1[6];
                unkFlag7 = flags1[7];
            }
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            bool[] flags0 = {
                    positioningInfoOverrideParent,
                    hasListenerRelativeRouting,
                    pannerType,
                    false, false,
                    _3DPositionType
                };
            b.Add(Utils.GetByte(flags0));
            if (hasListenerRelativeRouting)
            {
                bool[] flags1 = {
                        spatializationMode,
                        unkFlag1,
                        false,
                        enableAttenuation,
                        holdEmitterPosAndOrient,
                        holdListenerOrient,
                        enableDiffraction,
                        unkFlag7
                    };
                b.Add(Utils.GetByte(flags1));
            }
            return b;
        }
    }
}
