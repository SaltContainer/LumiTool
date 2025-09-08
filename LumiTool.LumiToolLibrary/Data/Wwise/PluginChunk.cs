namespace LumiTool.Data.Wwise
{
    public class PluginChunk : Chunk
    {
        public uint count;
        public List<Plugin> pluginList;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            pluginList = new();
            count = Utils.ReadUInt32(wd);
            for (int i = 0; i < count; i++)
            {
                Plugin p = new();
                p.Deserialize(wd);
                pluginList.Add(p);
            }
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            count = (uint)pluginList.Count;
            b0.AddRange(Utils.GetBytes(count));
            foreach (Plugin p in pluginList)
                b0.AddRange(p.Serialize());
            chunkSize = (uint)b0.Count;

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
