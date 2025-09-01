using LumiTool.Data;

namespace LumiTool.Forms.Popups
{
    public partial class FormDependencyAssetSelect : Form
    {
        public DependencyAsset Result = null;

        public FormDependencyAssetSelect(string assetName, string fieldName, List<DependencyAsset> assets)
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;

            lbText.Text = $"Please select the asset referenced by {assetName} at \"{fieldName}\".";
            comboAssets.DataSource = assets;
        }

        public FormDependencyAssetSelect(string assetName, string fieldName, string bundleName, List<DependencyAsset> assets)
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;

            lbText.Text = $"Please select the asset referenced by {assetName} at \"{fieldName}\" in bundle \"{bundleName}\".";
            comboAssets.DataSource = assets;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Result = (DependencyAsset)comboAssets.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
