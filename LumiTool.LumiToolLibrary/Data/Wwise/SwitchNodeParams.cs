namespace LumiTool.Data.Wwise
{
    public class SwitchNodeParams : ISerializable
    {
        public uint nodeID;
        public bool isFirstOnly;
        public bool continuePlayback;
        public byte onSwitchMode;
        public int fadeOutTime;
        public int fadeInTime;

        public void Deserialize(WwiseData wd)
        {
            nodeID = Utils.ReadUInt32(wd);
            bool[] flags = Utils.ReadFlags(wd);
            isFirstOnly = flags[0];
            continuePlayback = flags[1];
            onSwitchMode = Utils.ReadUInt8(wd);
            fadeOutTime = Utils.ReadInt32(wd);
            fadeInTime = Utils.ReadInt32(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(nodeID));
            bool[] flags = {
                    isFirstOnly,
                    continuePlayback
                };
            b.Add(Utils.GetByte(flags));
            b.Add(onSwitchMode);
            b.AddRange(Utils.GetBytes(fadeOutTime));
            b.AddRange(Utils.GetBytes(fadeInTime));
            return b;
        }
    }
}
