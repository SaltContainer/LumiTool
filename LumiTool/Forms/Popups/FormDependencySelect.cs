namespace LumiTool.Forms.Popups
{
    public partial class FormDependencySelect : Form
    {
        public List<string> Result = new List<string>();

        public FormDependencySelect(List<string> cabs)
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;
            listDependencies.DataSource = cabs;

            for (int i=0; i< listDependencies.Items.Count; i++)
                listDependencies.SetItemChecked(i, true);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Result.Clear();
            
            foreach (var item in listDependencies.CheckedItems)
                Result.Add((string)item);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
