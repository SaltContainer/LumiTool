using System.Text;

namespace LumiTool.Data.Wwise
{
    public abstract class Chunk : ISerializable
    {
        public string tag;
        public uint chunkSize;

        public virtual void Deserialize(WwiseData wd)
        {
            tag = Utils.ReadString(wd, 4);
            chunkSize = Utils.ReadUInt32(wd);
        }

        public static Chunk Create(WwiseData wd)
        {
            string chunkType = Encoding.ASCII.GetString(wd.buffer, wd.offset, 4);
            Chunk bc = chunkType switch
            {
                "BKHD" => new BankHeader(),
                "DATA" => new DataChunk(),
                "DIDX" => new MediaIndex(),
                "ENVS" => new EnvSettingsChunk(),
                "HIRC" => new HircChunk(),
                "INIT" => new PluginChunk(),
                "PLAT" => new CustomPlatformChunk(),
                "STMG" => new GlobalSettingsChunk(),
                _ => throw new NotImplementedException("ChunkType " + chunkType + " at " + wd.offset),
            };
            bc.Deserialize(wd);
            return bc;
        }

        public virtual IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(tag));
            b.AddRange(Utils.GetBytes(chunkSize));
            return b;
        }
    }
}
