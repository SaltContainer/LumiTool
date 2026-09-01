using LumiTool.Engine;
using System.Text.Json.Nodes;

namespace LumiTool
{
    public partial class FormReLumiSaveMigration : Form
    {
        LumiToolEngine engine;
        JsonNode saveFile = null;

        private ReLumiSaveVersion[] versions = (ReLumiSaveVersion[])Enum.GetValues(typeof(ReLumiSaveVersion));

        public FormReLumiSaveMigration(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;

            comboVersion.DataSource = versions.Select(x => x.GetDescription()).ToList();
        }

        private void UpdateComponentsOnStart()
        {
            lbSaveFileName.Text = "Save File Name: ";
            btnSaveFileSave.Enabled = false;
            comboVersion.Enabled = false;
            comboVersion.SelectedIndex = 0;
        }

        private void UpdateComponentsOnLoad(string saveFileName)
        {
            lbSaveFileName.Text = "Save File Name: " + saveFileName;
            btnSaveFileSave.Enabled = true;
            comboVersion.Enabled = true;
            comboVersion.SelectedItem = 0;
        }

        private void OpenSaveFile(string path)
        {
            try
            {
                saveFile = engine.LoadJsonReLumiSaveFile(path);
                UpdateComponentsOnLoad(Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occured while loading the file. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveFileOpen_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                OpenSaveFile(openFileDialog.FileName);
        }

        private void btnSaveFileSave_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    engine.MigrateReLumiSaveFile(saveFile, versions[comboVersion.SelectedIndex]);
                    engine.SaveReLumiSaveToFile(saveFileDialog.FileName, saveFile);
                    MessageBox.Show("Successfully migrated the save file!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An exception occured while migrating and saving the file. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormReLumiSaveMigration_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormReLumiSaveMigration_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveFile = null;
        }

        private void btnSaveFileOpen_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void btnSaveFileOpen_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 1)
                MessageBox.Show("Multiple files were dragged into the tool. You can only migrate one file at a time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                OpenSaveFile(files[0]);
        }
    }
}
