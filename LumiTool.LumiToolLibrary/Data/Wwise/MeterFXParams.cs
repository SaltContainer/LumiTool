namespace LumiTool.Data.Wwise
{
    public class MeterFXParams : FXParams
    {
        public float rtpcAttack;
        public float rtpcRelease;
        public float rtpcMin;
        public float rtpcMax;
        public float rtpcHold;
        public byte nonRTPCMode;
        public byte nonRTPCScope;
        public byte nonRTPCApplyDownstreamVolume;
        public uint nonRTPCGameParamID;

        public override void Deserialize(WwiseData wd)
        {
            rtpcAttack = Utils.ReadSingle(wd);
            rtpcRelease = Utils.ReadSingle(wd);
            rtpcMin = Utils.ReadSingle(wd);
            rtpcMax = Utils.ReadSingle(wd);
            rtpcHold = Utils.ReadSingle(wd);
            nonRTPCMode = Utils.ReadUInt8(wd);
            nonRTPCScope = Utils.ReadUInt8(wd);
            nonRTPCApplyDownstreamVolume = Utils.ReadUInt8(wd);
            nonRTPCGameParamID = Utils.ReadUInt32(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(rtpcAttack));
            b.AddRange(Utils.GetBytes(rtpcRelease));
            b.AddRange(Utils.GetBytes(rtpcMin));
            b.AddRange(Utils.GetBytes(rtpcMax));
            b.AddRange(Utils.GetBytes(rtpcHold));
            b.Add(nonRTPCMode);
            b.Add(nonRTPCScope);
            b.Add(nonRTPCApplyDownstreamVolume);
            b.AddRange(Utils.GetBytes(nonRTPCGameParamID));
            return b;
        }
    }
}
