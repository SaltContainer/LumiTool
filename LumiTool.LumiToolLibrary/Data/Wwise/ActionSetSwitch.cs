namespace LumiTool.Data.Wwise
{
    public class ActionSetSwitch : Action
    {
        public uint switchGroupID;
        public uint switchStateID;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            switchGroupID = Utils.ReadUInt32(wd);
            switchStateID = Utils.ReadUInt32(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(Utils.GetBytes(switchGroupID));
            b.AddRange(Utils.GetBytes(switchStateID));
            return b;
        }

        public override string ToString()
        {
            return $"[ActionSetSwitch ({actionType}) of ID {id}] Sets switch for group {switchGroupID} to state {switchStateID}";
        }
    }
}
