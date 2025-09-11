namespace LumiTool.Data.Wwise
{
    public class PauseActionSpecificParams : ISerializable
    {
        public bool includePendingResume;
        public bool applyToStateTransitions;
        public bool applyToDynamicSequence;

        public void Deserialize(WwiseData wd)
        {
            bool[] flags = Utils.ReadFlags(wd);
            includePendingResume = flags[0];
            applyToStateTransitions = flags[1];
            applyToDynamicSequence = flags[2];
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            bool[] flags = {
                    includePendingResume,
                    applyToStateTransitions,
                    applyToDynamicSequence
                };
            b.Add(Utils.GetByte(flags));
            return b;
        }
    }
}
