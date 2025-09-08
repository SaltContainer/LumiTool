namespace LumiTool.Data.Wwise
{
    public class StopActionSpecificParams : ISerializable
    {
        public bool applyToStateTransitions;
        public bool applyToDynamicSequence;

        public void Deserialize(WwiseData wd)
        {
            bool[] flags = Utils.ReadFlags(wd);
            applyToStateTransitions = flags[1];
            applyToDynamicSequence = flags[2];
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            bool[] flags = { false,
                        applyToStateTransitions,
                        applyToDynamicSequence
                };
            b.Add(Utils.GetByte(flags));
            return b;
        }
    }
}
