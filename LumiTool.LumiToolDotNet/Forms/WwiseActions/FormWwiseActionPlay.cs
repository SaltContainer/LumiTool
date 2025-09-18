using LumiTool.Data.Wwise;

namespace LumiTool.Forms.WwiseActions
{
    public partial class FormWwiseActionPlay : FormWwiseActionBase
    {
        public FormWwiseActionPlay(ActionPlay action) : base(action)
        {
            InitializeComponent();

            numFadeCurve.Value = action.fadeCurve;
            numBankID.Value = action.bankID;
        }

        public FormWwiseActionPlay()
        {
            InitializeComponent();
        }

        protected override void SaveProperties()
        {
            base.SaveProperties();

            var actionPlay = action as ActionPlay;
            actionPlay.fadeCurve = (byte)numFadeCurve.Value;
            actionPlay.bankID = (uint)numBankID.Value;
        }
    }
}
