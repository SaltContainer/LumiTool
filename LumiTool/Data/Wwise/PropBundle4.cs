namespace LumiTool.Data.Wwise
{
    public class PropBundle4 : ISerializable
    {
        public ushort propsCount;
        public List<PropBundle5> props;

        public void Deserialize(WwiseData wd)
        {
            props = new();
            propsCount = Utils.ReadUInt16(wd);
            for (int i = 0; i < propsCount; i++)
            {
                PropBundle5 pb1 = new();
                pb1.Deserialize(wd);
                props.Add(pb1);
            }
            foreach (PropBundle5 pb1 in props)
                pb1.DeserializeValue(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            propsCount = (byte)props.Count;
            b.AddRange(Utils.GetBytes(propsCount));
            foreach (PropBundle5 pb1 in props)
                b.AddRange(pb1.Serialize());
            foreach (PropBundle5 pb1 in props)
                b.AddRange(pb1.SerializeValue());
            return b;
        }
    }
}
