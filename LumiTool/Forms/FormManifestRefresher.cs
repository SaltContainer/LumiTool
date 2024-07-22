using LumiTool.Engine;
using SmartPoint.AssetAssistant;

namespace LumiTool.Forms
{
    public partial class FormManifestRefresher : Form
    {
        LumiToolEngine engine;
        AssetBundleDownloadManifest manifest;

        public FormManifestRefresher(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;
        }

        private void UpdateComponentsOnStart()
        {
            lbManifestName.Text = "Manifest Name: ";
            btnManifestSave.Enabled = false;
        }

        private void UpdateComponentsOnLoad()
        {
            lbManifestName.Text = "Manifest Name: " + manifest.projectName;
            btnManifestSave.Enabled = true;
        }

        private void btnManifestOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    manifest = engine.LoadManifest(openFileDialog.FileName);
                    UpdateComponentsOnLoad();
                }
            }
        }

        private void btnManifestSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    engine.SaveManifest(manifest, saveFileDialog.FileName);
                    MessageBox.Show("Successfully saved the new manifest!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FormManifestRefresher_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormManifestRefresher_FormClosed(object sender, FormClosedEventArgs e)
        {
            manifest = null;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            foreach (var record in manifest.records)
                record.size = -1;
        }
    }
}
