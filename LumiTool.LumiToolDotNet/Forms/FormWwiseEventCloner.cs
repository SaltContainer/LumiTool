using LumiTool.Data;
using LumiTool.Data.Wwise;
using LumiTool.Engine;

namespace LumiTool.Forms
{
    public partial class FormWwiseEventCloner : Form
    {
        LumiToolEngine engine;

        private static Dictionary<string, BDSPWwiseEventType> eventTypes = new Dictionary<string, BDSPWwiseEventType>()
        {
            { "BGM_FIELD With Intro (D05)",          BDSPWwiseEventType.BGM_FIELD_WITH_INTRO },
            //{ "BGM_FIELD BDSP With Intro (C01_DAY)", BDSPWwiseEventType.BGM_FIELD_BDSP_INTRO },
            //{ "BGM_FIELD DS With Intro (TBD)",       BDSPWwiseEventType.BGM_FIELD_DS_INTRO },
            { "BGM_FIELD No Intro (C01_NIGHT)",      BDSPWwiseEventType.BGM_FIELD_NO_INTRO },
            { "BGM_BATTLE No Intro (BA001)",         BDSPWwiseEventType.BGM_BATTLE_WITH_INTRO },
            { "Pokémon Cry Set (PLAY_PV_001_00_0*)", BDSPWwiseEventType.POKEMON_CRY_SET },
        };

        WwiseData bank;
        string originalPath = string.Empty;

        private Queue<string> infoLogQueue;

        public FormWwiseEventCloner(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;

            infoLogQueue = new Queue<string>();

            comboEventType.Items.Clear();
            comboEventType.Items.AddRange(eventTypes.Keys.ToArray());
        }

        private void UpdateComponentsOnStart()
        {
            infoLogQueue.Clear();

            lbBankName.Text = "Bank Name: " + Path.GetFileName(originalPath);
            txtNewEvent.Enabled = false;
            comboEventType.Enabled = false;
            btnNewEventHash.Enabled = false;
            checkLoop.Enabled = false;
            numRegInitialDelay.Enabled = false;
            numRegLoopStart.Enabled = false;
            numRegLoopEnd.Enabled = false;
            numRegTotalDuration.Enabled = false;
            numDSInitialDelay.Enabled = false;
            numDSLoopStart.Enabled = false;
            numDSLoopEnd.Enabled = false;
            numDSTotalDuration.Enabled = false;
            btnBankSave.Enabled = false;
            btnApply.Enabled = false;

            txtNewEvent.Text = string.Empty;

            numRegInitialDelay.Value = 0;
            numRegLoopStart.Value = 0;
            numRegLoopEnd.Value = 0;
            numRegTotalDuration.Value = 0;

            ttWwiseBankCloner.SetToolTip(lbBankName, "");
        }

        private void UpdateComponentsOnLoad()
        {
            lbBankName.Text = "Bank Name: " + Path.GetFileName(originalPath);
            txtNewEvent.Enabled = true;
            comboEventType.Enabled = true;
            btnNewEventHash.Enabled = true;
            checkLoop.Enabled = true;
            numRegInitialDelay.Enabled = checkLoop.Checked;
            numRegLoopStart.Enabled = checkLoop.Checked;
            numRegLoopEnd.Enabled = checkLoop.Checked;
            numRegTotalDuration.Enabled = checkLoop.Checked;
            numDSInitialDelay.Enabled = checkLoop.Checked;
            numDSLoopStart.Enabled = checkLoop.Checked;
            numDSLoopEnd.Enabled = checkLoop.Checked;
            numDSTotalDuration.Enabled = checkLoop.Checked;
            btnBankSave.Enabled = true;
            btnApply.Enabled = true;

            comboEventType.SelectedIndex = 0;

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

        private void LogReceiver(string message, LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Information:
                    infoLogQueue.Enqueue(message);
                    break;

                case LogLevel.Warning:
                    MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case LogLevel.Error:
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void ShowInfoPopup()
        {
            MessageBox.Show(string.Join("\n", infoLogQueue), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            infoLogQueue.Clear();
        }

        private WwiseLoopPointData GenerateLoopData()
        {
            WwiseLoopPointData loopData = null;
            if (checkLoop.Checked)
            {
                loopData = new WwiseLoopPointData()
                {
                    InitialDelay = (double)numRegInitialDelay.Value,
                    LoopStart = (double)numRegLoopStart.Value,
                    LoopEnd = (double)numRegLoopEnd.Value,
                    TotalSourceLength = (double)numRegTotalDuration.Value,
                };
            }
            return loopData;
        }

        private WwiseLoopPointData GenerateDSLoopData()
        {
            WwiseLoopPointData loopData = null;
            if (checkLoop.Checked)
            {
                loopData = new WwiseLoopPointData()
                {
                    InitialDelay = (double)numDSInitialDelay.Value,
                    LoopStart = (double)numDSLoopStart.Value,
                    LoopEnd = (double)numDSLoopEnd.Value,
                    TotalSourceLength = (double)numDSTotalDuration.Value,
                };
            }
            return loopData;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                engine.AddOnLogCallback(LogReceiver);
                if (engine.MakeNewBDSPWwiseEvent(bank, eventTypes[(string)comboEventType.SelectedItem], txtNewEvent.Text, GenerateLoopData(), GenerateDSLoopData()))
                {
                    MessageBox.Show("Successfully cloned an event. Don't forget to save your bank!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ShowInfoPopup();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while cloning the event. Full exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                engine.RemoveOnLogCallback(LogReceiver);
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
                    engine.WriteLinesToFile(saveFileDialog.FileName + ".log", infoLogQueue.ToList());
                    infoLogQueue.Clear();
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

        private void btnNewEventHash_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"The hash for \"{txtNewEvent.Text}\" is {CalculateHash(txtNewEvent.Text)}.", "FNV132 Hash", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkLoop_CheckedChanged(object sender, EventArgs e)
        {
            numRegInitialDelay.Enabled = checkLoop.Checked;
            numRegLoopStart.Enabled = checkLoop.Checked;
            numRegLoopEnd.Enabled = checkLoop.Checked;
            numRegTotalDuration.Enabled = checkLoop.Checked;
            numDSInitialDelay.Enabled = checkLoop.Checked;
            numDSLoopStart.Enabled = checkLoop.Checked;
            numDSLoopEnd.Enabled = checkLoop.Checked;
            numDSTotalDuration.Enabled = checkLoop.Checked;
        }
    }
}
