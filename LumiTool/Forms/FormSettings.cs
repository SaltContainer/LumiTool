using LumiTool.Engine;

namespace LumiTool.Forms
{
    public partial class FormSettings : Form
    {
        LumiToolEngine engine;

        public FormSettings(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;

            ttSettings.SetToolTip(lbShaderConfigPath, "The path to a Shader Bundles Configuration JSON file.\nAn example is provided in LumiTool's Config folder.");
        }

        private void UpdateComponentsOnStart()
        {
            txtShaderConfigPath.Text = engine.GetShaderConfigPath();
        }

        private void UpdateComponentsOnExit()
        {
            txtShaderConfigPath.Text = string.Empty;
        }

        private void SaveSettings()
        {
            if (engine.SetShaderConfigPath(txtShaderConfigPath.Text))
                MessageBox.Show("Successfully updated the shaders configuration!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                txtShaderConfigPath.Text = engine.GetShaderConfigPath();
                MessageBox.Show("There was a problem reading the shaders configuration. It was reverted to the previous configuration.", "Invalid Settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnShaderConfigPath_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                txtShaderConfigPath.Text = openFileDialog.FileName;
        }

        private void FormSettings_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateComponentsOnExit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }
    }
}
