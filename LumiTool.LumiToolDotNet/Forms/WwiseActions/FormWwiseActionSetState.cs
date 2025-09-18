using LumiTool.Data.Wwise;

namespace LumiTool.Forms.WwiseActions
{
    public partial class FormWwiseActionSetState : FormWwiseActionBase
    {
        public FormWwiseActionSetState(ActionSetState action) : base(action)
        {
            InitializeComponent();

            numStateGroupID.Value = action.stateGroupID;
            numTargetStateID.Value = action.targetStateID;
        }

        public FormWwiseActionSetState()
        {
            InitializeComponent();
        }

        protected override void SaveProperties()
        {
            base.SaveProperties();

            var actionSetState = action as ActionSetState;
            actionSetState.stateGroupID = (uint)numStateGroupID.Value;
            actionSetState.targetStateID = (uint)numTargetStateID.Value;
        }
    }
}
