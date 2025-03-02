namespace LumiTool.Data.Wwise
{
    public class EnvSettingsChunk : Chunk
    {
        public ObsOccCurve[][] obsOccCurves;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            obsOccCurves = new ObsOccCurve[2][];
            for (int i = 0; i < obsOccCurves.Length; i++)
            {
                obsOccCurves[i] = new ObsOccCurve[3];
                for (int j = 0; j < obsOccCurves[i].Length; j++)
                {
                    ObsOccCurve ooc = new();
                    ooc.Deserialize(wd);
                    obsOccCurves[i][j] = ooc;
                }
            }
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            foreach (ObsOccCurve[] ooca in obsOccCurves)
                foreach (ObsOccCurve ooc in ooca)
                    b0.AddRange(ooc.Serialize());
            chunkSize = (uint)b0.Count;

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
