using System.Text.Json.Serialization;

namespace LumiTool.Data
{
    public class DependencyConfig
    {
        [JsonPropertyName("bundles")]
        public List<DependencyBundle> Bundles { get; }

        [JsonIgnore]
        private Dictionary<string, DependencyBundle> bundlesByNameDict;
        [JsonIgnore]
        private Dictionary<string, DependencyBundle> bundlesByCABDict;

        [JsonConstructor]
        public DependencyConfig(List<DependencyBundle> bundles)
        {
            Bundles = bundles;

            bundlesByNameDict = new Dictionary<string, DependencyBundle>();
            foreach (var bundle in bundles)
                bundlesByNameDict.Add(bundle.BundleName, bundle);

            bundlesByCABDict = new Dictionary<string, DependencyBundle>();
            foreach (var bundle in bundles)
                bundlesByCABDict.Add(bundle.CABName, bundle);
        }

        public List<DependencyAsset> this[string bundleCabName] => GetBundleByCABName(bundleCabName)?.Assets;
        public DependencyAsset this[string bundleCabName, string assetName] => GetBundleByCABName(bundleCabName)?.GetAssetByName(assetName);

        public DependencyBundle GetBundleByName(string bundleName)
        {
            if (bundlesByNameDict.TryGetValue(bundleName, out var bundle))
                return bundle;

            return null;
        }

        public DependencyBundle GetBundleByCABName(string cabName)
        {
            if (bundlesByCABDict.TryGetValue(cabName, out var bundle))
                return bundle;

            return null;
        }
    }
}
