namespace LumiTool.Data.Wwise
{
    public abstract class Action : HircItem
    {
        public ushort actionType;
        public uint idExt;
        public byte isBus;
        public NodeInitialParams initialParams;

        public static Action GetInstance(WwiseData wd)
        {
            ushort actionType = BitConverter.ToUInt16(wd.buffer, wd.offset + 9);
            Action a = actionType switch
            {
                258 => new ActionStop(),
                259 => new ActionStop(),
                260 => new ActionStop(),
                514 => new ActionPause(),
                515 => new ActionPause(),
                516 => new ActionPause(),
                770 => new ActionResume(),
                772 => new ActionResume(),
                1027 => new ActionPlay(),
                1538 => new ActionMute(),
                1794 => new ActionMute(),
                2562 => new ActionSetAkProp(),
                2818 => new ActionSetAkProp(),
                3074 => new ActionSetAkProp(),
                3075 => new ActionSetAkProp(),
                3330 => new ActionSetAkProp(),
                3332 => new ActionSetAkProp(),
                4612 => new ActionSetState(),
                4866 => new ActionSetGameParameter(),
                4867 => new ActionSetGameParameter(),
                5122 => new ActionSetGameParameter(),
                5123 => new ActionSetGameParameter(),
                6401 => new ActionSetSwitch(),
                8451 => new ActionPlayEvent(),
                _ => throw new NotImplementedException("ActionType " + actionType + " at " + (wd.offset + 9)),
            };
            return a;
        }

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            initialParams = new();
            actionType = Utils.ReadUInt16(wd);
            idExt = Utils.ReadUInt32(wd);
            isBus = Utils.ReadUInt8(wd);
            initialParams.Deserialize(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(Utils.GetBytes(actionType));
            b.AddRange(Utils.GetBytes(idExt));
            b.Add(isBus);
            b.AddRange(initialParams.Serialize());
            return b;
        }
    }
}
