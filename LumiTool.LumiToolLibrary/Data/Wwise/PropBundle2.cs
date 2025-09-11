namespace LumiTool.Data.Wwise
{
    public class PropBundle2 : ISerializable
    {
        public byte propsCount;
        public List<PropBundle3> props;

        public PropBundle2 Clone()
        {
            PropBundle2 pb2 = (PropBundle2)this.MemberwiseClone();
            pb2.props = new();
            foreach (PropBundle3 oldPB3 in props)
                pb2.props.Add(oldPB3.Clone());
            return pb2;
        }

        public void Deserialize(WwiseData wd)
        {
            props = new();
            propsCount = Utils.ReadUInt8(wd);
            for (int i = 0; i < propsCount; i++)
            {
                PropBundle3 pb3 = new();
                pb3.Deserialize(wd);
                props.Add(pb3);
            }
            foreach (PropBundle3 pb3 in props)
                pb3.DeserializeBoundaries(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            propsCount = (byte)props.Count;
            b.Add(propsCount);
            foreach (PropBundle3 pb3 in props)
                b.AddRange(pb3.Serialize());
            foreach (PropBundle3 pb3 in props)
                b.AddRange(pb3.SerializeBoundaries());
            return b;
        }
    }
}
