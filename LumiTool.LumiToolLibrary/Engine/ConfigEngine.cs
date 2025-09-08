using AssetsTools.NET;
using LumiTool.Data;
using LumiTool.LumiToolLibrary;
using System.Text.Json;

namespace LumiTool.Engine
{
    public class ConfigEngine
    {
        private LumiToolEngine engine;
        private JsonSerializerOptions jsonOptions;

        private List<AssetBundleCompressionType> assetBundleCompressionModes = new List<AssetBundleCompressionType>()
        {
            AssetBundleCompressionType.None,
            AssetBundleCompressionType.LZMA,
            AssetBundleCompressionType.LZ4,
        };

        private DependencyConfig dependencyConfig = null;

        public ConfigEngine(LumiToolEngine engine)
        {
            this.engine = engine;
            this.jsonOptions = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
        }

        public bool UserConfigExists()
        {
            return !LumiToolSettings.Default.FirstBoot;
        }

        public void SetFirstBootConfig()
        {
            LumiToolSettings.Default.FirstBoot = false;
            LumiToolSettings.Default.Save();
        }

        public void ReloadDependencyConfig()
        {
            if (LumiToolSettings.Default.DependencyConfigPath == string.Empty)
            {
                dependencyConfig = null;
            }
            else
            {
                var json = File.ReadAllText(LumiToolSettings.Default.DependencyConfigPath);
                dependencyConfig = JsonSerializer.Deserialize<DependencyConfig>(json, jsonOptions);
            }
        }

        public bool TryReloadDependencyConfig()
        {
            try
            {
                ReloadDependencyConfig();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public DependencyConfig GetDependencyConfig()
        {
            return dependencyConfig;
        }

        public string GetDependencyConfigPath()
        {
            return LumiToolSettings.Default.DependencyConfigPath;
        }

        public bool SetDependencyConfigPath(string newPath)
        {
            var oldPath = LumiToolSettings.Default.DependencyConfigPath;
            LumiToolSettings.Default.DependencyConfigPath = newPath;

            if (TryReloadDependencyConfig())
            {
                LumiToolSettings.Default.Save();
                return true;
            }
            else
            {
                LumiToolSettings.Default.DependencyConfigPath = oldPath;
                return false;
            }
        }

        public bool IsDependencyConfigLoaded()
        {
            return dependencyConfig != null;
        }

        public List<AssetBundleCompressionType> GetAllAssetBundleCompressionTypes()
        {
            return assetBundleCompressionModes;
        }

        public AssetBundleCompressionType GetAssetBundleCompressionType()
        {
            return (AssetBundleCompressionType)LumiToolSettings.Default.AssetBundleCompressionMode;
        }

        public void SetAssetBundleCompressionType(AssetBundleCompressionType value)
        {
            LumiToolSettings.Default.AssetBundleCompressionMode = (int)value;
            LumiToolSettings.Default.Save();
        }
    }
}
