namespace LumiTool.Data.Wwise
{
    public class MeterInfo : ISerializable
    {
        public double gridPeriod;
        public double gridOffset;
        public float tempo;
        public byte timeSigNumBeatsBar;
        public byte timeSigBeatValue;

        public MeterInfo Clone()
        {
            return (MeterInfo)this.MemberwiseClone();
        }

        public void Deserialize(WwiseData wd)
        {
            gridPeriod = Utils.ReadDouble(wd);
            gridOffset = Utils.ReadDouble(wd);
            tempo = Utils.ReadSingle(wd);
            timeSigNumBeatsBar = Utils.ReadUInt8(wd);
            timeSigBeatValue = Utils.ReadUInt8(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(gridPeriod));
            b.AddRange(Utils.GetBytes(gridOffset));
            b.AddRange(Utils.GetBytes(tempo));
            b.Add(timeSigNumBeatsBar);
            b.Add(timeSigBeatValue);
            return b;
        }
    }
}
