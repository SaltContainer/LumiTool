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
        private FormBundlePrepper preperForm;
        private FormColorVariation colorVariationForm;
        private FormManifestRefresher manifestRefresherForm;

        public FormMain()
        {
            engine = new LumiToolEngine();

            aboutForm = new FormAbout();
            platformForm = new FormPlatform(engine);
            monoForm = new FormMono(engine);
            preperForm = new FormBundlePrepper(engine);
            colorVariationForm = new FormColorVariation(engine);
            manifestRefresherForm = new FormManifestRefresher(engine);

            InitializeComponent();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            aboutForm.ShowDialog();
        }

        private void btnPlatform_Click(object sender, EventArgs e)
        {
            platformForm.ShowDialog();
        }

        private void btnMono_Click(object sender, EventArgs e)
        {
            monoForm.ShowDialog();
        }

        private void btnPrepper_Click(object sender, EventArgs e)
        {
            preperForm.ShowDialog();
        }

        private void btnColorVariation_Click(object sender, EventArgs e)
        {
            //colorVariationForm.ShowDialog();
            MessageBox.Show("This section is a work in progress.", "WIP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnManifestRefresher_Click(object sender, EventArgs e)
        {
            manifestRefresherForm.ShowDialog();
        }

        private void btnManifestEditor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This section is a work in progress.", "WIP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}