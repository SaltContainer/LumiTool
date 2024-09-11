using LumiTool.Engine;
using LumiTool.Forms;

namespace LumiTool
{
    public partial class FormMain : Form
    {
        private LumiToolEngine engine;

        private FormAbout aboutForm;
        private FormPlatform platformForm;
        private FormMono monoForm;
        private FormBundlePrepper prepperForm;
        private FormBundlePrepperMass massPrepperForm;
        private FormColorVariation colorVariationForm;
        private FormManifestRefresher manifestRefresherForm;
        private FormShaderPathIDFixer shaderPathIDFixerForm;
        private FormRenameBundle bundleRenamerForm;

        public FormMain()
        {
            engine = new LumiToolEngine();

            aboutForm = new FormAbout();
            platformForm = new FormPlatform(engine);
            monoForm = new FormMono(engine);
            prepperForm = new FormBundlePrepper(engine);
            massPrepperForm = new FormBundlePrepperMass(engine);
            colorVariationForm = new FormColorVariation(engine);
            manifestRefresherForm = new FormManifestRefresher(engine);
            shaderPathIDFixerForm = new FormShaderPathIDFixer(engine);
            bundleRenamerForm = new FormRenameBundle(engine);

            InitializeComponent();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            aboutForm.ShowDialog(this);
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
            MessageBox.Show("This section is a work in progress.", "WIP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnShaderPathIDFixer_Click(object sender, EventArgs e)
        {
            shaderPathIDFixerForm.ShowDialog(this);
        }

        private void btnBundleRenamer_Click(object sender, EventArgs e)
        {
            bundleRenamerForm.ShowDialog(this);
        }
    }
}