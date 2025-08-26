using System.Text.Json.Serialization;

namespace LumiTool.Data
{
    public class Bundle
    {
        [JsonPropertyName("bundle_name")]
        public string BundleName { get; }
        [JsonPropertyName("cab_name")]
        public string CABName { get; }
        [JsonPropertyName("shaders")]
        public List<Shader> Shaders { get; }

        [JsonIgnore]
        private Dictionary<string, Shader> shadersByNameDict;

        [JsonConstructor]
        public Bundle(string bundleName, string cabName, List<Shader> shaders)
        {
            BundleName = bundleName;
            CABName = cabName;
            Shaders = shaders;

            shadersByNameDict = new Dictionary<string, Shader>();
            foreach (var shader in shaders)
                shadersByNameDict.Add(shader.Name, shader);
        }

        public Shader GetShaderByName(string name)
        {
            if (shadersByNameDict.TryGetValue(name, out var shader))
                return shader;

            return null;
        }

        public override string ToString()
        {
            return BundleName;
        }
    }
}
