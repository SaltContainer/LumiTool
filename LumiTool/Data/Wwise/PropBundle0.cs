namespace LumiTool.Data.Wwise
{
    public class PropBundle0 : ISerializable
    {
        public byte propsCount;
        public List<PropBundle1> props;

        public PropBundle0 Clone()
        {
            PropBundle0 pb0 = (PropBundle0)this.MemberwiseClone();
            pb0.props = new();
            foreach (PropBundle1 oldPB1 in props)
                pb0.props.Add(oldPB1.Clone());
            return pb0;
        }

        public void Deserialize(WwiseData wd)
        {
            props = new();
            propsCount = Utils.ReadUInt8(wd);
            for (int i = 0; i < propsCount; i++)
            {
                PropBundle1 pb1 = new();
                pb1.Deserialize(wd);
                props.Add(pb1);
            }
            foreach (PropBundle1 pb1 in props)
                pb1.DeserializeValue(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            propsCount = (byte)props.Count;
            b.Add(propsCount);
            foreach (PropBundle1 pb1 in props)
                b.AddRange(pb1.Serialize());
            foreach (PropBundle1 pb1 in props)
                b.AddRange(pb1.SerializeValue());
            return b;
        }
    }
}
