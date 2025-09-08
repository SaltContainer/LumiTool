namespace LumiTool.Data.Wwise
{
    public class StereoDelayFXParams : FXParams
    {
        public RTPCParams rtpcParams;
        public InvariantParams invariantParams;
        public AlgorithmTunings algorithmTunings;

        public override void Deserialize(WwiseData wd)
        {
            rtpcParams = new();
            invariantParams = new();
            algorithmTunings = new();
            rtpcParams.Deserialize(wd);
            invariantParams.Deserialize(wd);
            algorithmTunings.Deserialize(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(rtpcParams.Serialize());
            b.AddRange(invariantParams.Serialize());
            b.AddRange(algorithmTunings.Serialize());
            return b;
        }
    }
}
