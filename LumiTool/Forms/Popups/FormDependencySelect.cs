using LumiTool.Data;

namespace LumiTool.Forms.Popups
{
    public partial class FormDependencySelect : Form
    {
        public List<DependencyBundle> Result = new List<DependencyBundle>();

        public FormDependencySelect(List<DependencyBundle> bundles)
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;
            listDependencies.DataSource = bundles;

            for (int i=0; i<listDependencies.Items.Count; i++)
                listDependencies.SetItemChecked(i, true);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Result.Clear();
            
            foreach (var item in listDependencies.CheckedItems)
                Result.Add((DependencyBundle)item);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
