using LumiTool.Data.Wwise;
using LumiTool.Engine;

namespace LumiTool.Forms
{
    public partial class FormWwiseEventBrowser : Form
    {
        LumiToolEngine engine;

        WwiseData bank;
        string originalPath = string.Empty;

        public FormWwiseEventBrowser(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;
        }

        private void UpdateComponentsOnStart()
        {
            lbBankName.Text = "Bank Name: " + Path.GetFileName(originalPath);
            listEvents.Enabled = false;
            listActions.Enabled = false;

            ClearListBoxes();

            ttWwiseEventBrowser.SetToolTip(lbBankName, "");
        }

        private void UpdateComponentsOnLoad()
        {
            lbBankName.Text = "Bank Name: " + Path.GetFileName(originalPath);
            listEvents.Enabled = true;
            listActions.Enabled = true;

            AddEventsToListBox();

            ttWwiseEventBrowser.SetToolTip(lbBankName, originalPath);
        }

        private void ClearListBoxes()
        {
            listEvents.Items.Clear();
            listActions.Items.Clear();
        }

        private void AddEventsToListBox()
        {
            listEvents.Items.Clear();
            var events = engine.GetEventsOfBank(bank);
            foreach (var ev in events)
                listEvents.Items.Add(ev);
        }

        private void AddActionsToListBox(Event ev)
        {
            listActions.Items.Clear();
            var actions = engine.GetActionsOfEvent(bank, ev);
            foreach (var action in actions)
                listActions.Items.Add(action);
        }

        private void OpenBank(string path)
        {
            originalPath = path;
            bank = engine.LoadBank(path);
            UpdateComponentsOnLoad();
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

        private void FormWwiseEventBrowser_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormWwiseEventBrowser_FormClosed(object sender, FormClosedEventArgs e)
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
                MessageBox.Show("Multiple files were dragged into the tool. The Wwise Event Browser only supports one file at a time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                OpenBank(files[0]);
        }

        private void listEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddActionsToListBox(listEvents.SelectedItem as Event);
        }
    }
}
