namespace LumiTool.Data.Wwise
{
    public class ActionPause : Action
    {
        public byte fadeCurve;
        public PauseActionSpecificParams pauseActionSpecificParams;
        public ExceptParams exceptParams;

        public ActionPause Clone()
        {
            ActionPause ap = (ActionPause)this.MemberwiseClone();
            ap.initialParams = initialParams.Clone();
            return ap;
        }

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            pauseActionSpecificParams = new();
            exceptParams = new();
            fadeCurve = Utils.ReadUInt8(wd);
            pauseActionSpecificParams.Deserialize(wd);
            exceptParams.Deserialize(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.Add(fadeCurve);
            b.AddRange(pauseActionSpecificParams.Serialize());
            b.AddRange(exceptParams.Serialize());
            return b;
        }
    }
}
