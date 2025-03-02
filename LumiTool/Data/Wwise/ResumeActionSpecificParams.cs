namespace LumiTool.Data.Wwise
{
    public class ResumeActionSpecificParams : ISerializable
    {
        public bool isMasterResume;
        public bool applyToStateTransitions;
        public bool applyToDynamicSequence;

        public void Deserialize(WwiseData wd)
        {
            bool[] flags = Utils.ReadFlags(wd);
            isMasterResume = flags[0];
            applyToStateTransitions = flags[1];
            applyToDynamicSequence = flags[2];
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            bool[] flags = {
                    isMasterResume,
                    applyToStateTransitions,
                    applyToDynamicSequence
                };
            b.Add(Utils.GetByte(flags));
            return b;
        }
    }
}
