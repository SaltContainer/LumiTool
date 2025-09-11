namespace LumiTool.Data.Wwise
{
    public class Attenuation : HircItem
    {
        public byte isConeEnabled;
        public ConeParams coneParams;
        public sbyte[] curveToUse;
        public byte curvesCount;
        public List<ConversionTable> curves;
        public InitialRTPC initialRTPC;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            curves = new();
            initialRTPC = new();
            isConeEnabled = Utils.ReadUInt8(wd);
            if (isConeEnabled > 0)
            {
                coneParams = new();
                coneParams.Deserialize(wd);
            }
            curveToUse = new sbyte[7];
            curveToUse = Utils.ReadInt8Array(wd, 7);
            curvesCount = Utils.ReadUInt8(wd);
            for (int i = 0; i < curvesCount; i++)
            {
                ConversionTable ct = new();
                ct.Deserialize(wd);
                curves.Add(ct);
            }
            initialRTPC.Deserialize(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            isConeEnabled = (byte)(coneParams == null ? 0 : 1);
            b0.Add(isConeEnabled);
            if (coneParams != null)
                b0.AddRange(coneParams.Serialize());
            b0.AddRange(Utils.GetBytes(curveToUse));
            curvesCount = (byte)curves.Count;
            b0.Add(curvesCount);
            foreach (ConversionTable ct in curves)
                b0.AddRange(ct.Serialize());
            b0.AddRange(initialRTPC.Serialize());
            sectionSize = (uint)(b0.Count + 4);

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
