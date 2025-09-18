using LumiTool.Data.Wwise;

namespace LumiTool.Forms.WwiseActions
{
    public partial class FormWwiseActionSetSwitch : FormWwiseActionBase
    {
        public FormWwiseActionSetSwitch(ActionSetSwitch action) : base(action)
        {
            InitializeComponent();

            numSwitchGroupID.Value = action.switchGroupID;
            numSwitchStateID.Value = action.switchStateID;
        }

        public FormWwiseActionSetSwitch()
        {
            InitializeComponent();
        }

        protected override void SaveProperties()
        {
            base.SaveProperties();

            var actionSetSwitch = action as ActionSetSwitch;
            actionSetSwitch.switchGroupID = (uint)numSwitchGroupID.Value;
            actionSetSwitch.switchStateID = (uint)numSwitchStateID.Value;
        }
    }
}
