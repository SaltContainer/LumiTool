namespace LumiTool.Data.Wwise
{
    public class FlangerFXParams : FXParams
    {
        public float nonRTPCDelayTime;
        public float RTPCDryLevel;
        public float RTPCFfwdLevel;
        public float RTPCFbackLevel;
        public float RTPCModDepth;
        public float RTPCModParamsLFOParamsFrequency;
        public uint RTPCModParamsLFOParamsWaveform;
        public float RTPCModParamsLFOParamsSmooth;
        public float RTPCModParamsLFOParamsPWM;
        public float RTPCModParamsPhaseParamsPhaseOffset;
        public uint RTPCModParamsPhaseParamsPhaseMode;
        public float RTPCModParamsPhaseParamsPhaseSpread;
        public float RTPCOutputLevel;
        public float RTPCWetDryMix;
        public byte nonRTPCEnableLFO;
        public byte nonRTPCProcessCenter;
        public byte nonRTPCProcessLFE;

        public override void Deserialize(WwiseData wd)
        {
            nonRTPCDelayTime = Utils.ReadSingle(wd);
            RTPCDryLevel = Utils.ReadSingle(wd);
            RTPCFfwdLevel = Utils.ReadSingle(wd);
            RTPCFbackLevel = Utils.ReadSingle(wd);
            RTPCModDepth = Utils.ReadSingle(wd);
            RTPCModParamsLFOParamsFrequency = Utils.ReadSingle(wd);
            RTPCModParamsLFOParamsWaveform = Utils.ReadUInt32(wd);
            RTPCModParamsLFOParamsSmooth = Utils.ReadSingle(wd);
            RTPCModParamsLFOParamsPWM = Utils.ReadSingle(wd);
            RTPCModParamsPhaseParamsPhaseOffset = Utils.ReadSingle(wd);
            RTPCModParamsPhaseParamsPhaseMode = Utils.ReadUInt32(wd);
            RTPCModParamsPhaseParamsPhaseSpread = Utils.ReadSingle(wd);
            RTPCOutputLevel = Utils.ReadSingle(wd);
            RTPCWetDryMix = Utils.ReadSingle(wd);
            nonRTPCEnableLFO = Utils.ReadUInt8(wd);
            nonRTPCProcessCenter = Utils.ReadUInt8(wd);
            nonRTPCProcessLFE = Utils.ReadUInt8(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(nonRTPCDelayTime));
            b.AddRange(Utils.GetBytes(RTPCDryLevel));
            b.AddRange(Utils.GetBytes(RTPCFfwdLevel));
            b.AddRange(Utils.GetBytes(RTPCFbackLevel));
            b.AddRange(Utils.GetBytes(RTPCModDepth));
            b.AddRange(Utils.GetBytes(RTPCModParamsLFOParamsFrequency));
            b.AddRange(Utils.GetBytes(RTPCModParamsLFOParamsWaveform));
            b.AddRange(Utils.GetBytes(RTPCModParamsLFOParamsSmooth));
            b.AddRange(Utils.GetBytes(RTPCModParamsLFOParamsPWM));
            b.AddRange(Utils.GetBytes(RTPCModParamsPhaseParamsPhaseOffset));
            b.AddRange(Utils.GetBytes(RTPCModParamsPhaseParamsPhaseMode));
            b.AddRange(Utils.GetBytes(RTPCModParamsPhaseParamsPhaseSpread));
            b.AddRange(Utils.GetBytes(RTPCOutputLevel));
            b.AddRange(Utils.GetBytes(RTPCWetDryMix));
            b.Add(nonRTPCEnableLFO);
            b.Add(nonRTPCProcessCenter);
            b.Add(nonRTPCProcessLFE);
            return b;
        }
    }
}
