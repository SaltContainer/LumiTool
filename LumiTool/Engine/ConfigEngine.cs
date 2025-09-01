using LumiTool.Data;
using System.Text.Json;

namespace LumiTool.Engine
{
    public class ConfigEngine
    {
        private LumiToolEngine engine;
        private JsonSerializerOptions jsonOptions;

        private ShaderConfig shaderConfig = null;
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

        public void ReloadShaderConfig()
        {
            var json = File.ReadAllText(Properties.LumiToolSettings.Default.ShaderConfigPath);
            shaderConfig = JsonSerializer.Deserialize<ShaderConfig>(json, jsonOptions);
        }

        public bool TryReloadShaderConfig()
        {
            try
            {
                ReloadShaderConfig();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public ShaderConfig GetShaderConfig()
        {
            return shaderConfig;
        }

        public string GetShaderConfigPath()
        {
            return Properties.LumiToolSettings.Default.ShaderConfigPath;
        }

        public bool SetShaderConfigPath(string newPath)
        {
            var oldPath = Properties.LumiToolSettings.Default.ShaderConfigPath;
            Properties.LumiToolSettings.Default.ShaderConfigPath = newPath;

            if (TryReloadShaderConfig())
            {
                Properties.LumiToolSettings.Default.Save();
                return true;
            }
            else
            {
                Properties.LumiToolSettings.Default.ShaderConfigPath = oldPath;
                return false;
            }
        }

        public bool IsShaderConfigLoaded()
        {
            return shaderConfig != null;
        }

        public void ReloadDependencyConfig()
        {
            var json = File.ReadAllText(Properties.LumiToolSettings.Default.DependencyConfigPath);
            dependencyConfig = JsonSerializer.Deserialize<DependencyConfig>(json, jsonOptions);
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
    }
}
