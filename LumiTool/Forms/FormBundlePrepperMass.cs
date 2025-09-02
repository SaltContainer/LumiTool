using LumiTool.Data;
using LumiTool.Engine;
using LumiTool.Forms.Popups;

namespace LumiTool.Forms
{
    public partial class FormBundlePrepperMass : Form
    {
        LumiToolEngine engine;
        string folderPath = null;
        string outputPath = null;

        bool FoldersSet => folderPath != null && outputPath != null;
        bool CanRemapDependencies => FoldersSet && engine.IsDependencyConfigLoaded();

        public FormBundlePrepperMass(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;

            ttBundlePrepper.SetToolTip(checkTpk, "Checking this before selecting the rebuilt bundles folder\nthe classdata.tpk file in the same folder as the executable.\nUse this if you built the bundles without a type tree.");
            ttBundlePrepper.SetToolTip(checkConvertPlatform, "Changes the platform metadata of the rebuilt bundles to Switch.");
            ttBundlePrepper.SetToolTip(checkReassignDependencies, "When on, every asset's references to assets in dependencies will be remapped.\nThe user will be asked to identify the proper asset from a pre-set list\nfor each different asset that was detected.");
        }

        private void UpdateComponentsOnStart()
        {
            lbBundleName.Text = "Folder Path: ";
            lbOutputBundleName.Text = "Folder Path: ";
            btnConvertApply.Enabled = false;
            checkConvertPlatform.Enabled = false;
            checkReassignDependencies.Enabled = false;
            checkTpk.Enabled = true;

            ttBundlePrepper.SetToolTip(lbBundleName, "");
        }

        private void UpdateComponentsOnLoadCommon()
        {
            btnConvertApply.Enabled = FoldersSet;
            checkConvertPlatform.Enabled = FoldersSet;
            checkReassignDependencies.Enabled = CanRemapDependencies;
        }

        private void UpdateComponentsOnLoadEditing()
        {
            lbBundleName.Text = "Folder Path: " + folderPath;
            ttBundlePrepper.SetToolTip(lbBundleName, folderPath);
            checkTpk.Enabled = false;
            UpdateComponentsOnLoadCommon();
        }

        private void UpdateComponentsOnLoadVanilla()
        {
            lbOutputBundleName.Text = "Folder Path: " + outputPath;
            ttBundlePrepper.SetToolTip(lbOutputBundleName, outputPath);
            UpdateComponentsOnLoadCommon();
        }

        private void btnBundleOpen_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog.SelectedPath;

                UpdateComponentsOnLoadEditing();
            }
        }

        private void btnOutputBundleOpen_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                outputPath = folderBrowserDialog.SelectedPath;

                UpdateComponentsOnLoadVanilla();
            }
        }

        private void FormBundlePrepperMass_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormBundlePrepperMass_FormClosed(object sender, FormClosedEventArgs e)
        {
            engine.UnloadBundles();
        }

        private void btnConvertApply_Click(object sender, EventArgs e)
        {
            bool classesLoaded = !checkTpk.Checked;
            bool exceptionHappened = false;
            var foundShaders = new Dictionary<(string, long), Shader>();
            var foundReferences = new Dictionary<(string, long), DependencyAsset>();

            var selectedCabs = new List<string>();
            if (checkReassignDependencies.Checked && CanRemapDependencies)
            {
                using FormDependencySelect depSelect = new FormDependencySelect(engine.GetDependencyConfig().Bundles.Select(b => b.CABName).ToList());
                while (depSelect.ShowDialog() != DialogResult.OK)
                    MessageBox.Show("You must select the dependencies to remap!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                selectedCabs = depSelect.Result;
            }

            var files = Directory.GetFiles(folderPath);
            foreach (var file in files)
            {
                try
                {
                    var bundle = engine.LoadBundle(file, BundleEngine.ManagerID.Modded);
                    var afileInst = engine.LoadAssetsFileFromBundle(bundle, BundleEngine.ManagerID.Modded);

                    if (checkConvertPlatform.Checked) engine.SetPlatformOfBundle(bundle, afileInst, Platform.Switch);
                    if (checkReassignDependencies.Checked && CanRemapDependencies) engine.ReassignExternalDependencyReferences(bundle, afileInst, true, foundReferences, selectedCabs);

                    if (!classesLoaded && checkTpk.Checked)
                    {
                        engine.LoadClassPackage(afileInst, BundleEngine.ManagerID.Modded);
                        classesLoaded = true;
                    }

                    engine.SaveBundleToFile(bundle, Path.Combine(outputPath, Path.GetFileName(file)));
                }
                catch (Exception ex)
                {
                    exceptionHappened = true;
                    MessageBox.Show("There was an exception when converting the bundle at \"" + file + "\". Full Exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (exceptionHappened)
                MessageBox.Show("There were one or more exceptions while preparing bundles. Any successfully prepared bundles were still saved to the output folder.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Successfully saved all the new bundles to the output folder!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
