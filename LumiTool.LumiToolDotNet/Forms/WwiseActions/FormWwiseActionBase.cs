using LumiTool.Data.Wwise;
using System.ComponentModel;

namespace LumiTool.Forms.WwiseActions
{
    public partial class FormWwiseActionBase : Form
    {
        protected Data.Wwise.Action action;

        BindingList<PropBundle1> bundle0Props;
        BindingList<PropBundle3> bundle2Props;

        public FormWwiseActionBase(Data.Wwise.Action action)
        {
            InitializeComponent();

            this.action = action;
            bundle0Props = new BindingList<PropBundle1>(action.initialParams.propBundle0.props);
            bundle2Props = new BindingList<PropBundle3>(action.initialParams.propBundle2.props);

            numExtID.Value = action.idExt;
            checkIsBus.Checked = action.isBus != 0;
            listBundle0.DataSource = bundle0Props;
            listBundle2.DataSource = bundle2Props;
        }

        public FormWwiseActionBase()
        {
            InitializeComponent();
        }

        public static FormWwiseActionBase BuildFormByActionType(Data.Wwise.Action action)
        {
            switch (action)
            {
                case ActionStop actionStop:
                    return new FormWwiseActionStop(actionStop);

                case ActionPause actionPause:
                    return new FormWwiseActionPause(actionPause);

                case ActionResume actionResume:
                    return new FormWwiseActionResume(actionResume);

                case ActionPlay actionPlay:
                    return new FormWwiseActionPlay(actionPlay);

                case ActionMute actionMute:
                    return new FormWwiseActionMute(actionMute);

                case ActionSetAkProp actionSetAkProp:
                    return new FormWwiseActionSetAkProp(actionSetAkProp);

                case ActionSetState actionSetState:
                    return new FormWwiseActionSetState(actionSetState);

                case ActionSetGameParameter actionSetGameParameter:
                    return new FormWwiseActionSetGameParameter(actionSetGameParameter);

                case ActionSetSwitch actionSetSwitch:
                    return new FormWwiseActionSetSwitch(actionSetSwitch);

                case ActionPlayEvent actionPlayEvent:
                    return new FormWwiseActionPlayEvent(actionPlayEvent);

                default:
                    return null;
            }
        }

        protected virtual void SaveProperties()
        {
            action.idExt = (uint)numExtID.Value;
            action.isBus = (byte)(checkIsBus.Checked ? 1 : 0);
            action.initialParams.propBundle0.props = bundle0Props.ToList();
            action.initialParams.propBundle0.propsCount = (byte)action.initialParams.propBundle0.props.Count;
            action.initialParams.propBundle2.props = bundle2Props.ToList();
            action.initialParams.propBundle2.propsCount = (byte)action.initialParams.propBundle2.props.Count;
        }

        private void SetOKAndClose()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveProperties();
            SetOKAndClose();
        }

        private void listBundle0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBundle0.SelectedIndex >= 0 && listBundle0.SelectedIndex < bundle0Props.Count)
            {
                var item = bundle0Props[listBundle0.SelectedIndex];
                numBundle1ID.Value = item.id;
                numBundle1Value.Value = (decimal)item.value;
            }
        }

        private void btnAddBundle1_Click(object sender, EventArgs e)
        {
            bundle0Props.Add(new PropBundle1()
            {
                id = (byte)numBundle1ID.Value,
                value = (float)numBundle1Value.Value,
            });
        }

        private void btnRemoveBundle1_Click(object sender, EventArgs e)
        {
            if (listBundle0.SelectedIndex >= 0 && listBundle0.SelectedIndex < bundle0Props.Count)
                bundle0Props.RemoveAt(listBundle0.SelectedIndex);
        }

        private void btnEditBundle1_Click(object sender, EventArgs e)
        {
            if (listBundle0.SelectedIndex >= 0 && listBundle0.SelectedIndex < bundle0Props.Count)
            {
                var item = bundle0Props[listBundle0.SelectedIndex];
                item.id = (byte)numBundle1ID.Value;
                item.value = (float)numBundle1Value.Value;
            }
        }

        private void listBundle2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBundle2.SelectedIndex >= 0 && listBundle2.SelectedIndex < bundle2Props.Count)
            {
                var item = bundle2Props[listBundle2.SelectedIndex];
                numBundle3ID.Value = item.id;
                numBundle3Min0.Value = item.min[0];
                numBundle3Min1.Value = item.min[1];
                numBundle3Min2.Value = item.min[2];
                numBundle3Min3.Value = item.min[3];
                numBundle3Max0.Value = item.max[0];
                numBundle3Max1.Value = item.max[1];
                numBundle3Max2.Value = item.max[2];
                numBundle3Max3.Value = item.max[3];
            }
        }

        private void btnAddBundle3_Click(object sender, EventArgs e)
        {
            bundle2Props.Add(new PropBundle3()
            {
                id = (byte)numBundle3ID.Value,
                min = new byte[4] {
                    (byte)numBundle3Min0.Value,
                    (byte)numBundle3Min1.Value,
                    (byte)numBundle3Min2.Value,
                    (byte)numBundle3Min3.Value,
                },
                max = new byte[4] {
                    (byte)numBundle3Max0.Value,
                    (byte)numBundle3Max1.Value,
                    (byte)numBundle3Max2.Value,
                    (byte)numBundle3Max3.Value,
                },
            });
        }

        private void btnRemoveBundle3_Click(object sender, EventArgs e)
        {
            if (listBundle2.SelectedIndex >= 0 && listBundle2.SelectedIndex < bundle2Props.Count)
                bundle2Props.RemoveAt(listBundle2.SelectedIndex);
        }

        private void btnEditBundle3_Click(object sender, EventArgs e)
        {
            if (listBundle2.SelectedIndex >= 0 && listBundle2.SelectedIndex < bundle2Props.Count)
            {
                var item = bundle2Props[listBundle2.SelectedIndex];
                item.id = (byte)numBundle3ID.Value;
                item.min = new byte[4] {
                    (byte)numBundle3Min0.Value,
                    (byte)numBundle3Min1.Value,
                    (byte)numBundle3Min2.Value,
                    (byte)numBundle3Min3.Value,
                };
                item.max = new byte[4] {
                    (byte)numBundle3Max0.Value,
                    (byte)numBundle3Max1.Value,
                    (byte)numBundle3Max2.Value,
                    (byte)numBundle3Max3.Value,
                };
            }
        }
    }
}
