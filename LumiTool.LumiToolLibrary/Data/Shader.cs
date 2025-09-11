using System.Text.Json.Serialization;

namespace LumiTool.Data
{
    public class Shader
    {
        [JsonPropertyName("name")]
        public string Name { get; }
        [JsonPropertyName("path_id")]
        public long PathID { get; }

        [JsonConstructor]
        public Shader(string name, long pathID)
        {
            Name = name;
            PathID = pathID;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
