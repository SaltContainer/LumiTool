namespace LumiTool.Data.Wwise
{
    public class ActionMute : Action
    {
        public byte fadeCurve;
        public ExceptParams exceptParams;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            exceptParams = new();
            fadeCurve = Utils.ReadUInt8(wd);
            exceptParams.Deserialize(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.Add(fadeCurve);
            b.AddRange(exceptParams.Serialize());
            return b;
        }

        public override string ToString()
        {
            return $"[ActionMute ({actionType}) of ID {id}] Mutes {idExt}";
        }
    }
}
