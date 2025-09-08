using LumiTool.Engine;

namespace LumiTool.Forms
{
    public partial class FormColorVariation : Form
    {
        LumiToolEngine engine;

        public FormColorVariation(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;
        }

        private void UpdateComponentsOnStart()
        {
            
        }

        private void UpdateComponentsOnLoadCommon()
        {
            
        }

        private void UpdateComponentsOnLoadEditing()
        {
            UpdateComponentsOnLoadCommon();
        }

        private void btnBundleOpen_Click(object sender, EventArgs e)
        {

        }

        private void btnBundleSave_Click(object sender, EventArgs e)
        {

        }
    }
}
