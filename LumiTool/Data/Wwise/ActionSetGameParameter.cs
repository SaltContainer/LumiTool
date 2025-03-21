﻿namespace LumiTool.Data.Wwise
{
    public class ActionSetGameParameter : Action
    {
        public byte fadeCurve;
        public GameParameterActionSpecificParams gameParameterActionSpecificParams;
        public ExceptParams exceptParams;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            gameParameterActionSpecificParams = new();
            exceptParams = new();
            fadeCurve = Utils.ReadUInt8(wd);
            gameParameterActionSpecificParams.Deserialize(wd);
            exceptParams.Deserialize(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.Add(fadeCurve);
            b.AddRange(gameParameterActionSpecificParams.Serialize());
            b.AddRange(exceptParams.Serialize());
            return b;
        }
    }
}
