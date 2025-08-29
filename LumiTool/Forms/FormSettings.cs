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

            ttSettings.SetToolTip(lbShaderConfigPath, "The path to a Shader Bundles Configuration JSON file.\nDefines the different bundles that contain shaders and their path IDs.\nAn example is provided in LumiTool's Config folder.");
            ttSettings.SetToolTip(lbDependencyRemapConfigPath, "The path to a Dependency Remapping Configuration JSON file.\nDefines common dependencies and their path IDs for bundles that are commonly built.\nAn example is provided in LumiTool's Config folder.");
        }

        private void UpdateComponentsOnStart()
        {
            txtShaderConfigPath.Text = engine.GetShaderConfigPath();
            txtDependencyRemapConfigPath.Text = engine.GetDependencyConfigPath();
        }

        private void UpdateComponentsOnExit()
        {
            txtShaderConfigPath.Text = string.Empty;
            txtDependencyRemapConfigPath.Text = string.Empty;
        }

        private void SaveSettings()
        {
            bool shadersConfigLoaded = engine.SetShaderConfigPath(txtShaderConfigPath.Text);
            bool dependencyConfigLoaded = engine.SetDependencyConfigPath(txtDependencyRemapConfigPath.Text);

            if (shadersConfigLoaded && dependencyConfigLoaded)
            {
                MessageBox.Show("Successfully updated settings!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }  
            else
            {
                if (!shadersConfigLoaded)
                {
                    txtShaderConfigPath.Text = engine.GetShaderConfigPath();
                    MessageBox.Show("There was a problem reading the shaders configuration. It was reverted to the previous configuration.", "Invalid Settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (!dependencyConfigLoaded)
                {
                    txtDependencyRemapConfigPath.Text = engine.GetDependencyConfigPath();
                    MessageBox.Show("There was a problem reading the dependency remapping configuration. It was reverted to the previous configuration.", "Invalid Settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnShaderConfigPath_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                txtShaderConfigPath.Text = openFileDialog.FileName;
        }

        private void btnDependencyRemapConfigPath_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                txtDependencyRemapConfigPath.Text = openFileDialog.FileName;
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
