using LumiTool.Data.Wwise;
using LumiTool.Engine;
using LumiTool.Forms.WwiseActions;

namespace LumiTool.Forms
{
    public partial class FormWwiseEventBrowser : Form
    {
        private readonly List<(Type type, ushort id)> actionTypes = new List<(Type, ushort)>()
        {
            (typeof(ActionStop), 258),
            (typeof(ActionStop), 259),
            (typeof(ActionStop), 260),
            (typeof(ActionPause), 514),
            (typeof(ActionPause), 515),
            (typeof(ActionPause), 516),
            (typeof(ActionResume), 770),
            (typeof(ActionResume), 772),
            (typeof(ActionPlay), 1027),
            (typeof(ActionMute), 1538),
            (typeof(ActionMute), 1794),
            (typeof(ActionSetAkProp), 2562),
            (typeof(ActionSetAkProp), 2818),
            (typeof(ActionSetAkProp), 3074),
            (typeof(ActionSetAkProp), 3075),
            (typeof(ActionSetAkProp), 3330),
            (typeof(ActionSetAkProp), 3332),
            (typeof(ActionSetState), 4612),
            (typeof(ActionSetGameParameter), 4866),
            (typeof(ActionSetGameParameter), 4867),
            (typeof(ActionSetGameParameter), 5122),
            (typeof(ActionSetGameParameter), 5123),
            (typeof(ActionSetSwitch), 6401),
            (typeof(ActionPlayEvent), 8451),
        };

        LumiToolEngine engine;

        WwiseData bank;
        string originalPath = string.Empty;

        public FormWwiseEventBrowser(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;

            comboActions.DataSource = actionTypes.Select(x => $"{x.type.ToString().Split(".").Last()} ({x.id})").ToList();
        }

        private void UpdateComponentsOnStart()
        {
            lbBankName.Text = "Bank Name: " + Path.GetFileName(originalPath);
            listEvents.Enabled = false;
            listActions.Enabled = false;
            comboActions.Enabled = false;
            btnAddAction.Enabled = false;
            btnRemoveAction.Enabled = false;
            btnEditAction.Enabled = false;

            ClearListBoxes();

            ttWwiseEventBrowser.SetToolTip(lbBankName, "");
        }

        private void UpdateComponentsOnLoad()
        {
            lbBankName.Text = "Bank Name: " + Path.GetFileName(originalPath);
            listEvents.Enabled = true;
            listActions.Enabled = true;
            comboActions.Enabled = true;
            btnAddAction.Enabled = true;
            btnRemoveAction.Enabled = true;
            btnEditAction.Enabled = true;

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

        private void ReloadLists()
        {
            var selectedEvent = listEvents.SelectedIndex;
            var selectedAction = listActions.SelectedIndex;

            ClearListBoxes();

            AddEventsToListBox();

            if (selectedEvent > -1 && selectedEvent < listEvents.Items.Count)
            {
                listEvents.SelectedIndex = selectedEvent;
                AddActionsToListBox(listEvents.SelectedItem as Event);

                if (selectedAction > -1 && selectedAction < listActions.Items.Count)
                    listActions.SelectedIndex = selectedAction;
            }
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

        private void btnAddAction_Click(object sender, EventArgs e)
        {
            var ev = listEvents.SelectedItem as Event;
            var selectedType = actionTypes[comboActions.SelectedIndex];
            var action = Activator.CreateInstance(selectedType.type) as Data.Wwise.Action;

            using FormWwiseActionBase actionForm = new FormWwiseActionBase(action);
            actionForm.ShowDialog();

            if (actionForm.DialogResult == DialogResult.OK)
            {
                engine.AddActionToEvent(bank, ev, action);
                ReloadLists();
            }
        }

        private void btnRemoveAction_Click(object sender, EventArgs e)
        {
            var ev = listEvents.SelectedItem as Event;
            var action = listActions.SelectedItem as Data.Wwise.Action;

            if (listEvents.SelectedIndex > -1 && listEvents.SelectedIndex < listEvents.Items.Count &&
                listActions.SelectedIndex > -1 && listActions.SelectedIndex < listActions.Items.Count)
            {
                engine.RemoveActionOfEvent(bank, ev, action);
                ReloadLists();
            }
        }

        private void btnEditAction_Click(object sender, EventArgs e)
        {
            var ev = listEvents.SelectedItem as Event;
            var action = listActions.SelectedItem as Data.Wwise.Action;

            if (listEvents.SelectedIndex > -1 && listEvents.SelectedIndex < listEvents.Items.Count &&
                listActions.SelectedIndex > -1 && listActions.SelectedIndex < listActions.Items.Count)
            {
                using FormWwiseActionBase actionForm = new FormWwiseActionBase(action);
                actionForm.ShowDialog();

                if (actionForm.DialogResult == DialogResult.OK)
                {
                    engine.AddActionToEvent(bank, ev, action);
                    ReloadLists();
                }
            }
        }
    }
}
