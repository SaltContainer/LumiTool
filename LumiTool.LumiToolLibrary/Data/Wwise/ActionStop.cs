namespace LumiTool.Data.Wwise
{
    public class ActionStop : Action
    {
        public byte fadeCurve;
        public StopActionSpecificParams stopActionSpecificParams;
        public ExceptParams exceptParams;

        public ActionStop()
        {
            stopActionSpecificParams = new StopActionSpecificParams();
            exceptParams = new ExceptParams();
        }

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            stopActionSpecificParams = new();
            exceptParams = new();
            fadeCurve = Utils.ReadUInt8(wd);
            stopActionSpecificParams.Deserialize(wd);
            exceptParams.Deserialize(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.Add(fadeCurve);
            b.AddRange(stopActionSpecificParams.Serialize());
            b.AddRange(exceptParams.Serialize());
            return b;
        }

        public override string ToString()
        {
            return $"[ActionStop ({actionType}) of ID {id}] Stops {idExt}";
        }
    }
}
