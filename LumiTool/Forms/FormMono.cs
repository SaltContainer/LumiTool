using AssetsTools.NET.Extra;
using LumiTool.Engine;

namespace LumiTool.Forms
{
    public partial class FormMono : Form
    {
        LumiToolEngine engine;
        BundleFileInstance bundle = null!;
        AssetsFileInstance afileInst = null!;

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

        private void btnAddMono_Click(object sender, EventArgs e)
        {
            bool result = engine.AddMonoScript(bundle, afileInst, txtAssembly.Text, txtNamespace.Text, txtClass.Text);

            if (result)
                MessageBox.Show("Successfully added the new MonoScript. Don't forget to save your bundle!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Could not find this class in the assembly. Are your DLLs in the Managed folder?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnBundleOpen_Click(object sender, EventArgs e)
        {
            engine.UnloadBundles();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    bundle = engine.LoadBundle(openFileDialog.FileName);
                    afileInst = engine.LoadAssetsFileFromBundle(bundle);

                    UpdateComponentsOnLoad();
                }
            }
        }

        private void btnBundleSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    engine.SaveBundleToFile(bundle, saveFileDialog.FileName);
                    MessageBox.Show("Successfully saved the new bundle!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FormMono_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormMono_FormClosed(object sender, FormClosedEventArgs e)
        {
            bundle = null!;
            afileInst = null!;
            engine.UnloadBundles();
        }
    }
}
