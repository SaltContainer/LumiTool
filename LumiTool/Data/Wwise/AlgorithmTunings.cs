namespace LumiTool.Data.Wwise
{
    public class AlgorithmTunings : ISerializable
    {
        public float densityDelayMin;
        public float densityDelayMax;
        public float densityDelayRdmPerc;
        public float roomShapeMin;
        public float roomShapeMax;
        public float diffusionDelayScalePerc;
        public float diffusionDelayMax;
        public float diffusionDelayRdmPerc;
        public float dcFilterCutFreq;
        public float reverbUnitInputDelay;
        public float reverbUnitInputDelayRmdPerc;

        public void Deserialize(WwiseData wd)
        {
            densityDelayMin = Utils.ReadSingle(wd);
            densityDelayMax = Utils.ReadSingle(wd);
            densityDelayRdmPerc = Utils.ReadSingle(wd);
            roomShapeMin = Utils.ReadSingle(wd);
            roomShapeMax = Utils.ReadSingle(wd);
            diffusionDelayScalePerc = Utils.ReadSingle(wd);
            diffusionDelayMax = Utils.ReadSingle(wd);
            diffusionDelayRdmPerc = Utils.ReadSingle(wd);
            dcFilterCutFreq = Utils.ReadSingle(wd);
            reverbUnitInputDelay = Utils.ReadSingle(wd);
            reverbUnitInputDelayRmdPerc = Utils.ReadSingle(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(densityDelayMin));
            b.AddRange(Utils.GetBytes(densityDelayMax));
            b.AddRange(Utils.GetBytes(densityDelayRdmPerc));
            b.AddRange(Utils.GetBytes(roomShapeMin));
            b.AddRange(Utils.GetBytes(roomShapeMax));
            b.AddRange(Utils.GetBytes(diffusionDelayScalePerc));
            b.AddRange(Utils.GetBytes(diffusionDelayMax));
            b.AddRange(Utils.GetBytes(diffusionDelayRdmPerc));
            b.AddRange(Utils.GetBytes(dcFilterCutFreq));
            b.AddRange(Utils.GetBytes(reverbUnitInputDelay));
            b.AddRange(Utils.GetBytes(reverbUnitInputDelayRmdPerc));
            return b;
        }
    }
}
