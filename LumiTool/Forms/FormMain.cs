using LumiTool.Engine;
using LumiTool.Forms;

namespace LumiTool
{
    public partial class FormMain : Form
    {
        private LumiToolEngine engine;

        private FormAbout aboutForm;
        private FormSettings settingsForm;

        private FormPlatform platformForm;
        private FormMono monoForm;
        private FormBundlePrepper prepperForm;
        private FormBundlePrepperMass massPrepperForm;
        private FormColorVariation colorVariationForm;
        private FormManifestRefresher manifestRefresherForm;
        private FormManifestEditor manifestEditorForm;
        private FormShaderPathIDFixer shaderPathIDFixerForm;
        private FormRenameBundle bundleRenamerForm;
        private FormWwiseEventCloner wwiseBankClonerForm;
        private FormWwiseEventBrowser wwiseEventBrowserForm;

        public FormMain()
        {
            engine = new LumiToolEngine();

            aboutForm = new FormAbout();
            settingsForm = new FormSettings(engine);
            settingsForm.FormClosed += (sender, e) => UpdateComponentsOnSettingsChanged();

            platformForm = new FormPlatform(engine);
            monoForm = new FormMono(engine);
            prepperForm = new FormBundlePrepper(engine);
            massPrepperForm = new FormBundlePrepperMass(engine);
            colorVariationForm = new FormColorVariation(engine);
            manifestRefresherForm = new FormManifestRefresher(engine);
            manifestEditorForm = new FormManifestEditor(engine);
            shaderPathIDFixerForm = new FormShaderPathIDFixer(engine);
            bundleRenamerForm = new FormRenameBundle(engine);
            wwiseBankClonerForm = new FormWwiseEventCloner(engine);
            wwiseEventBrowserForm = new FormWwiseEventBrowser(engine);

            InitializeComponent();

            LoadSettings();
        }

        private void LoadSettings()
        {
            engine.TryReloadShaderConfig();
            engine.TryReloadDependencyConfig();

            UpdateComponentsOnSettingsChanged();
        }

        private void ToggleShaderConfigRequirements(bool enabled)
        {
            btnPrepper.Enabled = enabled;
            btnPrepperMass.Enabled = enabled;
        }

        private void UpdateComponentsOnSettingsChanged()
        {
            ToggleShaderConfigRequirements(engine.IsShaderConfigLoaded());
        }

        private void CheckForUnloadedWarning()
        {
            if (!engine.IsShaderConfigLoaded())
                MessageBox.Show("There was a problem reading the shaders configuration. Certain features won't be available until a valid configuration is set in the settings.", "Invalid Settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void SetFirstBootSettings()
        {
            MessageBox.Show("Hello! Since this is your first time using LumiTool, you'll have to set a few settings before you're ready to go.", "New User", MessageBoxButtons.OK, MessageBoxIcon.Information);
            engine.SetFirstBootConfig();
            settingsForm.ShowDialog(this);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            aboutForm.ShowDialog(this);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog(this);
        }

        private void btnPlatform_Click(object sender, EventArgs e)
        {
            platformForm.ShowDialog(this);
        }

        private void btnMono_Click(object sender, EventArgs e)
        {
            monoForm.ShowDialog(this);
        }

        private void btnPrepper_Click(object sender, EventArgs e)
        {
            prepperForm.ShowDialog(this);
        }

        private void btnPrepperMass_Click(object sender, EventArgs e)
        {
            massPrepperForm.ShowDialog(this);
        }

        private void btnColorVariation_Click(object sender, EventArgs e)
        {
            //colorVariationForm.ShowDialog(this);
            MessageBox.Show("This section is a work in progress.", "WIP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnManifestRefresher_Click(object sender, EventArgs e)
        {
            manifestRefresherForm.ShowDialog(this);
        }

        private void btnManifestEditor_Click(object sender, EventArgs e)
        {
            manifestEditorForm.ShowDialog(this);
        }

        private void btnShaderPathIDFixer_Click(object sender, EventArgs e)
        {
            shaderPathIDFixerForm.ShowDialog(this);
        }

        private void btnBundleRenamer_Click(object sender, EventArgs e)
        {
            bundleRenamerForm.ShowDialog(this);
        }

        private void btnWwiseBankCloner_Click(object sender, EventArgs e)
        {
            wwiseBankClonerForm.ShowDialog(this);
        }

        private void btnWwiseEventBrowser_Click(object sender, EventArgs e)
        {
            wwiseEventBrowserForm.ShowDialog(this);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            if (engine.UserConfigExists())
                CheckForUnloadedWarning();
            else
                SetFirstBootSettings();
        }
    }
}