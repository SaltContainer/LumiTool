namespace LumiTool.Data.Wwise
{
    public class RanSeqCntr : HircItem
    {
        public NodeBaseParams nodeBaseParams;
        public ushort loopCount;
        public ushort loopModMin;
        public ushort loopModMax;
        public float transitionTime;
        public float transitionTimeModMin;
        public float transitionTimeModMax;
        public ushort avoidRepeatCount;
        public byte transitionMode;
        public byte randomMode;
        public byte mode;
        public bool isUsingWeight;
        public bool resetPlayListAtEachPlay;
        public bool isRestartBackward;
        public bool isContinuous;
        public bool isGlobal;
        public Children children;
        public PlayList playList;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            nodeBaseParams = new();
            children = new();
            playList = new();
            nodeBaseParams.Deserialize(wd);
            loopCount = Utils.ReadUInt16(wd);
            loopModMin = Utils.ReadUInt16(wd);
            loopModMax = Utils.ReadUInt16(wd);
            transitionTime = Utils.ReadSingle(wd);
            transitionTimeModMin = Utils.ReadSingle(wd);
            transitionTimeModMax = Utils.ReadSingle(wd);
            avoidRepeatCount = Utils.ReadUInt16(wd);
            transitionMode = Utils.ReadUInt8(wd);
            randomMode = Utils.ReadUInt8(wd);
            mode = Utils.ReadUInt8(wd);
            bool[] flags = Utils.ReadFlags(wd);
            isUsingWeight = flags[0];
            resetPlayListAtEachPlay = flags[1];
            isRestartBackward = flags[2];
            isContinuous = flags[3];
            isGlobal = flags[4];
            children.Deserialize(wd);
            playList.Deserialize(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            b0.AddRange(nodeBaseParams.Serialize());
            b0.AddRange(Utils.GetBytes(loopCount));
            b0.AddRange(Utils.GetBytes(loopModMin));
            b0.AddRange(Utils.GetBytes(loopModMax));
            b0.AddRange(Utils.GetBytes(transitionTime));
            b0.AddRange(Utils.GetBytes(transitionTimeModMin));
            b0.AddRange(Utils.GetBytes(transitionTimeModMax));
            b0.AddRange(Utils.GetBytes(avoidRepeatCount));
            b0.Add(transitionMode);
            b0.Add(randomMode);
            b0.Add(mode);
            bool[] flags = {
                    isUsingWeight,
                    resetPlayListAtEachPlay,
                    isRestartBackward,
                    isContinuous,
                    isGlobal
                };
            b0.Add(Utils.GetByte(flags));
            b0.AddRange(children.Serialize());
            b0.AddRange(playList.Serialize());
            sectionSize = (uint)(b0.Count + 4);

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
