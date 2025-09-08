using AssetsTools.NET.Extra;
using LumiTool.Engine;

namespace LumiTool.Forms
{
    public partial class FormRenameBundle : Form
    {
        LumiToolEngine engine;
        BundleFileInstance bundle = null;
        AssetsFileInstance afileInst = null;

        public FormRenameBundle(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;
        }

        private void UpdateComponentsOnStart()
        {
            lbBundleName.Text = "Bundle Name: ";
            txtBundleRename.Enabled = false;
            txtCABRename.Enabled = false;
            btnBundleSave.Enabled = false;
            btnApply.Enabled = false;

            txtBundleRename.Text = "";
            txtCABRename.Text = "";

            ttRenameBundle.SetToolTip(lbBundleName, "");
        }

        private void UpdateComponentsOnLoad()
        {
            lbBundleName.Text = "Bundle Name: " + bundle.name;
            txtBundleRename.Enabled = true;
            txtCABRename.Enabled = true;
            btnBundleSave.Enabled = true;
            btnApply.Enabled = true;

            ttRenameBundle.SetToolTip(lbBundleName, bundle.name);
        }

        private void OpenBundle(string path)
        {
            bundle = engine.LoadBundle(path, BundleEngine.ManagerID.Modded);
            afileInst = engine.LoadAssetsFileFromBundle(bundle, BundleEngine.ManagerID.Modded);
            UpdateComponentsOnLoad();
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

        private void FormRenameBundle_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormRenameBundle_FormClosed(object sender, FormClosedEventArgs e)
        {
            bundle = null;
            afileInst = null;
            engine.UnloadBundles();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                engine.RenameBundle(bundle, afileInst, txtBundleRename.Text, txtCABRename.Text);
                MessageBox.Show("Successfully renamed. Don't forget to save your bundle!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an exception when renaming the bundle. Full Exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Multiple files were dragged into the tool. The Bundle Renamer only supports one file at a time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                OpenBundle(files[0]);
        }
    }
}
