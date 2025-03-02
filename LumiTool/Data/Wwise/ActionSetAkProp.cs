namespace LumiTool.Data.Wwise
{
    public class ActionSetAkProp : Action
    {
        public byte fadeCurve;
        public AkPropActionSpecificParams akPropActionSpecificParams;
        public ExceptParams exceptParams;

        public ActionSetAkProp Clone()
        {
            ActionSetAkProp asap = (ActionSetAkProp)this.MemberwiseClone();
            asap.propBundle0 = propBundle0.Clone();
            asap.propBundle1 = propBundle1.Clone();
            return asap;
        }

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            akPropActionSpecificParams = new();
            exceptParams = new();
            fadeCurve = Utils.ReadUInt8(wd);
            akPropActionSpecificParams.Deserialize(wd);
            exceptParams.Deserialize(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.Add(fadeCurve);
            b.AddRange(akPropActionSpecificParams.Serialize());
            b.AddRange(exceptParams.Serialize());
            return b;
        }
    }
}
