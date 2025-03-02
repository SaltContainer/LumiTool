namespace LumiTool.Data.Wwise
{
    public class ActionResume : Action
    {
        public byte fadeCurve;
        public ResumeActionSpecificParams resumeActionSpecificParams;
        public ExceptParams exceptParams;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            resumeActionSpecificParams = new();
            exceptParams = new();
            fadeCurve = Utils.ReadUInt8(wd);
            resumeActionSpecificParams.Deserialize(wd);
            exceptParams.Deserialize(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.Add(fadeCurve);
            b.AddRange(resumeActionSpecificParams.Serialize());
            b.AddRange(exceptParams.Serialize());
            return b;
        }
    }
}
