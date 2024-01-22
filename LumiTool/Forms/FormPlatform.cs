using AssetsTools.NET.Extra;
using LumiTool.Data;
using LumiTool.Engine;

namespace LumiTool.Forms
{
    public partial class FormPlatform : Form
    {
        LumiToolEngine engine;
        BundleFileInstance bundle = null!;
        AssetsFileInstance afileInst = null!;

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
                    engine.SetPlatformOfBundle(bundle, afileInst, (Platform)comboPlatform.SelectedItem);
                    engine.SaveBundleToFile(bundle, saveFileDialog.FileName);
                    MessageBox.Show("Successfully saved the new bundle!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FormPlatform_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormPlatform_FormClosed(object sender, FormClosedEventArgs e)
        {
            bundle = null!;
            afileInst = null!;
            engine.UnloadBundles();
        }
    }
}
