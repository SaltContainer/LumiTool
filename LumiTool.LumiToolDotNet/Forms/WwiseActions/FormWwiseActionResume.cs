using LumiTool.Data.Wwise;
using System.ComponentModel;

namespace LumiTool.Forms.WwiseActions
{
    public partial class FormWwiseActionResume : FormWwiseActionBase
    {
        BindingList<WwiseObjectIDext> exceptions;

        public FormWwiseActionResume(ActionResume action) : base(action)
        {
            InitializeComponent();

            exceptions = new BindingList<WwiseObjectIDext>(action.exceptParams.listElementException);

            numFadeCurve.Value = action.fadeCurve;
            checkMasterResume.Checked = action.resumeActionSpecificParams.isMasterResume;
            checkStateTransition.Checked = action.resumeActionSpecificParams.applyToStateTransitions;
            checkDynamicSequence.Checked = action.resumeActionSpecificParams.applyToDynamicSequence;
            listExceptions.DataSource = exceptions;
        }

        public FormWwiseActionResume()
        {
            InitializeComponent();
        }

        protected override void SaveProperties()
        {
            base.SaveProperties();

            var actionResume = action as ActionResume;
            actionResume.fadeCurve = (byte)numFadeCurve.Value;
            actionResume.resumeActionSpecificParams.isMasterResume = checkMasterResume.Checked;
            actionResume.resumeActionSpecificParams.applyToStateTransitions = checkStateTransition.Checked;
            actionResume.resumeActionSpecificParams.applyToDynamicSequence = checkDynamicSequence.Checked;
            actionResume.exceptParams.listElementException = exceptions.ToList();
            actionResume.exceptParams.exceptionListSize = (ulong)actionResume.exceptParams.listElementException.Count;
        }

        private void listExceptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listExceptions.SelectedIndex >= 0 && listExceptions.SelectedIndex < exceptions.Count)
            {
                var item = exceptions[listExceptions.SelectedIndex];
                numExceptionID.Value = item.id;
                checkExceptionBus.Checked = item.isBus != 0;
            }
        }

        private void btnExceptionsAdd_Click(object sender, EventArgs e)
        {
            exceptions.Add(new WwiseObjectIDext()
            {
                id = (uint)numExceptionID.Value,
                isBus = (byte)(checkExceptionBus.Checked ? 1 : 0),
            });
        }

        private void btnExceptionsRemove_Click(object sender, EventArgs e)
        {
            if (listExceptions.SelectedIndex >= 0 && listExceptions.SelectedIndex < exceptions.Count)
                exceptions.RemoveAt(listExceptions.SelectedIndex);
        }

        private void btnExceptionsEdit_Click(object sender, EventArgs e)
        {
            if (listExceptions.SelectedIndex >= 0 && listExceptions.SelectedIndex < exceptions.Count)
            {
                var item = exceptions[listExceptions.SelectedIndex];
                item.id = (uint)numExceptionID.Value;
                item.isBus = (byte)(checkExceptionBus.Checked ? 1 : 0);
            }
        }
    }
}
