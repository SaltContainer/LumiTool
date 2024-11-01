using LumiTool.Engine;
using SmartPoint.AssetAssistant;
using System.ComponentModel;

namespace LumiTool.Forms
{
    public partial class FormManifestEditor : Form
    {
        LumiToolEngine engine;
        AssetBundleDownloadManifest manifest = null;
        BindingList<AssetBundleRecord> records;

        string ManifestPath => manifest?.projectName ?? string.Empty;
        AssetBundleRecord SelectedRecord => (AssetBundleRecord)listRecords.SelectedItem;
        string SelectedDependency => (string)listDependencies.SelectedItem;
        string SelectedAssetPath => (string)listAssetPaths.SelectedItem;

        public FormManifestEditor(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;

            records = new BindingList<AssetBundleRecord>();
        }

        private void UpdateComponentsOnStart()
        {
            lbManifestName.Text = "Manifest Name: ";
            btnManifestSave.Enabled = false;

            ClearControls();
            ToggleControls(false);
        }

        private void UpdateComponentsOnLoad()
        {
            CreateRecordList();
            AddBindings();
            UpdateRecordList();
            UpdateRecordEditing(SelectedRecord);

            lbManifestName.Text = "Manifest Name: " + ManifestPath;
            ttManifestEditor.SetToolTip(lbManifestName, ManifestPath);
            ToggleControls(CheckAllLoaded());
        }

        private void ToggleControls(bool state)
        {
            btnManifestSave.Enabled = state;

            listRecords.Enabled = state;
            txtProjectName.Enabled = state;
            txtBundleName.Enabled = state;
            checkStreamingScene.Enabled = state;
            numSize.Enabled = state;

            listDependencies.Enabled = state;
            txtDependencyName.Enabled = state;
            btnAddDependency.Enabled = state;
            btnRemoveDependency.Enabled = state;

            listAssetPaths.Enabled = state;
            txtAssetPath.Enabled = state;
            btnAddAssetPath.Enabled = state;
            btnRemoveAssetPath.Enabled = state;
        }

        private void ClearControls()
        {
            listRecords.DataSource = null;
            
            txtProjectName.Text = string.Empty;
            txtBundleName.Text = string.Empty;
            checkStreamingScene.Checked = false;
            numSize.Value = 0;

            listDependencies.DataSource = null;
            txtDependencyName.Text = string.Empty;

            listAssetPaths .DataSource = null;
            txtAssetPath.Text = string.Empty;
        }

        private bool CheckAllLoaded()
        {
            return manifest != null;
        }

        private void CreateRecordList()
        {
            records.Clear();
            records = new BindingList<AssetBundleRecord>(manifest.records.ToList());
        }

        private void ApplyRecordListChanges()
        {
            engine.ReplaceAllRecordsOfManifest(manifest, records.ToArray());
        }

        private void AddBindings()
        {
            listRecords.DataSource = records;
            listRecords.DisplayMember = "AssetBundleName";
        }

        private void UpdateRecordList()
        {
            records.ResetBindings();
        }

        private void UpdateDependenciesOfRecordList(AssetBundleRecord record)
        {
            var deps = new BindingList<string>(record.allDependencies);
            listDependencies.DataSource = deps;
        }

        private void UpdateAssetPathsOfRecordList(AssetBundleRecord record)
        {
            var assetPaths = new BindingList<string>(record.assetPaths);
            listAssetPaths.DataSource = assetPaths;
        }

        private void UpdateRecordEditing(AssetBundleRecord record)
        {
            if (record == null)
                return;

            txtProjectName.Text = record.projectName;
            txtBundleName.Text = record.assetBundleName;
            checkStreamingScene.Checked = record.isStreamingSceneAssetBundle;
            numSize.Value = record.size;

            UpdateDependenciesOfRecordList(record);
            UpdateAssetPathsOfRecordList(record);
        }

        private void UpdateDependencyEditing(string dependency)
        {
            txtDependencyName.Text = dependency;
        }

        private void UpdateAssetPathEditing(string assetPath)
        {
            txtAssetPath.Text = assetPath;
        }

        private void btnManifestOpen_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    manifest = engine.LoadManifest(openFileDialog.FileName);
                    UpdateComponentsOnLoad();
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
                    ApplyRecordListChanges();
                    engine.SaveManifest(manifest, saveFileDialog.FileName);

                    MessageBox.Show("Successfully saved the new manifest!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error while saving the new manifest. Full exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormManifestEditor_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormManifestEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            manifest = null;
            records.Clear();
        }

        private void listRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRecordEditing(SelectedRecord);
        }

        private void listDependencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDependencyEditing((string)listDependencies.SelectedItem);
        }

        private void listAssetPaths_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAssetPathEditing((string)listAssetPaths.SelectedItem);
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            AssetBundleRecord record = new AssetBundleRecord
            {
                projectName = ManifestPath,
                assetBundleName = "new/bundle/name",
                hash = new RecordedHash(1, 1, 1, 1),
                lastWriteTime = DateTime.Now,
                isStreamingSceneAssetBundle = false,
                allDependencies = Array.Empty<string>(),
                assetPaths = Array.Empty<string>(),
                size = -1,
            };

            records.Add(record);
            UpdateRecordList();
            listRecords.SelectedIndex = records.Count - 1;
            UpdateRecordEditing(record);
        }

        private void btnRemoveRecord_Click(object sender, EventArgs e)
        {
            records.Remove(SelectedRecord);
            UpdateRecordList();
            UpdateRecordEditing(SelectedRecord);
        }

        private void btnAddDependency_Click(object sender, EventArgs e)
        {
            SelectedRecord.allDependencies = SelectedRecord.allDependencies.Append(txtDependencyName.Text).ToArray();
            UpdateRecordEditing(SelectedRecord);
            listDependencies.SelectedIndex = listDependencies.Items.Count - 1;
        }

        private void btnRemoveDependency_Click(object sender, EventArgs e)
        {
            if (listDependencies.Items.Count == 0)
                return;

            SelectedRecord.allDependencies = SelectedRecord.allDependencies.Select((x, i) => (x, i)).Where((x, i) => i != listDependencies.SelectedIndex).Select(y => y.x).ToArray();
            UpdateDependenciesOfRecordList(SelectedRecord);
        }

        private void btnAddAssetPath_Click(object sender, EventArgs e)
        {
            SelectedRecord.assetPaths = SelectedRecord.assetPaths.Append(txtAssetPath.Text).ToArray();
            UpdateRecordEditing(SelectedRecord);
            listAssetPaths.SelectedIndex = listAssetPaths.Items.Count - 1;
        }

        private void btnRemoveAssetPath_Click(object sender, EventArgs e)
        {
            if (listAssetPaths.Items.Count == 0)
                return;

            SelectedRecord.assetPaths = SelectedRecord.assetPaths.Select((x, i) => (x, i)).Where((x, i) => i != listAssetPaths.SelectedIndex).Select(y => y.x).ToArray();
            UpdateAssetPathsOfRecordList(SelectedRecord);
        }
    }
}
