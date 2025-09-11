using System.Text.Json.Serialization;

namespace LumiTool.Data
{
    public class DependencyBundle
    {
        [JsonPropertyName("bundle_name")]
        public string BundleName { get; }
        [JsonPropertyName("cab_name")]
        public string CABName { get; }
        [JsonPropertyName("assets")]
        public List<DependencyAsset> Assets { get; }

        [JsonIgnore]
        private Dictionary<string, DependencyAsset> assetsByNameDict;

        [JsonConstructor]
        public DependencyBundle(string bundleName, string cabName, List<DependencyAsset> assets)
        {
            BundleName = bundleName;
            CABName = cabName;
            Assets = assets;

            assetsByNameDict = new Dictionary<string, DependencyAsset>();
            foreach (var asset in assets)
                assetsByNameDict.Add(asset.Name, asset);
        }

        public DependencyAsset GetAssetByName(string name)
        {
            if (assetsByNameDict.TryGetValue(name, out var asset))
                return asset;

            return null;
        }

        public override string ToString()
        {
            return $"{BundleName} ({CABName})";
        }
    }
}
