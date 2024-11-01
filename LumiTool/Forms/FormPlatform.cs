using AssetsTools.NET.Extra;
using LumiTool.Data;
using LumiTool.Engine;
using System.Windows.Forms;

namespace LumiTool.Forms
{
    public partial class FormPlatform : Form
    {
        LumiToolEngine engine;
        BundleFileInstance bundle = null;
        AssetsFileInstance afileInst = null;

        public FormPlatform(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;

            comboPlatform.DataSource = Enum.GetValues(typeof(Platform));
        }

        private void UpdateComponentsOnStart()
        {
            lbBundleName.Text = "Bundle Name: ";
            btnBundleSave.Enabled = false;
            comboPlatform.Enabled = false;
            comboPlatform.SelectedItem = Platform.StandaloneWindows;
        }

        private void UpdateComponentsOnLoad()
        {
            lbBundleName.Text = "Bundle Name: " + bundle.name;
            btnBundleSave.Enabled = true;
            comboPlatform.Enabled = true;
            comboPlatform.SelectedItem = (Platform)afileInst.file.Metadata.TargetPlatform;
        }

        private void OpenBundle(string path)
        {
            bundle = engine.LoadBundle(path, BundleEngine.ManagerID.Modded);
            afileInst = engine.LoadAssetsFileFromBundle(bundle, BundleEngine.ManagerID.Modded);

            UpdateComponentsOnLoad();
        }

        private void btnBundleOpen_Click(object sender, EventArgs e)
        {
            engine.UnloadBundles();

            using OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                OpenBundle(openFileDialog.FileName);
        }

        private void btnBundleSave_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                engine.SetPlatformOfBundle(bundle, afileInst, (Platform)comboPlatform.SelectedItem);
                engine.SaveBundleToFile(bundle, saveFileDialog.FileName);
                MessageBox.Show("Successfully saved the new bundle!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormPlatform_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormPlatform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bundle = null;
            afileInst = null;
            engine.UnloadBundles();
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
                MessageBox.Show("Multiple files were dragged into the tool. You can only change the platform one file at a time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                OpenBundle(files[0]);
        }
    }
}
