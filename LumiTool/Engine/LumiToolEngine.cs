using AssetsTools.NET;
using AssetsTools.NET.Extra;
using LumiTool.Data;
using LumiTool.Forms;
using LumiTool.Forms.Popups;
using System.Windows.Forms;

namespace LumiTool.Engine
{
    public class LumiToolEngine
    {
        private AssetsManager manager;
        private AssetsManager managerV;
        private TemplateFieldToTypeTree typeTreeConverter;

        private Dictionary<long, Shader> foundShaders = new Dictionary<long, Shader>();

        public readonly List<Shader> ShaderList = new List<Shader>()
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
            manager = new AssetsManager();
            managerV = new AssetsManager();
            typeTreeConverter = new TemplateFieldToTypeTree();
        }

        public void UnloadBundles()
        {
            manager.UnloadAll();
            managerV.UnloadAll();
        }

        public BundleFileInstance LoadBundle(string path)
        {
            return manager.LoadBundleFile(path, true);
        }

        public BundleFileInstance LoadBundleV(string path)
        {
            return managerV.LoadBundleFile(path, true);
        }

        public AssetsFileInstance LoadAssetsFileFromBundle(BundleFileInstance bundle)
        {
            return manager.LoadAssetsFileFromBundle(bundle, 0, false);
        }

        public AssetsFileInstance LoadAssetsFileFromBundleV(BundleFileInstance bundle)
        {
            return managerV.LoadAssetsFileFromBundle(bundle, 0, false);
        }

        public void SetAssetsFileInBundle(BundleFileInstance bundle, AssetsFileInstance assetsFile)
        {
            bundle.file.BlockAndDirInfo.DirectoryInfos[0].SetNewData(assetsFile.file);
        }

        public void SetPlatformOfBundle(BundleFileInstance bundle, AssetsFileInstance assetsFile, Platform platform)
        {
            assetsFile.file.Metadata.TargetPlatform = Convert.ToUInt32(platform);
            SetAssetsFileInBundle(bundle, assetsFile);
        }

        public void SaveBundleToFile(BundleFileInstance bundle, string path)
        {
            using (AssetsFileWriter writer = new AssetsFileWriter(path))
            {
                bundle.file.Write(writer);
            }
        }

        public bool AddMonoScript(BundleFileInstance bundle, AssetsFileInstance assetsFile, string assembly, string namezpace, string klass)
        {
            AssetsFile file = assetsFile.file;

            manager.LoadClassPackage("classdata.tpk");
            var cldb = manager.LoadClassDatabaseFromPackage(file.Metadata.UnityVersion);

            Random rand = new Random();
            var monoScriptPathId = rand.NextInt64();

            var monoScriptClassId = (int)AssetClassID.MonoScript;
            var monoScriptInfo = AssetFileInfo.Create(file, monoScriptPathId, monoScriptClassId, cldb);
            file.Metadata.AssetInfos.Add(monoScriptInfo);

            var monoScriptTemp = manager.GetTemplateBaseField(assetsFile, monoScriptInfo);
            var monoScriptBf = ValueBuilder.DefaultValueFieldFromTemplate(monoScriptTemp);
            monoScriptBf["m_Name"].AsString = klass;
            monoScriptBf["m_ClassName"].AsString = klass;
            monoScriptBf["m_Namespace"].AsString = namezpace;
            monoScriptBf["m_AssemblyName"].AsString = assembly;

            monoScriptInfo.SetNewData(monoScriptBf);

            var newScriptId = file.Metadata.ScriptTypes.Count;

            file.Metadata.ScriptTypes.Add(new AssetPPtr(0, monoScriptPathId));

            var monoBehaviourClassId = (int)AssetClassID.MonoBehaviour;
            var monoBehaviourTemp = manager.GetTemplateBaseField(assetsFile, null, 0, monoBehaviourClassId, (ushort)newScriptId, AssetReadFlags.SkipMonoBehaviourFields);

            manager.MonoTempGenerator = new MonoCecilTempGenerator("Managed");
            var newBaseField = manager.MonoTempGenerator.GetTemplateField(monoBehaviourTemp, assembly, namezpace, klass, new UnityVersion(file.Metadata.UnityVersion));

            if (newBaseField != null)
            {
                var newTypeTreeItem = ConvertTemplateFieldToTypeTree(cldb, newBaseField, monoBehaviourClassId, (ushort)newScriptId);

                file.Metadata.TypeTreeTypes.Add(newTypeTreeItem);

                var fileOutStream = new MemoryStream();
                var fileOutWriter = new AssetsFileWriter(fileOutStream);
                file.Write(fileOutWriter);
                bundle.file.BlockAndDirInfo.DirectoryInfos[0].Replacer = new ContentReplacerFromBuffer(fileOutStream.ToArray());

                return true;
            }
            else
            {
                return false;
            }
        }

        public void CopyMaterials(AssetsFileInstance to, AssetsFileInstance from)
        {
            var toMats = to.file.GetAssetsOfType(AssetClassID.Material);
            var fromMats = from.file.GetAssetsOfType(AssetClassID.Material);
            foreach (var fromMat in fromMats)
            {
                var fromMatBase = managerV.GetBaseField(from, fromMat);
                var toMat = toMats.Find(m => manager.GetBaseField(to, m)["m_Name"].AsString == fromMatBase["m_Name"].AsString);
                if (toMat != null)
                {
                    var toMatBase = manager.GetBaseField(to, toMat);
                    CopyMaterial(toMat, fromMatBase);
                }
            }

            SetAssetsFileInBundle(to.parentBundle, to);
        }

        public void CopyDependencies(AssetsFileInstance to, AssetsFileInstance from)
        {
            ClearDependencies(to);
            foreach (var dep in from.file.Metadata.Externals)
                to.file.Metadata.Externals.Add(dep);

            SetAssetsFileInBundle(to.parentBundle, to);
        }

        public void RepointTexturesOfMaterials(AssetsFileInstance to, AssetsFileInstance from)
        {
            var toMats = to.file.GetAssetsOfType(AssetClassID.Material);
            var fromMats = from.file.GetAssetsOfType(AssetClassID.Material);
            var toTexs = to.file.GetAssetsOfType(AssetClassID.Texture2D);

            foreach (var fromMat in fromMats)
            {
                var fromMatBase = managerV.GetBaseField(from, fromMat);
                var toMat = toMats.Find(m => manager.GetBaseField(to, m)["m_Name"].AsString == fromMatBase["m_Name"].AsString);
                if (toMat != null)
                {
                    var toMatBase = manager.GetBaseField(to, toMat);
                    var toTexsOfMat = toMatBase["m_SavedProperties"]["m_TexEnvs"]["Array"];

                    foreach (var toTexOfMat in toTexsOfMat)
                    {
                        long original = toTexOfMat["second"]["m_Texture"]["m_PathID"].AsLong;
                        if (original == 0)
                            continue;

                        var fromTex = managerV.GetBaseField(from, original);

                        var toTex = toTexs.Find(t => manager.GetBaseField(to, t)["m_Name"].AsString == fromTex["m_Name"].AsString);
                        if (toTex != null)
                            toTexOfMat["second"]["m_Texture"]["m_PathID"].AsLong = toTex.PathId;
                    }

                    toMat.SetNewData(toMatBase);
                }
            }

            SetAssetsFileInBundle(to.parentBundle, to);
        }

        public bool RegenerateMonoTypeTree(BundleFileInstance bundle, AssetsFileInstance assetsFile)
        {
            var file = assetsFile.file;

            manager.LoadClassPackage("classdata.tpk");
            var cldb = manager.LoadClassDatabaseFromPackage(file.Metadata.UnityVersion);

            manager.MonoTempGenerator = new MonoCecilTempGenerator("Managed");

            for (int i=0; i<file.Metadata.ScriptTypes.Count; i++)
            {
                var monoBehaviourClassId = (int)AssetClassID.MonoBehaviour;
                var monoBehaviourTemp = manager.GetTemplateBaseField(assetsFile, null, 0, monoBehaviourClassId, (ushort)i, AssetReadFlags.SkipMonoBehaviourFields);

                var scriptBase = manager.GetBaseField(assetsFile, file.Metadata.ScriptTypes[i].PathId);

                string assembly = scriptBase["m_AssemblyName"].AsString;
                string namezpace = scriptBase["m_Namespace"].AsString;
                string klass = scriptBase["m_ClassName"].AsString;

                var newBaseField = manager.MonoTempGenerator.GetTemplateField(monoBehaviourTemp, assembly, namezpace, klass, new UnityVersion(file.Metadata.UnityVersion));

                if (newBaseField == null)
                    return false;

                var newTypeTreeItem = ConvertTemplateFieldToTypeTree(cldb, newBaseField, monoBehaviourClassId, (ushort)i);

                int typeTreeIndex = file.Metadata.TypeTreeTypes.FindIndex(t => t.ScriptTypeIndex == i);
                file.Metadata.TypeTreeTypes[typeTreeIndex] = newTypeTreeItem;
            }

            var fileOutStream = new MemoryStream();
            var fileOutWriter = new AssetsFileWriter(fileOutStream);
            file.Write(fileOutWriter);
            bundle.file.BlockAndDirInfo.DirectoryInfos[0].Replacer = new ContentReplacerFromBuffer(fileOutStream.ToArray());

            return true;
        }

        public void FixShadersOfMaterials(BundleFileInstance bundle, AssetsFileInstance assetsFile)
        {
            var mats = assetsFile.file.GetAssetsOfType(AssetClassID.Material);
            int shaderFileID = GetDependencyIndexOfShadersBundles(assetsFile);

            foreach (var mat in mats)
            {
                var matBase = manager.GetBaseField(assetsFile, mat);
                long currentShaderPathID = matBase["m_Shader"]["m_PathID"].AsLong;

                if (foundShaders.TryGetValue(currentShaderPathID, out Shader shader))
                {
                    AssignShaderToMaterial(mat, matBase, shaderFileID, shader.PathID);
                }
                else
                {
                    FormShaderSelect shaderSelect = new FormShaderSelect(matBase["m_Name"].AsString, ShaderList);
                    while (shaderSelect.ShowDialog() != DialogResult.OK)
                        MessageBox.Show("You must specify the shader used for this material!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    foundShaders.Add(currentShaderPathID, shaderSelect.Result);
                    AssignShaderToMaterial(mat, matBase, shaderFileID, shaderSelect.Result.PathID);
                }
                
                mat.SetNewData(matBase);
            }

            SetAssetsFileInBundle(bundle, assetsFile);
            ClearShaderPathIDs();
        }

        public void CopyMonos(AssetsFileInstance to, AssetsFileInstance from)
        {
            var toMonos = to.file.GetAssetsOfType(AssetClassID.MonoBehaviour);
            var fromMonos = from.file.GetAssetsOfType(AssetClassID.MonoBehaviour);

            foreach (var toMono in toMonos)
            {
                var toMonoBase = manager.GetBaseField(to, toMono);
                var toMonoScriptBase = manager.GetBaseField(to, to.file.GetAssetInfo(toMonoBase["m_Script"]["m_PathID"].AsLong));

                string monoScriptName = toMonoScriptBase["m_Name"].AsString;

                var fromMonoScript = from.file.GetAssetsOfType(AssetClassID.MonoScript).Find(s => managerV.GetBaseField(from, s)["m_Name"].AsString == monoScriptName);
                if (fromMonoScript == null)
                    return;
                
                var fromMono = fromMonos.Find(b => managerV.GetBaseField(from, b)["m_Script"]["m_PathID"].AsLong == fromMonoScript.PathId);
                if (fromMono == null)
                    return;

                switch (monoScriptName)
                {
                    case "CurvePatterns":
                        CopyCurvePatterns(to, from, toMono, fromMono);
                        break;
                    case "FieldCharacterEntity":
                        CopyFieldCharacterEntity(to, from, toMono, fromMono);
                        break;
                    case "FieldPlayerEntity":
                        CopyFieldPlayerEntity(to, from, toMono, fromMono);
                        break;
                }
            }

            SetAssetsFileInBundle(to.parentBundle, to);
        }

        public void AdjustRendererBones(AssetsFileInstance to, AssetsFileInstance from)
        {
            var toRenderers = to.file.GetAssetsOfType(AssetClassID.SkinnedMeshRenderer);
            var fromRenderers = from.file.GetAssetsOfType(AssetClassID.SkinnedMeshRenderer);

            foreach (var toRenderer in toRenderers)
            {
                var toRendererBase = manager.GetBaseField(to, toRenderer);
                var toGo = manager.GetBaseField(to, toRendererBase["m_GameObject"]["m_PathID"].AsLong);
                if (toGo == null)
                    return;

                var fromRenderer = fromRenderers.Find(b => managerV.GetBaseField(from, managerV.GetBaseField(from, b)["m_GameObject"]["m_PathID"].AsLong)["m_Name"].AsString == toGo["m_Name"].AsString);
                if (fromRenderer == null)
                    return;

                var fromRendererBase = managerV.GetBaseField(from, fromRenderer);

                toRendererBase["m_Bones"]["Array"].Children = fromRendererBase["m_Bones"]["Array"].Children;
                for (int i=0; i<fromRendererBase["m_Bones"]["Array"].Children.Count; i++)
                {
                    var fromBone = fromRendererBase["m_Bones"]["Array"].Children[i];
                    var toBone = toRendererBase["m_Bones"]["Array"].Children[i];
                    toBone["m_PathID"].AsLong = FindComponentPathIDFromGameObjectName(to, from, toBone, fromBone, AssetClassID.Transform);
                }

                toRenderer.SetNewData(toRendererBase);
            }

            SetAssetsFileInBundle(to.parentBundle, to);
        }

        private void CopyCurvePatterns(AssetsFileInstance to, AssetsFileInstance from, AssetFileInfo toMono, AssetFileInfo fromMono)
        {
            var fromMonoBase = managerV.GetBaseField(from, fromMono);
            var toMonoBase = manager.GetBaseField(to, toMono);

            var fromMonoScriptBase = managerV.GetBaseField(from, from.file.GetAssetInfo(fromMonoBase["m_Script"]["m_PathID"].AsLong));
            var toMonoScript = to.file.GetAssetsOfType(AssetClassID.MonoScript).Find(s => manager.GetBaseField(to, s)["m_Name"].AsString == fromMonoScriptBase["m_Name"].AsString);

            if (toMonoScript == null)
                return;

            toMonoBase["m_Enabled"].AsBool = fromMonoBase["m_Enabled"].AsBool;
            toMonoBase["curves"]["Array"].Children = fromMonoBase["curves"]["Array"].Children;

            toMono.SetNewData(toMonoBase);
        }

        private void CopyFieldCharacterEntity(AssetsFileInstance to, AssetsFileInstance from, AssetFileInfo toMono, AssetFileInfo fromMono)
        {
            var fromMonoBase = managerV.GetBaseField(from, fromMono);
            var toMonoBase = manager.GetBaseField(to, toMono);

            var fromMonoScriptBase = managerV.GetBaseField(from, from.file.GetAssetInfo(fromMonoBase["m_Script"]["m_PathID"].AsLong));
            var toMonoScript = to.file.GetAssetsOfType(AssetClassID.MonoScript).Find(s => manager.GetBaseField(to, s)["m_Name"].AsString == fromMonoScriptBase["m_Name"].AsString);

            if (toMonoScript == null)
                return;

            CopyFieldCharacterEntityFields(to, from, toMonoBase, fromMonoBase);

            toMono.SetNewData(toMonoBase);
        }

        private void CopyFieldPlayerEntity(AssetsFileInstance to, AssetsFileInstance from, AssetFileInfo toMono, AssetFileInfo fromMono)
        {
            var fromMonoBase = managerV.GetBaseField(from, fromMono);
            var toMonoBase = manager.GetBaseField(to, toMono);

            var fromMonoScriptBase = managerV.GetBaseField(from, from.file.GetAssetInfo(fromMonoBase["m_Script"]["m_PathID"].AsLong));
            var toMonoScript = to.file.GetAssetsOfType(AssetClassID.MonoScript).Find(s => manager.GetBaseField(to, s)["m_Name"].AsString == fromMonoScriptBase["m_Name"].AsString);

            if (toMonoScript == null)
                return;

            CopyFieldCharacterEntityFields(to, from, toMonoBase, fromMonoBase);
            CopyFieldPlayerEntityFields(to, from, toMonoBase, fromMonoBase);

            toMono.SetNewData(toMonoBase);
        }

        private void CopyFieldCharacterEntityFields(AssetsFileInstance to, AssetsFileInstance from, AssetTypeValueField toMonoBase, AssetTypeValueField fromMonoBase)
        {
            toMonoBase["m_Enabled"].AsBool = fromMonoBase["m_Enabled"].AsBool;
            toMonoBase["m_Name"].AsString = fromMonoBase["m_Name"].AsString;
            toMonoBase["_enityName"].AsString = fromMonoBase["_enityName"].AsString;
            toMonoBase["IsIgnorePlayerCollision"].AsBool = fromMonoBase["IsIgnorePlayerCollision"].AsBool;
            toMonoBase["HandScale"].AsFloat = fromMonoBase["HandScale"].AsFloat;

            MergeAnimationClipsOfEntity(to, from, toMonoBase, fromMonoBase);

            toMonoBase["_variations"]["Array"].Children = fromMonoBase["_variations"]["Array"].Children;
            for (int i=0; i<fromMonoBase["_variations"]["Array"].Children.Count; i++)
            {
                var fromVariation = fromMonoBase["_variations"]["Array"].Children[i];
                var toVariation = toMonoBase["_variations"]["Array"].Children[i];
                toVariation["root"]["m_PathID"].AsLong = FindComponentPathIDFromGameObjectName(to, from, toVariation["root"], fromVariation["root"], AssetClassID.Transform);
                toVariation["neck"]["m_PathID"].AsLong = FindComponentPathIDFromGameObjectName(to, from, toVariation["neck"], fromVariation["neck"], AssetClassID.Transform);
                toVariation["lhand"]["m_PathID"].AsLong = FindComponentPathIDFromGameObjectName(to, from, toVariation["lhand"], fromVariation["lhand"], AssetClassID.Transform);
                toVariation["rhand"]["m_PathID"].AsLong = FindComponentPathIDFromGameObjectName(to, from, toVariation["rhand"], fromVariation["rhand"], AssetClassID.Transform);
                toVariation["faceRenderer"]["m_PathID"].AsLong = FindComponentPathIDFromGameObjectName(to, from, toVariation["faceRenderer"], fromVariation["faceRenderer"], AssetClassID.SkinnedMeshRenderer);
                toVariation["eyeMaterialIndex"].AsInt = fromVariation["eyeMaterialIndex"].AsInt;
                toVariation["mouthMaterialIndex"].AsInt = fromVariation["mouthMaterialIndex"].AsInt;
            }

            toMonoBase["_eyePatternIndex"].AsInt = fromMonoBase["_eyePatternIndex"].AsInt;
            toMonoBase["_mouthPatternIndex"].AsInt = fromMonoBase["_mouthPatternIndex"].AsInt;
            toMonoBase["_currentVariation"].AsInt = fromMonoBase["_currentVariation"].AsInt;

            toMonoBase["_watchRenderer"]["m_PathID"].AsLong = FindComponentPathIDFromGameObjectName(to, from, toMonoBase["_watchRenderer"], fromMonoBase["_watchRenderer"], AssetClassID.SkinnedMeshRenderer);

            toMonoBase["NeckAngle"]["x"].AsFloat = fromMonoBase["NeckAngle"]["x"].AsFloat;
            toMonoBase["NeckAngle"]["y"].AsFloat = fromMonoBase["NeckAngle"]["y"].AsFloat;
            toMonoBase["NeckAngle"]["z"].AsFloat = fromMonoBase["NeckAngle"]["z"].AsFloat;

            toMonoBase["_updateNeckAngle"]["x"].AsFloat = fromMonoBase["_updateNeckAngle"]["x"].AsFloat;
            toMonoBase["_updateNeckAngle"]["y"].AsFloat = fromMonoBase["_updateNeckAngle"]["y"].AsFloat;
            toMonoBase["_updateNeckAngle"]["z"].AsFloat = fromMonoBase["_updateNeckAngle"]["z"].AsFloat;

            toMonoBase["_updateNeckAngle2"]["x"].AsFloat = fromMonoBase["_updateNeckAngle2"]["x"].AsFloat;
            toMonoBase["_updateNeckAngle2"]["y"].AsFloat = fromMonoBase["_updateNeckAngle2"]["y"].AsFloat;
            toMonoBase["_updateNeckAngle2"]["z"].AsFloat = fromMonoBase["_updateNeckAngle2"]["z"].AsFloat;

            toMonoBase["SubductionDepth"].AsFloat = fromMonoBase["SubductionDepth"].AsFloat;
        }

        private void CopyFieldPlayerEntityFields(AssetsFileInstance to, AssetsFileInstance from, AssetTypeValueField toMonoBase, AssetTypeValueField fromMonoBase)
        {
            toMonoBase["_hatRenderers"]["Array"].Children = fromMonoBase["_hatRenderers"]["Array"].Children;
            for (int i=0; i<fromMonoBase["_hatRenderers"]["Array"].Children.Count; i++)
            {
                var fromRenderer = fromMonoBase["_hatRenderers"]["Array"].Children[i];
                var toRenderer = toMonoBase["_hatRenderers"]["Array"].Children[i];
                toRenderer["m_PathID"].AsLong = FindComponentPathIDFromGameObjectName(to, from, toRenderer, fromRenderer, AssetClassID.SkinnedMeshRenderer);
            }

            toMonoBase["_shoesRenderers"]["Array"].Children = fromMonoBase["_shoesRenderers"]["Array"].Children;
            for (int i = 0; i < fromMonoBase["_shoesRenderers"]["Array"].Children.Count; i++)
            {
                var fromRenderer = fromMonoBase["_shoesRenderers"]["Array"].Children[i];
                var toRenderer = toMonoBase["_shoesRenderers"]["Array"].Children[i];
                toRenderer["m_PathID"].AsLong = FindComponentPathIDFromGameObjectName(to, from, toRenderer, fromRenderer, AssetClassID.SkinnedMeshRenderer);
            }

            toMonoBase["_meshGroup"]["m_PathID"].AsLong = FindGameObjectPathIDFromName(to, from, toMonoBase["_meshGroup"], fromMonoBase["_meshGroup"]);
            toMonoBase["_bicycleObject"]["m_PathID"].AsLong = FindGameObjectPathIDFromName(to, from, toMonoBase["_bicycleObject"], fromMonoBase["_bicycleObject"]);

            toMonoBase["_rodRenderers"]["Array"].Children = fromMonoBase["_rodRenderers"]["Array"].Children;
            for (int i = 0; i < fromMonoBase["_rodRenderers"]["Array"].Children.Count; i++)
            {
                var fromRenderer = fromMonoBase["_rodRenderers"]["Array"].Children[i];
                var toRenderer = toMonoBase["_rodRenderers"]["Array"].Children[i];
                toRenderer["m_PathID"].AsLong = FindComponentPathIDFromGameObjectName(to, from, toRenderer, fromRenderer, AssetClassID.SkinnedMeshRenderer);
            }

            toMonoBase["_podRenderer"]["m_PathID"].AsLong = FindComponentPathIDFromGameObjectName(to, from, toMonoBase["_podRenderer"], fromMonoBase["_podRenderer"], AssetClassID.SkinnedMeshRenderer);
            toMonoBase["_beadaruRenderer"]["m_PathID"].AsLong = FindComponentPathIDFromGameObjectName(to, from, toMonoBase["_beadaruRenderer"], fromMonoBase["_beadaruRenderer"], AssetClassID.SkinnedMeshRenderer);
            toMonoBase["_mukuhawkRenderer"]["m_PathID"].AsLong = FindComponentPathIDFromGameObjectName(to, from, toMonoBase["_mukuhawkRenderer"], fromMonoBase["_mukuhawkRenderer"], AssetClassID.SkinnedMeshRenderer);
            toMonoBase["_bicycleColors"]["Array"].Children = fromMonoBase["_bicycleColors"]["Array"].Children;
            toMonoBase["_bicycleRenderer"]["m_PathID"].AsLong = FindComponentPathIDFromGameObjectName(to, from, toMonoBase["_bicycleRenderer"], fromMonoBase["_bicycleRenderer"], AssetClassID.SkinnedMeshRenderer);
            toMonoBase["_bicycleMaterialIndex"].AsInt = fromMonoBase["_bicycleMaterialIndex"].AsInt;

            toMonoBase["InputMoveVector"]["x"].AsFloat = fromMonoBase["InputMoveVector"]["x"].AsFloat;
            toMonoBase["InputMoveVector"]["y"].AsFloat = fromMonoBase["InputMoveVector"]["y"].AsFloat;
            toMonoBase["InputMoveVector"]["z"].AsFloat = fromMonoBase["InputMoveVector"]["z"].AsFloat;

            toMonoBase["FormType"].AsInt = fromMonoBase["FormType"].AsInt;
            toMonoBase["ForcePlayNaminoriEffect"].AsBool = fromMonoBase["ForcePlayNaminoriEffect"].AsBool;
        }

        private void MergeAnimationClipsOfEntity(AssetsFileInstance to, AssetsFileInstance from, AssetTypeValueField toMonoBase, AssetTypeValueField fromMonoBase)
        {
            for (int i=toMonoBase["_animationPlayer"]["_clips"]["Array"].Children.Count; i<fromMonoBase["_animationPlayer"]["_clips"]["Array"].Children.Count; i++)
            {
                var newClip = ValueBuilder.DefaultValueFieldFromArrayTemplate(toMonoBase["_animationPlayer"]["_clips"]["Array"]);
                toMonoBase["_animationPlayer"]["_clips"]["Array"].Children.Add(newClip);
            }

            for (int i=0; i<toMonoBase["_animationPlayer"]["_clips"]["Array"].Children.Count; i++)
            {
                long toClipPathID = toMonoBase["_animationPlayer"]["_clips"]["Array"][i]["m_PathID"].AsLong;
                if (toClipPathID != 0)
                    continue;

                long toClipFileID = toMonoBase["_animationPlayer"]["_clips"]["Array"][i]["m_FileID"].AsLong;
                if (toClipFileID != 0)
                    continue;

                long clipPathID = FindAnimationClipPathIDFromName(to, from, toMonoBase["_animationPlayer"]["_clips"]["Array"][i], fromMonoBase["_animationPlayer"]["_clips"]["Array"][i]);
                toMonoBase["_animationPlayer"]["_clips"]["Array"][i]["m_PathID"].AsLong = clipPathID;
            }
        }

        private long FindAnimationClipPathIDFromName(AssetsFileInstance to, AssetsFileInstance from, AssetTypeValueField toField, AssetTypeValueField fromField)
        {
            if (fromField["m_PathID"].AsLong == 0)
                return 0;

            var animInfo = from.file.GetAssetInfo(fromField["m_PathID"].AsLong);
            if (animInfo == null)
                return 0;

            string clipName = managerV.GetBaseField(from, animInfo)["m_Name"].AsString;
            var toClip = to.file.GetAssetsOfType(AssetClassID.AnimationClip).Find(c => manager.GetBaseField(to, c)["m_Name"].AsString == clipName);
            if (toClip == null)
                return 0;

            return toClip.PathId;
        }

        private long FindComponentPathIDFromGameObjectName(AssetsFileInstance to, AssetsFileInstance from, AssetTypeValueField toField, AssetTypeValueField fromField, AssetClassID klass)
        {
            if (fromField["m_PathID"].AsLong == 0)
                return 0;

            var fromComponent = managerV.GetBaseField(from, from.file.GetAssetInfo(fromField["m_PathID"].AsLong));
            var fromGO = managerV.GetBaseField(from, fromComponent["m_GameObject"]["m_PathID"].AsLong);

            var toGO = to.file.GetAssetsOfType(AssetClassID.GameObject).Find(g => manager.GetBaseField(to, g)["m_Name"].AsString == fromGO["m_Name"].AsString);
            if (toGO == null)
                return 0;

            var toGOBase = manager.GetBaseField(to, toGO);
            var toComponent = to.file.GetAssetsOfType(klass).Find(a => toGOBase["m_Component"]["Array"].Children.Any(c => c["component"]["m_PathID"].AsLong == a.PathId));
            if (toComponent == null)
                return 0;

            return toComponent.PathId;
        }

        private long FindGameObjectPathIDFromName(AssetsFileInstance to, AssetsFileInstance from, AssetTypeValueField toField, AssetTypeValueField fromField)
        {
            if (fromField["m_PathID"].AsLong == 0)
                return 0;

            var fromGO = managerV.GetBaseField(from, fromField["m_PathID"].AsLong);

            var toGO = to.file.GetAssetsOfType(AssetClassID.GameObject).Find(g => manager.GetBaseField(to, g)["m_Name"].AsString == fromGO["m_Name"].AsString);
            if (toGO == null)
                return 0;

            return toGO.PathId;
        }

        private void ClearShaderPathIDs()
        {
            foundShaders.Clear();
        }

        private int GetDependencyIndexOfShadersBundles(AssetsFileInstance assetsFile)
        {
            return assetsFile.file.Metadata.Externals.FindIndex(d => d.PathName == "archive:/CAB-1dc8d26be8722a766953ce9d8a444e8c/CAB-1dc8d26be8722a766953ce9d8a444e8c") + 1;
        }

        private void AssignShaderToMaterial(AssetFileInfo mat, AssetTypeValueField matBase, long fileID, long pathID)
        {
            if (fileID != -1)
                matBase["m_Shader"]["m_FileID"].AsLong = fileID;

            matBase["m_Shader"]["m_PathID"].AsLong = pathID;

            mat.SetNewData(matBase);
        }

        private void ClearDependencies(AssetsFileInstance assetsFile)
        {
            assetsFile.file.Metadata.Externals.Clear();
        }

        private void AddDependency(AssetsFileInstance assetsFile, string path)
        {
            var deps = assetsFile.file.Metadata.Externals;
            AssetsFileExternal dep = new AssetsFileExternal()
            {
                VirtualAssetPathName = "",
                PathName = path,
                OriginalPathName = "",
                Type = AssetsFileExternalType.Normal,
                Guid = default,
            };
            deps.Add(dep);
        }

        private void CopyMaterial(AssetFileInfo toMat, AssetTypeValueField fromMatBase)
        {
            byte[] fromData = fromMatBase.WriteToByteArray();
            toMat.SetNewData(fromData);
        }

        private TypeTreeType ConvertTemplateFieldToTypeTree(ClassDatabaseFile cldbFile, AssetTypeTemplateField templateField, int typeId, ushort scriptIndex)
        {
            return typeTreeConverter.ConvertInternal(cldbFile, templateField, typeId, scriptIndex);
        }
    }
}
