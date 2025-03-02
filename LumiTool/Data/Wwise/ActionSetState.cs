namespace LumiTool.Data.Wwise
{
    public class ActionSetState : Action
    {
        public uint stateGroupID;
        public uint targetStateID;

        public ActionSetState Clone()
        {
            ActionSetState ass = (ActionSetState)this.MemberwiseClone();
            ass.propBundle0 = propBundle0.Clone();
            ass.propBundle1 = propBundle1.Clone();
            return ass;
        }

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            stateGroupID = Utils.ReadUInt32(wd);
            targetStateID = Utils.ReadUInt32(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(Utils.GetBytes(stateGroupID));
            b.AddRange(Utils.GetBytes(targetStateID));
            return b;
        }
    }
}
