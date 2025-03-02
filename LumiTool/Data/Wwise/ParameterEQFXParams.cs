namespace LumiTool.Data.Wwise
{
    public class ParameterEQFXParams : FXParams
    {
        public List<EQModuleParams> band;
        public float outputLevel;
        public byte processLFE;

        public override void Deserialize(WwiseData wd)
        {
            band = new();
            for (int i = 0; i < 3; i++)
            {
                EQModuleParams eqmp = new();
                eqmp.Deserialize(wd);
                band.Add(eqmp);
            }
            outputLevel = Utils.ReadSingle(wd);
            processLFE = Utils.ReadUInt8(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            foreach (EQModuleParams eqmp in band)
                b.AddRange(eqmp.Serialize());
            b.AddRange(Utils.GetBytes(outputLevel));
            b.Add(processLFE);
            return b;
        }
    }
}
