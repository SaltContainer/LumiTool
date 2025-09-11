using System.Diagnostics;

namespace SmartPoint.AssetAssistant
{
    [Serializable]
    public class AssetBundleDownloadManifest
    {
        private const int currentVersion = 6;

        private int _version;
        private string _projectName;
        private AssetBundleRecord[] _records;
        private string[] _assetBundleNamesWithVariant;
        [NonSerialized]
        private Dictionary<string, HashSet<string>> _variantMap;
        [NonSerialized]
        private Dictionary<string, AssetBundleRecord> _recordLookupFromAssetBundleName;
        [NonSerialized]
        private Dictionary<string, AssetBundleRecord> _recordLookupFromAssetPath;
        [NonSerialized]
        private bool _dirty;
        [NonSerialized]
        private string _path;
        [NonSerialized]
        private AssetBundleDownloadManifest _latest;

        public string projectName { get => _projectName; set => _projectName = value; }
        public string path { get => _path; set => _path = value; }
        public AssetBundleDownloadManifest latest
        {
            get => _latest;
            set
            {
                _latest = value;
                MarkDifference(value);
            }
        }
        public int recordCount { get => _records.Length; }
        public AssetBundleRecord[] records { get => _records; }
        public long totalSize { get => _recordLookupFromAssetBundleName.Values.Sum(x => x.size); }
        public long installSize { get => _recordLookupFromAssetBundleName.Values.Sum(x => x.latest == null ? 0 : x.size); }
        public int installCount { get => _records.Where(x => x.latest != null).Count(); }
        public AssetBundleRecord[] installAssetBundleRecords { get => _records.Where(x => x.latest != null).ToArray(); }

        public AssetBundleDownloadManifest()
        {
            _version = currentVersion;
            _projectName = string.Empty;
            _assetBundleNamesWithVariant = Array.Empty<string>();
            _path = string.Empty;
            _records = Array.Empty<AssetBundleRecord>();
            _recordLookupFromAssetBundleName = new Dictionary<string, AssetBundleRecord>();
            _dirty = false;
        }

        public AssetBundleDownloadManifest(string projectName, string[] assetBundleNamesWithVariant, string path)
        {
            _version = currentVersion;
            _projectName = projectName;
            _assetBundleNamesWithVariant = assetBundleNamesWithVariant;
            _path = path;
            _records = Array.Empty<AssetBundleRecord>();
            _recordLookupFromAssetBundleName = new Dictionary<string, AssetBundleRecord>();
            _dirty = false;
        }

        public static AssetBundleDownloadManifest Load(byte[] data)
        {
            AssetBundleDownloadManifest manifest = null;

            using (var stream = new MemoryStream(data))
            {
                var deserialized = stream.DeserializeBinaryFormatter();

                if (deserialized != null && deserialized is AssetBundleDownloadManifest)
                    manifest = deserialized as AssetBundleDownloadManifest;
            }

            return manifest;
        }

        public static AssetBundleDownloadManifest Load(string path)
        {
            AssetBundleDownloadManifest manifest = null;
            string dirPath;

            if (File.Exists(path))
            {
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    var deserialized = stream.DeserializeBinaryFormatter();

                    if (deserialized != null && deserialized is AssetBundleDownloadManifest)
                        manifest = deserialized as AssetBundleDownloadManifest;
                }

                if (manifest._version != currentVersion)
                    manifest.Clear();

                dirPath = Path.GetDirectoryName(path) + "/";
            }

            if (manifest == null)
            {
                manifest = new AssetBundleDownloadManifest
                {
                    _dirty = true,
                    _projectName = Path.GetFileNameWithoutExtension(path),
                    _path = Path.GetDirectoryName(path) + "/"
                };
            }
            else
            {
                manifest.BuildLookupTables();
            }

            return manifest;
        }

        public string[] GetDependencies(string assetBundleName)
        {
            var record = _records.FirstOrDefault(x => x.assetBundleName == assetBundleName);
            if (record != null)
                return record.allDependencies;

            return Array.Empty<string>();
        }

        public void Save(string path, bool force = false)
        {
            if (_dirty || force)
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                    Directory.CreateDirectory(Path.GetDirectoryName(path));

                var stream = new FileStream(path, FileMode.Create, FileAccess.Write);
                stream.SerializeBinaryFormatter(this);
                if (stream != null)
                    stream.Dispose();
            }

            _dirty = false;
        }

        public void Append(string projectName, AssetBundleDownloadManifest appendManifest)
        {
            var newList = new List<AssetBundleRecord>(_records);
            for (int i = 0; i < appendManifest._records.Length; i++)
            {
                var record = appendManifest._records[i];
                var lookupRecord = GetAssetBundleRecord(record.assetBundleName);
                if (lookupRecord == null)
                {
                    lookupRecord = new AssetBundleRecord(record);
                    lookupRecord.projectName = projectName;
                    newList.Add(lookupRecord);
                    lookupRecord.latest = record;
                    _dirty = true;
                }
                else
                {
                    if (record.hash != lookupRecord.hash && record.lastWriteTime >= lookupRecord.lastWriteTime)
                    {
                        lookupRecord.projectName = projectName;
                        lookupRecord.allDependencies = record.allDependencies;
                        lookupRecord.assetPaths = record.assetPaths;
                        lookupRecord.size = record.size;
                        lookupRecord.latest = record;
                        _dirty = true;
                    }
                }
            }

            _records = newList.ToArray();
            if (_dirty)
                _assetBundleNamesWithVariant = _assetBundleNamesWithVariant.Union(appendManifest._assetBundleNamesWithVariant).ToArray();
            BuildLookupTables();
        }

        private void MarkDifference(AssetBundleDownloadManifest latestManifest)
        {
            var newList = new List<AssetBundleRecord>(_records);
            if (latestManifest != null)
            {
                for (int i = 0; i < _records.Length; i++)
                {
                    var record = _records[i];
                    var lookupRecord = GetAssetBundleRecord(record.assetBundleName);
                    if (lookupRecord == null)
                    {
                        lookupRecord = new AssetBundleRecord(record);
                        newList.Add(lookupRecord);
                        lookupRecord.latest = record;
                        _dirty = true;
                    }
                    else
                    {
                        if (record.hash != lookupRecord.hash && record.lastWriteTime >= lookupRecord.lastWriteTime)
                        {
                            lookupRecord.projectName = record.projectName;
                            lookupRecord.allDependencies = record.allDependencies;
                            lookupRecord.assetPaths = record.assetPaths;
                            lookupRecord.size = record.size;
                            lookupRecord.latest = record;
                            _dirty = true;
                        }
                    }
                }

                _records = newList.ToArray();
                if (_assetBundleNamesWithVariant != latestManifest._assetBundleNamesWithVariant)
                {
                    _assetBundleNamesWithVariant = latestManifest._assetBundleNamesWithVariant;
                    _dirty = true;
                }
            }

            BuildLookupTables();
        }

        private void BuildLookupTables()
        {
            _recordLookupFromAssetBundleName = _records.ToDictionary(x => x.assetBundleName, x => x);
            _recordLookupFromAssetPath = new Dictionary<string, AssetBundleRecord>();
            _variantMap = new Dictionary<string, HashSet<string>>();

            for (int i = 0; i < _records.Length; i++)
            {
                var record = _records[i];

                if (record.assetPaths != null)
                {
                    for (int j = 0; j < record.assetPaths.Length; j++)
                    {
                        var path = record.assetPaths[j];
                        path = path.ToLower();
                        string key = path.RemoveStart("assets/");

                        if (_recordLookupFromAssetPath.ContainsKey(key))
                            Console.WriteLine("What?" + record.assetBundleName + ":" + path);

                        _recordLookupFromAssetPath.Add(key, record);
                    }
                }
            }

            if (_assetBundleNamesWithVariant != null)
            {
                for (int i = 0; i < _assetBundleNamesWithVariant.Length; i++)
                {
                    var name = _assetBundleNamesWithVariant[i];
                    int length = name.LastIndexOf('.');
                    string filename = name.Substring(0, length);
                    string extension = name.Substring(length + 1);

                    if (!_variantMap.TryGetValue(extension, out HashSet<string> variant))
                    {
                        variant = new HashSet<string>();
                        _variantMap.Add(extension, variant);
                    }
                    variant.Add(filename);
                }
            }
        }

        public AssetBundleRecord AddRecord(string projectName, string assetBundleName)
        {
            Array.Resize(ref _records, _records.Length + 1);
            var record = new AssetBundleRecord(projectName, assetBundleName);
            _records[_records.Length - 1] = record;
            BuildLookupTables();

            return record;
        }

        public void ReplaceAllRecords(AssetBundleRecord[] newRecords)
        {
            _records = newRecords;
            _dirty = true;
            BuildLookupTables();
        }

        public void Clear()
        {
            _records = Array.Empty<AssetBundleRecord>();
            if (_records != null)
                _recordLookupFromAssetBundleName.Clear();

            if (_variantMap != null)
                _variantMap.Clear();

            _variantMap = null;
            _recordLookupFromAssetPath = null;
            _version = currentVersion;
            MarkDifference(_latest);
        }

        public bool IsExist(string assetBundleName)
        {
            return _recordLookupFromAssetBundleName.ContainsKey(assetBundleName);
        }

        public string[] GetExists(string[] assetBundleNames)
        {
            return _records.Where(x => Array.IndexOf(assetBundleNames, x.assetBundleName) != -1).Select(x => x.assetBundleName).ToArray();
        }

        public void RemoveRecords(string[] assetBundleNames)
        {
            _records = _records.Where(x => Array.IndexOf(assetBundleNames, x.assetBundleName) == -1).ToArray();
            _dirty = true;
        }

        public void RemoveRecordsWhere(Func<AssetBundleRecord, bool> predicate)
        {
            var removing = _records.Where(predicate).ToList();
            foreach (var r in removing)
            {
                Debug.WriteLine(r.projectName + " - " + r.assetBundleName);
            }
            _records = _records.Where(r => !predicate(r)).ToArray();
            _dirty = true;
        }

        public void RestrictRecords(string[] assetBundleNames)
        {
            _records = _records.Where(x => Array.IndexOf(assetBundleNames, x.assetBundleName) != -1).ToArray();
            _dirty = true;
        }

        public string[] GetAllAssetBundleNames()
        {
            return _recordLookupFromAssetBundleName.Keys.ToArray();
        }

        public string[] GetAssetBundleNamesWithVariant()
        {
            return _assetBundleNamesWithVariant;
        }

        public string FindMatchAssetBundleNameWithVariants(string assetBundleName, string[] variants)
        {
            int dotIndex = assetBundleName.IndexOf('.');
            if (dotIndex != -1)
                assetBundleName = assetBundleName.Substring(0, dotIndex);

            for (int i = 0; i < variants.Length; i++)
            {
                var variant = variants[i];
                if (_variantMap.TryGetValue(variant, out HashSet<string> set) && set.Contains(assetBundleName))
                    return assetBundleName + "." + variant;
            }

            return assetBundleName;
        }

        public string GetAssetBundleNameAtPath(string path)
        {
            if (_recordLookupFromAssetPath != null)
            {
                if (_recordLookupFromAssetPath.TryGetValue(path.ToLower().RemoveStart("assets/"), out AssetBundleRecord value))
                    return value.assetBundleName;

                return null;
            }

            return null;
        }

        public AssetBundleRecord GetAssetBundleRecord(string assetBundleName)
        {
            if (_recordLookupFromAssetBundleName.TryGetValue(assetBundleName, out AssetBundleRecord value))
                return value;

            return null;
        }

        public AssetBundleRecord[] GetAssetBundleRecordsWithDependencies(string assetBundleName)
        {
            var record = GetAssetBundleRecord(assetBundleName);
            if (record == null)
                return Array.Empty<AssetBundleRecord>();

            var deps = new List<AssetBundleRecord>();
            for (int i = 0; i < record.allDependencies.Length; i++)
            {
                var depName = record.allDependencies[i];
                deps.Add(GetAssetBundleRecord(depName));
            }

            return deps.ToArray();
        }
    }
}
