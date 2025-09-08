namespace LumiTool.Data.Wwise
{
    public class ConeParams : ISerializable
    {
        public float insideDegrees;
        public float outsideDegrees;
        public float outsideVolume;
        public float loPass;
        public float hiPass;

        public void Deserialize(WwiseData wd)
        {
            insideDegrees = Utils.ReadSingle(wd);
            outsideDegrees = Utils.ReadSingle(wd);
            outsideVolume = Utils.ReadSingle(wd);
            loPass = Utils.ReadSingle(wd);
            hiPass = Utils.ReadSingle(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(insideDegrees));
            b.AddRange(Utils.GetBytes(outsideDegrees));
            b.AddRange(Utils.GetBytes(outsideVolume));
            b.AddRange(Utils.GetBytes(loPass));
            b.AddRange(Utils.GetBytes(hiPass));
            return b;
        }
    }
}
