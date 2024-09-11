using AssetsTools.NET;
using AssetsTools.NET.Extra;
using LumiTool.Data;
using SmartPoint.AssetAssistant;

namespace LumiTool.Engine
{
    public class LumiToolEngine
    {
        private BundleEngine bundleEngine;
        private ManifestEngine manifestEngine;
        private FileSystemEngine fileSystemEngine;

        public static readonly List<Shader> ShaderList = new List<Shader>()
        {
            new Shader("Custom/AfterImage", -4970256172671831970),
            new Shader("Custom/Bloom Finalize", 53842323778609191),
            new Shader("Custom/Bloom Setup", 8035550817748785116),
            new Shader("Custom/CaptureFocus", -5466533002143108898),
            new Shader("Custom/Contest/ColorAdditve", -2842559807349284410),
            new Shader("Custom/DepthOfField", -7464453924571447068),
            new Shader("Custom/Downsample2x2Focus", -2205641664787468429),
            new Shader("Custom/EffectCopyTexture", -3777356945394623797),
            new Shader("Custom/ExpandFocus", 7915733658093096756),
            new Shader("Custom/Fxaa", -1391858814557534617),
            new Shader("Custom/Gaussian7x7", 4236319583406469960),
            new Shader("Custom/ProceduralPlane/Footprint", -5646477618197714314),
            new Shader("Custom/ProceduralPlane/FrameFade", -6972357076304326454),
            new Shader("Custom/ResolveFocus", 168003426929850598),
            new Shader("Custom/StencilMask", 8170728072275071070),
            new Shader("Custom/WaterInteration/DynamicNormalMap", -1169972748190587529),
            new Shader("Custom/WaterInteration/WaterSimulation", -6802883449932581483),

            new Shader("Delphis/Battle/Encount01", 1564348391444287570),
            new Shader("Delphis/Battle/Encount02", -8291963777014188288),
            new Shader("Delphis/Character/DepthOnly", 3418051442139860500),
            new Shader("Delphis/Character/Standard", 6563995300646652156),
            new Shader("Delphis/Dig/DigColorGain", 6261636413239207142),
            new Shader("Delphis/Map/Additive", -8142274094207094620),
            new Shader("Delphis/Map/Blend", 227267204978926967),
            new Shader("Delphis/Map/FlowMap", 3540238303807400238),
            new Shader("Delphis/Map/FlowmapBumpWater", 160191684220584772),
            new Shader("Delphis/Map/FlowmapWater", -1229414707475946922),
            new Shader("Delphis/Map/Fog", 1711601622408796059),
            new Shader("Delphis/Map/LineUVScroll", -6341295909368841153),
            new Shader("Delphis/Map/Mask", 9140095141265939992),
            new Shader("Delphis/Map/PhotoFrame", 3325521180629300053),
            new Shader("Delphis/Map/Sky", -4669996567639855370),
            new Shader("Delphis/Map/Standard", -4213824261075451297),
            new Shader("Delphis/Map/Water", 6224322154787984484),
            new Shader("Delphis/Map/Wave", -2088498294480579029),
            new Shader("Delphis/Poffin", 6993189180789558362),
            new Shader("Delphis/Snowfield/Snowfield", -8767734290174472441),
            new Shader("Delphis/UI/FrostedGlass", 2637188512777540748),
            new Shader("Delphis/WaterSimulation/WaterSurface", 4321107867503748431),

            new Shader("Dpr/Objects/ShadowCast", 6476002754864908655),
            new Shader("Dpr/PostEffect/BtlvPfxShader", -3583825286010479546),
            new Shader("Dpr/PostEffect/ChromaticAberration", 6157991620160446954),
            new Shader("Dpr/PostEffect/ColorFiler", 3190842003931510964),
            new Shader("Dpr/PostEffect/FeedbackBlur", 3021052186492057238),
            new Shader("Dpr/PostEffect/RadualBlur", -1636536088489789794),

            new Shader("Mitake/FireCore1st", -5562877344249246907),
            new Shader("Mitake/FireMask1st", -4687111639529973708),
            new Shader("Mitake/MitakeDepthOnlyShader", -347540048557242273),
            new Shader("Mitake/MitakeGroundEffectShader1st", 5943162064127105437),
            new Shader("Mitake/MitakeStandardBumpShader", -4845677725423271419),
            new Shader("Mitake/MitakeStandardPetrify", -518736460639948329),
            new Shader("Mitake/MitakeStandardPetrifyFire", 2693070194924545345),
            new Shader("Mitake/MitakeStandardShader1st", 3392663556170153613),
            new Shader("Mitake/SmokeMask_MT", -389467399638713532),

            new Shader("MovieTexture", -6543584180457251334),

            new Shader("TextMeshPro/Distance Field", 3039605131867672570),
            new Shader("TextMeshPro/Mobile/Distance Field", -9155214179205432183),

            new Shader("UI/Blur", 7941833886796439821),
            new Shader("UI/Custom", -7612284448310537654),
            new Shader("UI/UI-Gray", -7432224456793065039),
            new Shader("UI/UI-Multiply", 8358741793606657134),
            new Shader("UI/UI-SolidColor", -5974943227850357013),
            new Shader("UI/UI-SoundWave", -2131554227428552704),
        };

        public LumiToolEngine()
        {
            bundleEngine = new BundleEngine(this);
            manifestEngine = new ManifestEngine(this);
            fileSystemEngine = new FileSystemEngine(this);
        }

        public void UnloadBundles()
        {
            bundleEngine.UnloadBundles();
        }

        public BundleFileInstance LoadBundle(string path, BundleEngine.ManagerID managerID)
        {
            return bundleEngine.LoadBundleFile(path, managerID);
        }

        public AssetsFileInstance LoadAssetsFileFromBundle(BundleFileInstance bundle, BundleEngine.ManagerID managerID)
        {
            return bundleEngine.LoadAssetsFileFromBundle(bundle, managerID);
        }

        public void SetPlatformOfBundle(BundleFileInstance bundle, AssetsFileInstance assetsFile, Platform platform)
        {
            bundleEngine.SetPlatformOfBundle(bundle, assetsFile, platform);
        }

        public void SaveBundleToFile(BundleFileInstance bundle, string path)
        {
            bundleEngine.SaveBundleToFile(bundle, path);
        }

        public ClassDatabaseFile LoadClassPackage(AssetsFileInstance assetsFile, BundleEngine.ManagerID managerID)
        {
            return bundleEngine.LoadClassPackage(assetsFile, managerID);
        }

        public bool AddMonoScript(BundleFileInstance bundle, AssetsFileInstance assetsFile, string assembly, string namezpace, string klass, BundleEngine.ManagerID managerID)
        {
            return bundleEngine.AddMonoScript(bundle, assetsFile, assembly, namezpace, klass, managerID);
        }

        public void CopyDependencies(AssetsFileInstance to, AssetsFileInstance from)
        {
            bundleEngine.CopyDependencies(to, from);
        }

        public void FixShadersOfMaterials(BundleFileInstance bundle, AssetsFileInstance assetsFile, bool showBundleNameInPopup = false)
        {
            bundleEngine.FixShadersOfMaterials(bundle, assetsFile, showBundleNameInPopup);
        }

        public void FixShadersOfMaterials(BundleFileInstance bundle, AssetsFileInstance assetsFile, bool showBundleNameInPopup, Dictionary<long, Shader> foundShaders)
        {
            bundleEngine.FixShadersOfMaterials(bundle, assetsFile, showBundleNameInPopup, foundShaders);
        }

        public void AddDependency(AssetsFileInstance assetsFile, string path)
        {
            bundleEngine.AddDependency(assetsFile, path);
        }

        public void CopyMaterial(AssetFileInfo toMat, AssetTypeValueField fromMatBase)
        {
            bundleEngine.CopyMaterial(toMat, fromMatBase);
        }

        public AssetBundleDownloadManifest LoadManifest(string path)
        {
            return manifestEngine.LoadManifest(path);
        }

        public void SaveManifest(AssetBundleDownloadManifest manifest, string path)
        {
            manifestEngine.SaveManifest(manifest, path);
        }

        public void RefreshManifest(AssetBundleDownloadManifest manifest, string romfsPath, string romfsVPath)
        {
            manifestEngine.RefreshManifest(manifest, romfsPath, romfsVPath);
        }

        public string? FindAssetAssistantPath(string path)
        {
            return fileSystemEngine.FindAssetAssistantPath(path);
        }

        public bool ChangeShadersBundlePathIDs(BundleFileInstance toBundle, AssetsFileInstance toAssetsFile, BundleFileInstance fromBundle, AssetsFileInstance fromAssetsFile)
        {
            return bundleEngine.ChangeShadersBundlePathIDs(toBundle, toAssetsFile, fromBundle, fromAssetsFile);
        }

        public long? GetFileSizeAtPath(string path)
        {
            return fileSystemEngine.GetFileSizeAtPath(path);
        }

        public void RenameBundle(BundleFileInstance bundle, AssetsFileInstance assetsFile, string newName, string newCAB)
        {
            bundleEngine.RenameBundle(bundle, assetsFile, newName, newCAB);
        }
    }
}
