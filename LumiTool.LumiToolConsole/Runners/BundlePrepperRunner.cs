using LumiTool.Data;
using LumiTool.Engine;
using LumiTool.Options;

namespace LumiTool.Runners
{
    public class BundlePrepperRunner
    {
        private LumiToolEngine engine;

        public BundlePrepperRunner(LumiToolEngine engine)
        {
            this.engine = engine;
        }

        // TODO: Make this actually select
        private DependencyAsset FindDependencyAsset(string assetName, string fieldName, string bundleName, List<DependencyAsset> dependencyAssets)
        {
            return dependencyAssets[0];
        }

        public void Run(BundlePrepperOptions options)
        {
            if (!options.SetPlatform && !options.CopyDependencies && !options.RemapDependencies)
            {
                Console.WriteLine("[Bundle Prepper] No steps were enabled, so nothing was done to the bundle.");
                return;
            }

            try
            {
                var bundle = engine.LoadBundle(options.InputPath, BundleEngine.ManagerID.Modded);
                var afileInst = engine.LoadAssetsFileFromBundle(bundle, BundleEngine.ManagerID.Modded);

                if (options.LoadClassData)
                {
                    engine.LoadClassPackage(afileInst, BundleEngine.ManagerID.Modded);
                    Console.WriteLine("[Bundle Prepper] Class Package loaded.");
                }

                if (options.SetPlatform)
                {
                    engine.SetPlatformOfBundle(bundle, afileInst, Platform.Switch);
                    Console.WriteLine("[Bundle Prepper] Platform changed to Switch.");
                }

                if (options.CopyDependencies)
                {
                    if (options.VanillaPath != null)
                    {
                        var bundleV = engine.LoadBundle(options.VanillaPath, BundleEngine.ManagerID.Vanilla);
                        var afileInstV = engine.LoadAssetsFileFromBundle(bundleV, BundleEngine.ManagerID.Vanilla);

                        if (options.LoadClassData)
                        {
                            engine.LoadClassPackage(afileInst, BundleEngine.ManagerID.Vanilla);
                            Console.WriteLine("[Bundle Prepper] Class Package loaded for vanilla bundle.");
                        }

                        engine.CopyDependencies(afileInst, afileInstV);
                        Console.WriteLine("[Bundle Prepper] Copied dependencies from vanilla bundle.");
                    }
                    else
                    {
                        Console.WriteLine("[Bundle Prepper] No vanilla bundles was specified. The \"Copy Dependencies\" step will be skipped.");
                    }
                }

                if (options.RemapDependencies)
                {
                    if (engine.IsDependencyConfigLoaded())
                    {
                        var cabsToRemap = engine.GetCABNamesInBundleDependencies(afileInst);
                        var supportedBundles = engine.GetDependencyConfig().Bundles;
                        var missingCabs = cabsToRemap.Where(c => !supportedBundles.Any(b => b.CABName == c)).ToList();
                        var selectableBundles = supportedBundles.Where(b => cabsToRemap.Any(c => c == b.CABName)).ToList();

                        if (missingCabs.Any())
                        {
                            Console.WriteLine($"[Bundle Prepper] The bundles with the following CAB names are not present in the dependency config file:");
                            foreach (var cab in missingCabs)
                                Console.WriteLine($"[Bundle Prepper] {cab}");

                            Console.WriteLine("[Bundle Prepper] Assets with a reference to these dependencies will not be changed.");
                        }

                        // TODO: Using all selectable bundles for now, somehow make them selectable in the cmd later
                        /*using FormDependencySelect depSelect = new FormDependencySelect(selectableBundles);
                        while (depSelect.ShowDialog() != DialogResult.OK)
                            MessageBox.Show("You must select the dependencies to remap!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        engine.AddOnAssetSelectCallback(FindDependencyAsset);
                        engine.ReassignExternalDependencyReferences(bundle, afileInst, false, depSelect.Result.Select(b => b.CABName).ToList());*/

                        Console.WriteLine("[Bundle Prepper] Using all selectable bundles for now, they will be selectable in the command prompt later.");
                        Console.WriteLine("[Bundle Prepper] Using the first asset in the list when asking to select one, they will be selectable in the command prompt later.");

                        engine.AddOnAssetSelectCallback(FindDependencyAsset);
                        engine.ReassignExternalDependencyReferences(bundle, afileInst, false, selectableBundles.Select(b => b.CABName).ToList());
                    }
                    else
                    {
                        Console.WriteLine("[Bundle Prepper] The dependency remapping configuration is not loaded. The \"Remap References to Dependencies\" step will be skipped.");
                    }
                }

                engine.SaveBundleToFile(bundle, options.OutputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Bundle Prepper] There was an exception when preparing the bundle. Full Exception: {ex.Message}");
            }
        }
    }
}
