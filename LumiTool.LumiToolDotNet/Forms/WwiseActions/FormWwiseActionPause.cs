using LumiTool.Data.Wwise;
using System.ComponentModel;

namespace LumiTool.Forms.WwiseActions
{
    public partial class FormWwiseActionPause : FormWwiseActionBase
    {
        BindingList<WwiseObjectIDext> exceptions;

        public FormWwiseActionPause(ActionPause action) : base(action)
        {
            InitializeComponent();

            exceptions = new BindingList<WwiseObjectIDext>(action.exceptParams.listElementException);

            numFadeCurve.Value = action.fadeCurve;
            checkPendingResume.Checked = action.pauseActionSpecificParams.includePendingResume;
            checkStateTransition.Checked = action.pauseActionSpecificParams.applyToStateTransitions;
            checkDynamicSequence.Checked = action.pauseActionSpecificParams.applyToDynamicSequence;
            listExceptions.DataSource = exceptions;
        }

        public FormWwiseActionPause()
        {
            InitializeComponent();
        }

        protected override void SaveProperties()
        {
            base.SaveProperties();

            var actionPause = action as ActionPause;
            actionPause.fadeCurve = (byte)numFadeCurve.Value;
            actionPause.pauseActionSpecificParams.includePendingResume = checkPendingResume.Checked;
            actionPause.pauseActionSpecificParams.applyToStateTransitions = checkStateTransition.Checked;
            actionPause.pauseActionSpecificParams.applyToDynamicSequence = checkDynamicSequence.Checked;
            actionPause.exceptParams.listElementException = exceptions.ToList();
            actionPause.exceptParams.exceptionListSize = (ulong)actionPause.exceptParams.listElementException.Count;
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
