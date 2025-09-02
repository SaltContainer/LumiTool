using LumiTool.Engine;

namespace LumiTool.Forms
{
    public partial class FormSettings : Form
    {
        LumiToolEngine engine;

        bool IsDependencyConfigSet => txtDependencyRemapConfigPath.Text != string.Empty;

        public FormSettings(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;

            ttSettings.SetToolTip(lbDependencyRemapConfigPath, "The path to a Dependency Remapping Configuration JSON file.\nDefines the path IDs for assets in bundles that are referenced by\nbundles that need to be prepped uwing the Bundle Prepper.\nAn example is provided in LumiTool's Config folder.");
        }

        private void UpdateComponentsOnStart()
        {
            txtDependencyRemapConfigPath.Text = engine.GetDependencyConfigPath();
        }

        private void UpdateComponentsOnExit()
        {
            txtDependencyRemapConfigPath.Text = string.Empty;
        }

        private void SaveSettings()
        {
            bool dependencyConfigLoaded = engine.SetDependencyConfigPath(txtDependencyRemapConfigPath.Text);

            if (dependencyConfigLoaded)
            {
                MessageBox.Show("Successfully updated settings!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }  
            else
            {
                if (!dependencyConfigLoaded)
                {
                    txtDependencyRemapConfigPath.Text = engine.GetDependencyConfigPath();
                    MessageBox.Show("There was a problem reading the dependency remapping configuration. It was reverted to the previous configuration.", "Invalid Settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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
