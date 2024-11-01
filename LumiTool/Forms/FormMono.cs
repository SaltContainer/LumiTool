using AssetsTools.NET.Extra;
using LumiTool.Engine;
using System.Windows.Forms;

namespace LumiTool.Forms
{
    public partial class FormMono : Form
    {
        LumiToolEngine engine;
        BundleFileInstance bundle = null;
        AssetsFileInstance afileInst = null;

        public FormMono(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;
        }

        private void UpdateComponentsOnStart()
        {
            lbBundleName.Text = "Bundle Name: ";
            btnBundleSave.Enabled = false;
            btnAddMono.Enabled = false;
            txtAssembly.Enabled = false;
            txtNamespace.Enabled = false;
            txtClass.Enabled = false;
            txtAssembly.Text = "";
            txtNamespace.Text = "";
            txtClass.Text = "";
        }

        private void UpdateComponentsOnLoad()
        {
            lbBundleName.Text = "Bundle Name: " + bundle.name;
            btnBundleSave.Enabled = true;
            btnAddMono.Enabled = true;
            txtAssembly.Enabled = true;
            txtNamespace.Enabled = true;
            txtClass.Enabled = true;
        }

        private void OpenBundle(string path)
        {
            bundle = engine.LoadBundle(path, BundleEngine.ManagerID.Modded);
            afileInst = engine.LoadAssetsFileFromBundle(bundle, BundleEngine.ManagerID.Modded);

            UpdateComponentsOnLoad();
        }

        private void btnAddMono_Click(object sender, EventArgs e)
        {
            bool result = engine.AddMonoScript(bundle, afileInst, txtAssembly.Text, txtNamespace.Text, txtClass.Text, BundleEngine.ManagerID.Modded);

            if (result)
                MessageBox.Show("Successfully added the new MonoScript. Don't forget to save your bundle!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Could not find this class in the assembly. Are your DLLs in the Managed folder?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                engine.SaveBundleToFile(bundle, saveFileDialog.FileName);
                MessageBox.Show("Successfully saved the new bundle!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormMono_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormMono_FormClosed(object sender, FormClosedEventArgs e)
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
                MessageBox.Show("Multiple files were dragged into the tool. You can only add Monos one file at a time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                OpenBundle(files[0]);
        }
    }
}
