namespace SmartPoint.AssetAssistant
{
    public static class SceneDatabase
    {
        private static SceneProperty[] _properties = new SceneProperty[17]
        {
            new SceneProperty("Assets/SharedAssets/Battle/DebugBattle/DebugBattleBoot.unity", "3c1885bcfd8ffaf49b3fd8065ee3301a", "debug/scenes/debug_battle_boot", false),
            new SceneProperty("Assets/SharedAssets/Games/Scenes/_Old/EvolveDemo.unity", "6eeeddc4e581def4c866652576f723be", "scenes/evolvedemo", false),
            new SceneProperty("Assets/SharedAssets/Games/Scenes/_Old/HatchDemo.unity", "aadc7fdd6e6c60a4d88976cf80aab019", "scenes/evolvedemo", false),
            new SceneProperty("Assets/SharedAssets/Games/Scenes/Battle.unity", "2ebbd94bd76e7ad4f83e1c06813c94ce", "scenes/battle", false),
            new SceneProperty("Assets/SharedAssets/Games/Scenes/Contest.unity", "599564d7a9766c04893e5b72ffd0dfd1", "scenes/contest", false),
            new SceneProperty("Assets/SharedAssets/Games/Scenes/DigFossil.unity", "43026e4dfa3203043a4fc96fad594c23", "scenes/digfossil", false),
            new SceneProperty("Assets/SharedAssets/Games/Scenes/Field.unity", "950e55600aa08d340ab1c14fb6148a7d", "scenes/field", true),
            new SceneProperty("Assets/SharedAssets/Games/Scenes/GMS.unity", "85924a1299a8def4192fa41ad6d19039", "scenes/gms", false),
            new SceneProperty("Assets/SharedAssets/Games/Scenes/Opening/Opening.unity", "db3ade2fc6527364685e1089620d8a9c", "scenes/opening", false),
            new SceneProperty("Assets/SharedAssets/Games/Scenes/SealPreview.unity", "e71b6292c91298048b945ccf230f5b34", "scenes/sealpreview", false),
            new SceneProperty("Assets/SharedAssets/Games/Scenes/Title.unity", "c1a4a957a0edca34eae02412d8802b1c", "scenes/title", false),
            new SceneProperty("Assets/SharedAssets/SubContents/Contest/Debug/DebugContestBoot.unity", "b2a7c9d6f5c20d84da5fd46950470cf6", "debug/scenes/debug_contest_boot", false),
            new SceneProperty("Assets/SharedAssets/SubContents/DigFossil/Debug/DebugDigFossilBoot.unity", "aec101312d97dc44d9d89cdc2d329a19", "debug/scenes/debug_digfossil_boot", false),
            new SceneProperty("Assets/SharedAssets/SubContents/GMS/Debug/DebugGMSBoot.unity", "86088d9b1d746fb438449cbf7fa522ec", "debug/scenes/debug_gms_boot", false),
            new SceneProperty("Assets/SharedAssets/SubContents/NetworkTest/NetworkTest.unity", "3e6efcb2d130bb64c813eae5e609564d", "debug/networktest", false),
            new SceneProperty("Assets/SharedAssets/Tools/AssetViewer/Viewer.unity", "1e824329088a294479ece6332f183a18", "assetviewer/viewer", false),
            new SceneProperty("Assets/SharedAssets/Tools/MessageViewer/MessageViewer.unity", "0e60b2c27ea875144a15ea1e0395b3d0", "scenes/messageviewer", false),
        };
        private static Dictionary<string, SceneProperty> _sceneDictionary = _properties.ToDictionary(p => p.scenePath, p => p);

        public static bool Contains(string scenePath)
        {
            return _sceneDictionary.ContainsKey(scenePath);
        }

        public static string GUIDToPath(string guid)
        {
            foreach (var scene in _sceneDictionary.Values)
            {
                if (scene.guid == guid)
                    return scene.scenePath;
            }

            return string.Empty;
        }

        public static bool IsExist(string scenePath)
        {
            return _sceneDictionary.ContainsKey(scenePath);
        }

        public static SceneProperty GetProperty(string scenePath)
        {
            if (_sceneDictionary.TryGetValue(scenePath, out SceneProperty sceneProperty))
                return sceneProperty;

            return null;
        }

        public static string GetAssetBundleName(string scenePath)
        {
            if (_sceneDictionary.TryGetValue(scenePath, out SceneProperty sceneProperty))
                return string.IsNullOrEmpty(sceneProperty.assetBundleName) ? string.Empty : sceneProperty.assetBundleName;

            return string.Empty;
        }

        public static void AddProperty(string path)
        {
            if (_sceneDictionary.ContainsKey(path))
                return;

            _sceneDictionary.Add(path, new SceneProperty(path));
        }

        public static Dictionary<string, SceneProperty> GetAllSceneProperty()
        {
            return _sceneDictionary;
        }

        [Serializable]
        public class SceneProperty
        {
            private string _scenePath;
            private string _guid;
            private string _assetBundleName;
            private bool _dontDiscard;
            private bool _leaveHistory;
            private string[] _includes;

            public string scenePath { get => _scenePath; }
            public string guid { get => _guid; }
            public string assetBundleName { get => _assetBundleName; }
            public bool dontDiscard { get => _dontDiscard; }
            public bool leaveHistroy { get => _leaveHistory; }
            public string[] includes { get => _includes; }

            public SceneProperty(string path)
            {
                _scenePath = path;
                _guid = string.Empty;
                _assetBundleName = string.Empty;
                _leaveHistory = true;
                _includes = Array.Empty<string>();
            }

            public SceneProperty(string path, string guid, string assetBundleName, bool dontDiscard)
            {
                _scenePath = path;
                _guid = guid;
                _assetBundleName = assetBundleName;
                _dontDiscard = dontDiscard;
                _leaveHistory = true;
                _includes = Array.Empty<string>();
            }
        }
    }
}
