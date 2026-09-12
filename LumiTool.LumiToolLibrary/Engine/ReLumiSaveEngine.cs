using LumiTool.Data;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace LumiTool.Engine
{
    public class ReLumiSaveEngine
    {
        private LumiToolEngine engine;

        public ReLumiSaveEngine(LumiToolEngine engine)
        {
            this.engine = engine;
        }

        public JsonNode LoadJsonReLumiSaveFile(string path)
        {
            return JsonSerializer.Deserialize<JsonNode>(File.ReadAllText(path));
        }

        public void MigrateReLumiSaveFile(JsonNode saveFile, ReLumiSaveVersion version)
        {
            if (version == ReLumiSaveVersion.DEV_1)
            {
                MigrateToDEV1(saveFile);
                version = ReLumiSaveVersion.DEV_2;
            }

            if (version == ReLumiSaveVersion.DEV_2)
            {
                MigrateToDEV2(saveFile);
                version = ReLumiSaveVersion.DEV_3;
            }

            if (version == ReLumiSaveVersion.DEV_3)
            {
                MigrateToDEV3(saveFile);
                version = ReLumiSaveVersion.RE_LEASE;
            }

            if (version == ReLumiSaveVersion.RE_LEASE)
            {
                MigrateToReLease(saveFile);
                version = ReLumiSaveVersion.FUTURE;
            }

            if (version == ReLumiSaveVersion.FUTURE)
            {
                MigrateToFuture(saveFile);
                version = ReLumiSaveVersion.PRESENT;
            }
        }

        public void SaveReLumiSaveToFile(string path, JsonNode saveFile)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(saveFile));
        }

        private void MigrateToDEV1(JsonNode saveFile)
        {
            saveFile["lumi"]["settings"]["bikingMusicEnabled"] = true;
            saveFile["lumi"]["settings"]["surfingMusicEnabled"] = true;
        }

        private void MigrateToDEV2(JsonNode saveFile)
        {

        }

        private void MigrateToDEV3(JsonNode saveFile)
        {

        }

        private void MigrateToReLease(JsonNode saveFile)
        {

        }

        private void MigrateToFuture(JsonNode saveFile)
        {

        }
    }
}
