using LumiTool.Data;
using System.Text.Json;

namespace LumiTool.Engine
{
    public class ConfigEngine
    {
        private LumiToolEngine engine;
        private JsonSerializerOptions jsonOptions;

        private ShaderConfig shaderConfig = null;

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

            try
            {
                ReloadShaderConfig();
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Could not load the new shaders configuration! Reverting to the previous one. Full exception: {ex}", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Properties.LumiToolSettings.Default.ShaderConfigPath = oldPath;
                return false;
            }

            Properties.LumiToolSettings.Default.Save();
            return true;
        }

        public bool IsShaderConfigLoaded()
        {
            return shaderConfig != null;
        }
    }
}
