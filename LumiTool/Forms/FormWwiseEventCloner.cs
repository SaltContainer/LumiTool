using LumiTool.Data.Wwise;
using LumiTool.Engine;

namespace LumiTool.Forms
{
    public partial class FormWwiseEventCloner : Form
    {
        LumiToolEngine engine;

        WwiseData bank;
        string originalPath = string.Empty;

        public FormWwiseEventCloner(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;
        }

        private void UpdateComponentsOnStart()
        {
            lbBankName.Text = "Bank Name: " + Path.GetFileName(originalPath);
            txtOldEvent.Enabled = false;
            txtNewEvent.Enabled = false;
            txtGroup.Enabled = false;
            btnOldEventHash.Enabled = false;
            btnNewEventHash.Enabled = false;
            btnGroupHash.Enabled = false;
            checkLoop.Enabled = false;
            numInitialDelay.Enabled = false;
            numLoopStart.Enabled = false;
            numLoopEnd.Enabled = false;
            numTotalDuration.Enabled = false;
            btnBankSave.Enabled = false;
            btnApply.Enabled = false;

            txtOldEvent.Text = string.Empty;
            txtNewEvent.Text = string.Empty;
            txtGroup.Text = string.Empty;

            numInitialDelay.Value = 0;
            numLoopStart.Value = 0;
            numLoopEnd.Value = 0;
            numTotalDuration.Value = 0;

            ttWwiseBankCloner.SetToolTip(lbBankName, "");
        }

        private void UpdateComponentsOnLoad()
        {
            lbBankName.Text = "Bank Name: " + Path.GetFileName(originalPath);
            txtOldEvent.Enabled = true;
            txtNewEvent.Enabled = true;
            txtGroup.Enabled = true;
            btnOldEventHash.Enabled = true;
            btnNewEventHash.Enabled = true;
            btnGroupHash.Enabled = true;
            checkLoop.Enabled = true;
            numInitialDelay.Enabled = checkLoop.Checked;
            numLoopStart.Enabled = checkLoop.Checked;
            numLoopEnd.Enabled = checkLoop.Checked;
            numTotalDuration.Enabled = checkLoop.Checked;
            btnBankSave.Enabled = true;
            btnApply.Enabled = true;

            ttWwiseBankCloner.SetToolTip(lbBankName, originalPath);
        }

        private void OpenBank(string path)
        {
            originalPath = path;
            bank = engine.LoadBank(path);
            UpdateComponentsOnLoad();
        }

        private uint CalculateHash(string eventName)
        {
            return engine.FNV132Hash(eventName);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                engine.CloneHircEvent(bank, txtOldEvent.Text, txtNewEvent.Text, txtGroup.Text, checkLoop.Checked, (double)numInitialDelay.Value, (double)numLoopStart.Value, (double)numLoopEnd.Value, (double)numTotalDuration.Value);
                MessageBox.Show("Successfully cloned an event. Don't forget to save your bank!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while cloning the event. Full exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBankOpen_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OpenBank(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error while loading the bank. Full exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBankSave_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    engine.SaveBank(bank, saveFileDialog.FileName);
                    MessageBox.Show("Successfully saved the new bank!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error while saving the new bank. Full exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormWwiseBankCloner_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormWwiseBankCloner_FormClosed(object sender, FormClosedEventArgs e)
        {
            bank = null;
            originalPath = string.Empty;
        }

        private void btnBankOpen_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void btnBankOpen_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 1)
                MessageBox.Show("Multiple files were dragged into the tool. The Wwise Event Cloner only supports one file at a time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                OpenBank(files[0]);
        }

        private void btnOldEventHash_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"The hash for \"{txtOldEvent.Text}\" is {CalculateHash(txtOldEvent.Text)}.", "FNV132 Hash", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNewEventHash_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"The hash for \"{txtNewEvent.Text}\" is {CalculateHash(txtNewEvent.Text)}.", "FNV132 Hash", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGroupHash_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"The hash for \"{txtGroup.Text}\" is {CalculateHash(txtGroup.Text)}.", "FNV132 Hash", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkLoop_CheckedChanged(object sender, EventArgs e)
        {
            numInitialDelay.Enabled = checkLoop.Checked;
            numLoopStart.Enabled = checkLoop.Checked;
            numLoopEnd.Enabled = checkLoop.Checked;
            numTotalDuration.Enabled = checkLoop.Checked;
        }
    }
}
