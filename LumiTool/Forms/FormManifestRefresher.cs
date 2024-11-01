using LumiTool.Engine;
using SmartPoint.AssetAssistant;

namespace LumiTool.Forms
{
    public partial class FormManifestRefresher : Form
    {
        LumiToolEngine engine;
        AssetBundleDownloadManifest manifest = null;
        string moddedPath = string.Empty;
        string vanillaPath = string.Empty;

        string ManifestPath => manifest?.projectName ?? string.Empty;

        public FormManifestRefresher(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;
        }

        private void UpdateComponentsOnStart()
        {
            lbManifestName.Text = "Manifest Name: ";
            lbModPath.Text = "Path: ";
            lbVanillaPath.Text = "Path: ";
            btnManifestSave.Enabled = false;
            btnRefresh.Enabled = false;
        }

        private void UpdateComponentsOnLoad()
        {
            lbManifestName.Text = "Manifest Name: " + ManifestPath;
            ttManifestRefresher.SetToolTip(lbManifestName, ManifestPath);
            lbModPath.Text = "Path: " + moddedPath;
            ttManifestRefresher.SetToolTip(lbModPath, moddedPath);
            lbVanillaPath.Text = "Path: " + vanillaPath;
            ttManifestRefresher.SetToolTip(lbVanillaPath, vanillaPath);
            btnManifestSave.Enabled = CheckAllLoaded();
            btnRefresh.Enabled = CheckAllLoaded();
        }

        private bool CheckAllLoaded()
        {
            return manifest != null && moddedPath != string.Empty && vanillaPath != string.Empty;
        }

        private void OpenManifest(string path)
        {
            manifest = engine.LoadManifest(path);
            UpdateComponentsOnLoad();
        }

        private void btnManifestOpen_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OpenManifest(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error while loading the manifest. Full exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnManifestSave_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    engine.SaveManifest(manifest, saveFileDialog.FileName);
                    MessageBox.Show("Successfully saved the new manifest!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error while saving the new manifest. Full exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModOpen_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string assetAssistantPath = engine.FindAssetAssistantPath(folderBrowserDialog.SelectedPath);
                if (assetAssistantPath == null)
                {
                    MessageBox.Show("Could not find the AssetAssistant folder in the RomFS. Make sure it can be found at either \".../Data/StreamingAssets/AssetAssistant\" or \".../StreamingAssets/AssetAssistant\".", "Bad path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    moddedPath = assetAssistantPath;
                    UpdateComponentsOnLoad();
                }
            }
        }

        private void btnVanillaOpen_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string assetAssistantPath = engine.FindAssetAssistantPath(folderBrowserDialog.SelectedPath);
                if (assetAssistantPath == null)
                {
                    MessageBox.Show("Could not find the AssetAssistant folder in the RomFS. Make sure it can be found at either \".../Data/StreamingAssets/AssetAssistant\" or \".../StreamingAssets/AssetAssistant\".", "Bad path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    vanillaPath = assetAssistantPath;
                    UpdateComponentsOnLoad();
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
            moddedPath = string.Empty;
            vanillaPath = string.Empty;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                engine.RefreshManifest(manifest, moddedPath, vanillaPath);
                MessageBox.Show("Successfully refreshed the manifest. Don't forget to save your manifest!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an exception when refreshing the manifest. Full Exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManifestOpen_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void btnManifestOpen_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 1)
                MessageBox.Show("Multiple files were dragged into the tool. The Manifest Refresher only supports one file at a time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                OpenManifest(files[0]);
        }
    }
}
