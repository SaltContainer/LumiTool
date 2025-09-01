using AssetsTools.NET.Extra;
using System.Text.Json.Serialization;

namespace LumiTool.Data
{
    public class DependencyAsset
    {
        [JsonPropertyName("name")]
        public string Name { get; }
        [JsonPropertyName("type")]
        public AssetClassID Type { get; }
        [JsonPropertyName("path_id")]
        public long PathID { get; }

        [JsonConstructor]
        public DependencyAsset(string name, AssetClassID type, long pathID)
        {
            Name = name;
            Type = type;
            PathID = pathID;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
