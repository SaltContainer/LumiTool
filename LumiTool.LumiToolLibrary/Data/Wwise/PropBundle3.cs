namespace LumiTool.Data.Wwise
{
    public class PropBundle3 : ISerializable
    {
        public byte id;
        public byte[] min;
        public byte[] max;

        public PropBundle3 Clone()
        {
            PropBundle3 pb3 = (PropBundle3)this.MemberwiseClone();
            pb3.min = new byte[min.Length];
            for (int i = 0; i < min.Length; i++)
                pb3.min[i] = min[i];
            pb3.max = new byte[max.Length];
            for (int i = 0; i < max.Length; i++)
                pb3.max[i] = max[i];
            return pb3;
        }

        public void Deserialize(WwiseData wd)
        {
            id = Utils.ReadUInt8(wd);
        }

        public void DeserializeBoundaries(WwiseData wd)
        {
            min = Utils.ReadUInt8Array(wd, 4);
            max = Utils.ReadUInt8Array(wd, 4);
        }

        public IEnumerable<byte> Serialize()
        {
            return new byte[] { id };
        }

        public IEnumerable<byte> SerializeBoundaries()
        {
            List<byte> b = new();
            b.AddRange(min);
            b.AddRange(max);
            return b;
        }

        public override string ToString()
        {
            return $"{id} : min: [{min[0]}, {min[1]}, {min[2]}, {min[3]}], max: [{max[0]}, {max[1]}, {max[2]}, {max[3]}]";
        }
    }
}
