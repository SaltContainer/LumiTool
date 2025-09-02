using AssetsTools.NET.Extra;
using LumiTool.Data;
using LumiTool.Engine;
using LumiTool.Forms.Popups;

namespace LumiTool.Forms
{
    public partial class FormBundlePrepper : Form
    {
        LumiToolEngine engine;
        BundleFileInstance bundle = null;
        AssetsFileInstance afileInst = null;
        BundleFileInstance bundleV = null;
        AssetsFileInstance afileInstV = null;

        bool NewBundleLoaded => bundle != null;
        bool VanillaBundleLoaded => bundleV != null;

        public FormBundlePrepper(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;

            ttBundlePrepper.SetToolTip(checkTpk, "Checking this before loading the rebuilt bundle will load\nthe classdata.tpk file in the same folder as the executable.\nUse this if you built the bundle without a type tree.");
            ttBundlePrepper.SetToolTip(checkConvertPlatform, "Changes the platform metadata of the rebuilt bundle to Switch.");
            ttBundlePrepper.SetToolTip(checkConvertDependencies, "Copies the dependencies of the vanilla bundle onto the rebuilt bundle.\nOff by default.\nThis is the only option that actually looks at the vanilla bundle.");
            ttBundlePrepper.SetToolTip(checkConvertShaders, "When on, each material asset's shader will be remapped.\nThe user will be asked to identify the proper shader from a pre-set list\nfor each different shader that was detected.");
            ttBundlePrepper.SetToolTip(checkReassignDependencies, "When on, every asset's references to assets in dependencies will be remapped.\nThe user will be asked to identify the proper asset from a pre-set list\nfor each different asset that was detected.");
        }

        private void UpdateComponentsOnStart()
        {
            lbBundleName.Text = "Bundle Name: ";
            lbBundleVName.Text = "Bundle Name: ";
            btnBundleSave.Enabled = false;
            btnConvertApply.Enabled = false;
            checkConvertPlatform.Enabled = false;
            checkConvertDependencies.Enabled = false;
            checkConvertShaders.Enabled = false;
            checkReassignDependencies.Enabled = false;
            checkTpk.Enabled = true;

            ttBundlePrepper.SetToolTip(lbBundleName, "");
            ttBundlePrepper.SetToolTip(lbBundleVName, "");
        }

        private void UpdateComponentsOnLoadCommon()
        {
            btnBundleSave.Enabled = NewBundleLoaded;
            btnConvertApply.Enabled = NewBundleLoaded;
            checkConvertPlatform.Enabled = NewBundleLoaded;
            checkConvertDependencies.Enabled = NewBundleLoaded && VanillaBundleLoaded;
            checkConvertShaders.Enabled = NewBundleLoaded;
            checkReassignDependencies.Enabled = NewBundleLoaded && engine.IsDependencyConfigLoaded();
        }

        private void UpdateComponentsOnLoadEditing()
        {
            lbBundleName.Text = "Bundle Name: " + bundle.name;
            ttBundlePrepper.SetToolTip(lbBundleName, bundle.name);
            checkTpk.Enabled = false;
            UpdateComponentsOnLoadCommon();
        }

        private void UpdateComponentsOnLoadVanilla()
        {
            lbBundleVName.Text = "Bundle Name: " + bundleV.name;
            ttBundlePrepper.SetToolTip(lbBundleVName, bundleV.name);
            UpdateComponentsOnLoadCommon();
        }

        private void OpenBundle(string path)
        {
            bundle = engine.LoadBundle(path, BundleEngine.ManagerID.Modded);
            afileInst = engine.LoadAssetsFileFromBundle(bundle, BundleEngine.ManagerID.Modded);

            if (checkTpk.Checked)
                engine.LoadClassPackage(afileInst, BundleEngine.ManagerID.Modded);

            UpdateComponentsOnLoadEditing();
        }

        private void OpenVBundle(string path)
        {
            bundleV = engine.LoadBundle(path, BundleEngine.ManagerID.Vanilla);
            afileInstV = engine.LoadAssetsFileFromBundle(bundleV, BundleEngine.ManagerID.Vanilla);

            UpdateComponentsOnLoadVanilla();
        }

        private void btnBundleOpen_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                OpenBundle(openFileDialog.FileName);
        }

        private void btnBundleSave_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                engine.SaveBundleToFile(bundle, saveFileDialog.FileName);
                MessageBox.Show("Successfully saved the new bundle!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBundleVOpen_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                OpenVBundle(openFileDialog.FileName);
        }

        private void FormBundlePrepper_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormBundlePrepper_FormClosed(object sender, FormClosedEventArgs e)
        {
            bundle = null;
            afileInst = null;
            bundleV = null;
            afileInstV = null;
            engine.UnloadBundles();
        }

        private void btnConvertApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkConvertPlatform.Checked) engine.SetPlatformOfBundle(bundle, afileInst, Platform.Switch);
                if (checkConvertDependencies.Checked) engine.CopyDependencies(afileInst, afileInstV);
                if (checkConvertShaders.Checked && !checkReassignDependencies.Checked) engine.FixShadersOfMaterials(bundle, afileInst);
                if (checkReassignDependencies.Checked)
                {
                    using FormDependencySelect depSelect = new FormDependencySelect(engine.GetCABNamesInBundleDependencies(afileInst));
                    while (depSelect.ShowDialog() != DialogResult.OK)
                        MessageBox.Show("You must select the dependencies to remap!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    engine.ReassignExternalDependencyReferences(bundle, afileInst, false, depSelect.Result);
                }
                MessageBox.Show("Successfully converted the bundle. Don't forget to save your bundle!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an exception when converting the bundle. Full Exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBundleOpen_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void btnBundleOpen_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 1)
                MessageBox.Show("Multiple files were dragged into the tool. The Bundle Prepper only supports one file at a time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                OpenBundle(files[0]);
        }

        private void btnBundleVOpen_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void btnBundleVOpen_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 1)
                MessageBox.Show("Multiple files were dragged into the tool. The Bundle Prepper only supports one file at a time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                OpenVBundle(files[0]);
        }
    }
}
