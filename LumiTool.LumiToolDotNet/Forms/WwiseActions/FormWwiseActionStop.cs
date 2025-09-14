using LumiTool.Data.Wwise;
using System.ComponentModel;

namespace LumiTool.Forms.WwiseActions
{
    public partial class FormWwiseActionStop : FormWwiseActionBase
    {
        BindingList<WwiseObjectIDext> exceptions;

        public FormWwiseActionStop(ActionStop action) : base(action)
        {
            InitializeComponent();

            exceptions = new BindingList<WwiseObjectIDext>(action.exceptParams.listElementException);

            numFadeCurve.Value = action.fadeCurve;
            checkStateTransition.Checked = action.stopActionSpecificParams.applyToStateTransitions;
            checkDynamicSequence.Checked = action.stopActionSpecificParams.applyToDynamicSequence;
            listExceptions.DataSource = exceptions;
        }

        public FormWwiseActionStop()
        {
            InitializeComponent();
        }

        protected override void SaveProperties()
        {
            base.SaveProperties();

            var actionStop = action as ActionStop;
            actionStop.fadeCurve = (byte)numFadeCurve.Value;
            actionStop.stopActionSpecificParams.applyToStateTransitions = checkStateTransition.Checked;
            actionStop.stopActionSpecificParams.applyToDynamicSequence = checkDynamicSequence.Checked;
            actionStop.exceptParams.listElementException = exceptions.ToList();
            actionStop.exceptParams.exceptionListSize = (ulong)actionStop.exceptParams.listElementException.Count;
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

        private void btnExceptionsEdit_Click(object sender, EventArgs e)
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

        private void btnExceptionsAdd_Click(object sender, EventArgs e)
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
