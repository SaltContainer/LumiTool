namespace LumiTool.Data.Wwise
{
    public abstract class FXParams : ISerializable
    {
        public uint fxID;
        public uint size;
        public abstract void Deserialize(WwiseData wd);

        public static FXParams Create(WwiseData wd)
        {
            uint fxID = Utils.ReadUInt32(wd);
            FXParams fxp = fxID switch
            {
                6881283 => new ParameterEQFXParams(),
                7733251 => new StereoDelayFXParams(),
                8192003 => new FlangerFXParams(),
                8454147 => new MeterFXParams(),
                _ => throw new NotImplementedException("fxID " + fxID + " at " + wd.offset),
            };
            fxp.fxID = fxID;
            fxp.size = Utils.ReadUInt32(wd);
            fxp.Deserialize(wd);
            return fxp;
        }

        public abstract IEnumerable<byte> Serialize();
    }
}
