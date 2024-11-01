using AssetsTools.NET.Extra;
using LumiTool.Engine;
using System.Windows.Forms;

namespace LumiTool.Forms
{
    public partial class FormShaderPathIDFixer : Form
    {
        LumiToolEngine engine;
        BundleFileInstance bundle = null;
        AssetsFileInstance afileInst = null;
        BundleFileInstance bundleV = null;
        AssetsFileInstance afileInstV = null;

        public FormShaderPathIDFixer(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;
        }

        private void UpdateComponentsOnStart()
        {
            lbBundleName.Text = "Bundle Name: ";
            lbBundleVName.Text = "Bundle Name: ";
            btnBundleSave.Enabled = false;
            btnFix.Enabled = false;

            ttShaderPathIDFixer.SetToolTip(lbBundleName, "");
            ttShaderPathIDFixer.SetToolTip(lbBundleVName, "");
        }

        private void UpdateComponentsOnLoadCommon()
        {
            bool active = bundle != null && bundleV != null;
            btnBundleSave.Enabled = active;
            btnFix.Enabled = active;
        }

        private void UpdateComponentsOnLoadEditing()
        {
            lbBundleName.Text = "Bundle Name: " + bundle.name;
            ttShaderPathIDFixer.SetToolTip(lbBundleName, bundle.name);
            UpdateComponentsOnLoadCommon();
        }

        private void UpdateComponentsOnLoadVanilla()
        {
            lbBundleVName.Text = "Bundle Name: " + bundleV.name;
            ttShaderPathIDFixer.SetToolTip(lbBundleVName, bundleV.name);
            UpdateComponentsOnLoadCommon();
        }

        private void OpenBundle(string path)
        {
            bundle = engine.LoadBundle(path, BundleEngine.ManagerID.Modded);
            afileInst = engine.LoadAssetsFileFromBundle(bundle, BundleEngine.ManagerID.Modded);
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

        private void FormShaderPathIDFixer_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormShaderPathIDFixer_FormClosed(object sender, FormClosedEventArgs e)
        {
            bundle = null;
            afileInst = null;
            bundleV = null;
            afileInstV = null;
            engine.UnloadBundles();
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            try
            {
                if (engine.ChangeShadersBundlePathIDs(bundle, afileInst, bundleV, afileInstV))
                    MessageBox.Show("Successfully fixed the path IDs of all shaders and materials in the bundle. Don't forget to save your bundle!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Some shaders or materials could not be found, but the ones that were found were successfully fixed. You can still save your bundle.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Multiple files were dragged into the tool. The Shader Bundle PathID Fixer only supports one file at a time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Multiple files were dragged into the tool. The Shader Bundle PathID Fixer only supports one file at a time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                OpenVBundle(files[0]);
        }
    }
}
