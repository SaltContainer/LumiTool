using LumiTool.Data;

namespace LumiTool.Forms.Popups
{
    public partial class FormShaderSelect : Form
    {
        public Shader Result = null;

        public FormShaderSelect(string materialName, List<Shader> shaders)
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;

            lbText.Text = string.Format("Please select the shader that material {0} uses.", materialName);
            comboShaders.DataSource = shaders;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Result = (Shader)comboShaders.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
