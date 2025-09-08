using AssetsTools.NET;
using LumiTool.Data;
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
            return !Properties.LumiToolSettings.Default.FirstBoot;
        }

        public void SetFirstBootConfig()
        {
            Properties.LumiToolSettings.Default.FirstBoot = false;
            Properties.LumiToolSettings.Default.Save();
        }

        public void ReloadDependencyConfig()
        {
            if (Properties.LumiToolSettings.Default.DependencyConfigPath == string.Empty)
            {
                dependencyConfig = null;
            }
            else
            {
                var json = File.ReadAllText(Properties.LumiToolSettings.Default.DependencyConfigPath);
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
            return Properties.LumiToolSettings.Default.DependencyConfigPath;
        }

        public bool SetDependencyConfigPath(string newPath)
        {
            var oldPath = Properties.LumiToolSettings.Default.DependencyConfigPath;
            Properties.LumiToolSettings.Default.DependencyConfigPath = newPath;

            if (TryReloadDependencyConfig())
            {
                Properties.LumiToolSettings.Default.Save();
                return true;
            }
            else
            {
                Properties.LumiToolSettings.Default.DependencyConfigPath = oldPath;
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
            return (AssetBundleCompressionType)Properties.LumiToolSettings.Default.AssetBundleCompressionMode;
        }

        public void SetAssetBundleCompressionType(AssetBundleCompressionType value)
        {
            Properties.LumiToolSettings.Default.AssetBundleCompressionMode = (int)value;
            Properties.LumiToolSettings.Default.Save();
        }
    }
}
