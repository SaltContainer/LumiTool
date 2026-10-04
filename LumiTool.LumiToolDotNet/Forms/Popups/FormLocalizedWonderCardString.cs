using LumiTool.Data;
using LumiTool.Utils;

namespace LumiTool.Forms.Popups
{
    public partial class FormLocalizedWonderCardString : Form
    {
        private const int LANGUAGE_COUNT = 9;

        private BDSPLanguage[] languages = (BDSPLanguage[])Enum.GetValues(typeof(BDSPLanguage));

        public string[] ResultStrings = new string[LANGUAGE_COUNT]
        {
            string.Empty, string.Empty, string.Empty,
            string.Empty, string.Empty, string.Empty,
            string.Empty, string.Empty, string.Empty,
        };

        public BDSPLanguage[] ResultLanguages = new BDSPLanguage[LANGUAGE_COUNT]
        {
            BDSPLanguage.USA, BDSPLanguage.USA, BDSPLanguage.USA,
            BDSPLanguage.USA, BDSPLanguage.USA, BDSPLanguage.USA,
            BDSPLanguage.USA, BDSPLanguage.USA, BDSPLanguage.USA,
        };

        public FormLocalizedWonderCardString(string elementName, int lengthLimit = -1, string[] existingStrings = null, BDSPLanguage[] existingLanguages = null)
        {
            InitializeComponent();

            SetupComboBoxes();
            SetTextBoxLimit(lengthLimit);

            DialogResult = DialogResult.Cancel;

            if (existingStrings != null)
            {
                for (int i=0; i<LANGUAGE_COUNT; i++)
                    ResultStrings[i] = existingStrings[i];
            }

            if (existingLanguages != null)
            {
                for (int i=0; i<LANGUAGE_COUNT; i++)
                    ResultLanguages[i] = existingLanguages[i];
            }

            lbDescription.Text = $"Enter {elementName} in each available language.";

            LoadDataFromArray(ResultStrings, ResultLanguages);
        }

        private void LoadDataFromArray(string[] strings, BDSPLanguage[] languages)
        {
            txtJPN.Text = strings[0];
            txtUSA.Text = strings[1];
            txtFRA.Text = strings[2];
            txtITA.Text = strings[3];
            txtDEU.Text = strings[4];
            txtESP.Text = strings[5];
            txtKOR.Text = strings[6];
            txtSCH.Text = strings[7];
            txtTCH.Text = strings[8];

            comboJPN.SelectedItem = languages[0].GetDescription();
            comboUSA.SelectedItem = languages[1].GetDescription();
            comboFRA.SelectedItem = languages[2].GetDescription();
            comboITA.SelectedItem = languages[3].GetDescription();
            comboDEU.SelectedItem = languages[4].GetDescription();
            comboESP.SelectedItem = languages[5].GetDescription();
            comboKOR.SelectedItem = languages[6].GetDescription();
            comboSCH.SelectedItem = languages[7].GetDescription();
            comboTCH.SelectedItem = languages[8].GetDescription();
        }

        private void SaveDataToResult()
        {
            ResultStrings[0] = txtJPN.Text;
            ResultStrings[1] = txtUSA.Text;
            ResultStrings[2] = txtFRA.Text;
            ResultStrings[3] = txtITA.Text;
            ResultStrings[4] = txtDEU.Text;
            ResultStrings[5] = txtESP.Text;
            ResultStrings[6] = txtKOR.Text;
            ResultStrings[7] = txtSCH.Text;
            ResultStrings[8] = txtTCH.Text;

            ResultLanguages[0] = languages[comboJPN.SelectedIndex];
            ResultLanguages[1] = languages[comboUSA.SelectedIndex];
            ResultLanguages[2] = languages[comboFRA.SelectedIndex];
            ResultLanguages[3] = languages[comboITA.SelectedIndex];
            ResultLanguages[4] = languages[comboDEU.SelectedIndex];
            ResultLanguages[5] = languages[comboESP.SelectedIndex];
            ResultLanguages[6] = languages[comboKOR.SelectedIndex];
            ResultLanguages[7] = languages[comboSCH.SelectedIndex];
            ResultLanguages[8] = languages[comboTCH.SelectedIndex];
        }

        private void SetTextBoxLimit(int lengthLimit)
        {
            if (lengthLimit > 0)
            {
                txtJPN.MaxLength = lengthLimit;
                txtUSA.MaxLength = lengthLimit;
                txtFRA.MaxLength = lengthLimit;
                txtITA.MaxLength = lengthLimit;
                txtDEU.MaxLength = lengthLimit;
                txtESP.MaxLength = lengthLimit;
                txtKOR.MaxLength = lengthLimit;
                txtSCH.MaxLength = lengthLimit;
                txtTCH.MaxLength = lengthLimit;
            }
        }

        private void SetupComboBoxes()
        {
            comboJPN.DataSource = languages.Select(x => x.GetDescription()).ToList();
            comboUSA.DataSource = languages.Select(x => x.GetDescription()).ToList();
            comboFRA.DataSource = languages.Select(x => x.GetDescription()).ToList();
            comboITA.DataSource = languages.Select(x => x.GetDescription()).ToList();
            comboDEU.DataSource = languages.Select(x => x.GetDescription()).ToList();
            comboESP.DataSource = languages.Select(x => x.GetDescription()).ToList();
            comboKOR.DataSource = languages.Select(x => x.GetDescription()).ToList();
            comboSCH.DataSource = languages.Select(x => x.GetDescription()).ToList();
            comboTCH.DataSource = languages.Select(x => x.GetDescription()).ToList();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SaveDataToResult();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtLANG_TextChanged(object sender, EventArgs e)
        {
            var txtSender = sender as TextBox;
            txtSender.Text = txtSender.Text;
        }
    }
}
