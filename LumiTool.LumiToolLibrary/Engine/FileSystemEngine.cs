namespace LumiTool.Engine
{
    public class FileSystemEngine
    {
        private LumiToolEngine engine;

        public FileSystemEngine(LumiToolEngine engine)
        {
            this.engine = engine;
        }

        private readonly List<(string dir, bool optional)> pathSegments = new List<(string, bool)>()
        {
            ("Data", true), ("StreamingAssets", false), ("AssetAssistant", false)
        };

        public long? GetFileSizeAtPath(string path)
        {
            if (File.Exists(path))
                return new FileInfo(path).Length;
            else
                return null;
        }

        public string? FindAssetAssistantPath(string path)
        {
            for (int i=pathSegments.Count-1; i>=0; i--)
            {
                if (GetLastDirectoryName(path) == pathSegments[i].dir)
                    return AddPathSegments(i+1, path);
            }

            return AddPathSegments(0, path);
        }

        public bool DoesFileExist(string path)
        {
            return File.Exists(path);
        }

        public void WriteLinesToFile(string path, List<string> lines)
        {
            using var fs = new FileStream(path, FileMode.Create);
            using var sw = new StreamWriter(fs);
            foreach (var line in lines)
                sw.WriteLine(line);
        }

        public void WriteTextToFile(string path, string text)
        {
            using var fs = new FileStream(path, FileMode.Create);
            using var sw = new StreamWriter(fs);
            sw.Write(text);
        }

        private string? AddPathSegments(int startIndex, string path)
        {
            for (int i=startIndex; i<pathSegments.Count; i++)
            {
                string tempPath = Path.Combine(path, pathSegments[i].dir);
                if (!Directory.Exists(tempPath) && !pathSegments[i].optional)
                    return null;

                if (Directory.Exists(tempPath))
                    path = tempPath;
            }

            return path;
        }

        private string GetLastDirectoryName(string path)
        {
            return path.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
        }
    }
}
