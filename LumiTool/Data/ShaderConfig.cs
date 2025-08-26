using System.Text.Json.Serialization;

namespace LumiTool.Data
{
    public class ShaderConfig
    {
        [JsonPropertyName("bundles")]
        public List<Bundle> Bundles { get; }

        [JsonIgnore]
        private Dictionary<string, Bundle> bundlesByNameDict;
        [JsonIgnore]
        private Dictionary<string, Bundle> bundlesByCABDict;

        [JsonConstructor]
        public ShaderConfig(List<Bundle> bundles)
        {
            Bundles = bundles;

            bundlesByNameDict = new Dictionary<string, Bundle>();
            foreach (var bundle in bundles)
                bundlesByNameDict.Add(bundle.BundleName, bundle);

            bundlesByCABDict = new Dictionary<string, Bundle>();
            foreach (var bundle in bundles)
                bundlesByCABDict.Add(bundle.CABName, bundle);
        }

        public List<Shader> this[string bundleCabName] => GetBundleByCABName(bundleCabName).Shaders;
        public Shader this[string bundleCabName, string shaderName] => GetBundleByCABName(bundleCabName).GetShaderByName(shaderName);

        public Bundle GetBundleByName(string bundleName)
        {
            if (bundlesByNameDict.TryGetValue(bundleName, out var bundle))
                return bundle;

            return null;
        }

        public Bundle GetBundleByCABName(string cabName)
        {
            if (bundlesByCABDict.TryGetValue(cabName, out var bundle))
                return bundle;

            return null;
        }
    }
}
