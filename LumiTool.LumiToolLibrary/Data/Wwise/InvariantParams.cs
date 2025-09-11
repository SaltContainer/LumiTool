namespace LumiTool.Data.Wwise
{
    public class InvariantParams : ISerializable
    {
        public byte enableEarlyReflections;
        public uint erPattern;
        public float reverbDelay;
        public float roomSize;
        public float erFrontBackDelay;
        public float density;
        public float roomShape;
        public uint numReverbUnits;
        public byte enableToneControls;
        public uint filter1Pos;
        public uint filter1Curve;
        public uint filter2Pos;
        public uint filter2Curve;
        public uint filter3Pos;
        public uint filter3Curve;
        public float inputCenterLevel;
        public float inputLFELevel;

        public void Deserialize(WwiseData wd)
        {
            enableEarlyReflections = Utils.ReadUInt8(wd);
            erPattern = Utils.ReadUInt32(wd);
            reverbDelay = Utils.ReadSingle(wd);
            roomSize = Utils.ReadSingle(wd);
            erFrontBackDelay = Utils.ReadSingle(wd);
            density = Utils.ReadSingle(wd);
            roomShape = Utils.ReadSingle(wd);
            numReverbUnits = Utils.ReadUInt32(wd);
            enableToneControls = Utils.ReadUInt8(wd);
            filter1Pos = Utils.ReadUInt32(wd);
            filter1Curve = Utils.ReadUInt32(wd);
            filter2Pos = Utils.ReadUInt32(wd);
            filter2Curve = Utils.ReadUInt32(wd);
            filter3Pos = Utils.ReadUInt32(wd);
            filter3Curve = Utils.ReadUInt32(wd);
            inputCenterLevel = Utils.ReadSingle(wd);
            inputLFELevel = Utils.ReadSingle(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.Add(enableEarlyReflections);
            b.AddRange(Utils.GetBytes(erPattern));
            b.AddRange(Utils.GetBytes(reverbDelay));
            b.AddRange(Utils.GetBytes(roomSize));
            b.AddRange(Utils.GetBytes(erFrontBackDelay));
            b.AddRange(Utils.GetBytes(density));
            b.AddRange(Utils.GetBytes(roomShape));
            b.AddRange(Utils.GetBytes(numReverbUnits));
            b.Add(enableToneControls);
            b.AddRange(Utils.GetBytes(filter1Pos));
            b.AddRange(Utils.GetBytes(filter1Curve));
            b.AddRange(Utils.GetBytes(filter2Pos));
            b.AddRange(Utils.GetBytes(filter2Curve));
            b.AddRange(Utils.GetBytes(filter3Pos));
            b.AddRange(Utils.GetBytes(filter3Curve));
            b.AddRange(Utils.GetBytes(inputCenterLevel));
            b.AddRange(Utils.GetBytes(inputLFELevel));
            return b;
        }
    }
}
