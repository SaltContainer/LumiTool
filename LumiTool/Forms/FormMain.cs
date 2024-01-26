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
        private FormMap mapForm;
        private FormCharacter characterForm;

        public FormMain()
        {
            engine = new LumiToolEngine();

            aboutForm = new FormAbout();
            platformForm = new FormPlatform(engine);
            monoForm = new FormMono(engine);
            mapForm = new FormMap(engine);
            characterForm = new FormCharacter(engine);

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

        private void btnMap_Click(object sender, EventArgs e)
        {
            mapForm.ShowDialog();
        }

        private void btnCharacter_Click(object sender, EventArgs e)
        {
            characterForm.ShowDialog();
        }
    }
}