namespace LumiTool.Data.Wwise
{
    public class Plugin : ISerializable
    {
        public uint pluginID;
        public uint stringSize;
        public string dllName;

        public void Deserialize(WwiseData wd)
        {
            pluginID = Utils.ReadUInt32(wd);
            stringSize = Utils.ReadUInt32(wd);
            dllName = Utils.ReadString(wd, (int)stringSize);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(pluginID));
            b.AddRange(Utils.GetBytes(stringSize));
            b.AddRange(Utils.GetBytes(dllName));
            return b;
        }
    }
}
