namespace LumiTool.Data.Wwise
{
    public class RTPCParams : ISerializable
    {
        public float decayTime;
        public float hfDamping;
        public float diffusion;
        public float stereoWidth;
        public float filter1Gain;
        public float filter1Freq;
        public float filter1Q;
        public float filter2Gain;
        public float filter2Freq;
        public float filter2Q;
        public float filter3Gain;
        public float filter3Freq;
        public float filter3Q;
        public float frontLevel;
        public float rearLevel;
        public float centerLevel;
        public float lfeLevel;
        public float dryLevel;
        public float erLevel;
        public float reverbLevel;

        public void Deserialize(WwiseData wd)
        {
            decayTime = Utils.ReadSingle(wd);
            hfDamping = Utils.ReadSingle(wd);
            diffusion = Utils.ReadSingle(wd);
            stereoWidth = Utils.ReadSingle(wd);
            filter1Gain = Utils.ReadSingle(wd);
            filter1Freq = Utils.ReadSingle(wd);
            filter1Q = Utils.ReadSingle(wd);
            filter2Gain = Utils.ReadSingle(wd);
            filter2Freq = Utils.ReadSingle(wd);
            filter2Q = Utils.ReadSingle(wd);
            filter3Gain = Utils.ReadSingle(wd);
            filter3Freq = Utils.ReadSingle(wd);
            filter3Q = Utils.ReadSingle(wd);
            frontLevel = Utils.ReadSingle(wd);
            rearLevel = Utils.ReadSingle(wd);
            centerLevel = Utils.ReadSingle(wd);
            lfeLevel = Utils.ReadSingle(wd);
            dryLevel = Utils.ReadSingle(wd);
            erLevel = Utils.ReadSingle(wd);
            reverbLevel = Utils.ReadSingle(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(decayTime));
            b.AddRange(Utils.GetBytes(hfDamping));
            b.AddRange(Utils.GetBytes(diffusion));
            b.AddRange(Utils.GetBytes(stereoWidth));
            b.AddRange(Utils.GetBytes(filter1Gain));
            b.AddRange(Utils.GetBytes(filter1Freq));
            b.AddRange(Utils.GetBytes(filter1Q));
            b.AddRange(Utils.GetBytes(filter2Gain));
            b.AddRange(Utils.GetBytes(filter2Freq));
            b.AddRange(Utils.GetBytes(filter2Q));
            b.AddRange(Utils.GetBytes(filter3Gain));
            b.AddRange(Utils.GetBytes(filter3Freq));
            b.AddRange(Utils.GetBytes(filter3Q));
            b.AddRange(Utils.GetBytes(frontLevel));
            b.AddRange(Utils.GetBytes(rearLevel));
            b.AddRange(Utils.GetBytes(centerLevel));
            b.AddRange(Utils.GetBytes(lfeLevel));
            b.AddRange(Utils.GetBytes(dryLevel));
            b.AddRange(Utils.GetBytes(erLevel));
            b.AddRange(Utils.GetBytes(reverbLevel));
            return b;
        }
    }
}
