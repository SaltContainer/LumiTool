using LumiTool.Data.Wwise;
using System.ComponentModel;

namespace LumiTool.Forms.WwiseActions
{
    public partial class FormWwiseActionSetGameParameter : FormWwiseActionBase
    {
        BindingList<WwiseObjectIDext> exceptions;

        public FormWwiseActionSetGameParameter(ActionSetGameParameter action) : base(action)
        {
            InitializeComponent();

            exceptions = new BindingList<WwiseObjectIDext>(action.exceptParams.listElementException);

            numFadeCurve.Value = action.fadeCurve;
            numBypassTransition.Value = action.gameParameterActionSpecificParams.bypassTransition;
            numValueMeaning.Value = action.gameParameterActionSpecificParams.valueMeaning;
            numRangedBase.Value = (decimal)action.gameParameterActionSpecificParams.rangedParameter._base;
            numRangedMin.Value = (decimal)action.gameParameterActionSpecificParams.rangedParameter.min;
            numRangedMax.Value = (decimal)action.gameParameterActionSpecificParams.rangedParameter.max;
            listExceptions.DataSource = exceptions;
        }

        public FormWwiseActionSetGameParameter()
        {
            InitializeComponent();
        }

        protected override void SaveProperties()
        {
            base.SaveProperties();

            var actionSetGameParameter = action as ActionSetGameParameter;
            actionSetGameParameter.fadeCurve = (byte)numFadeCurve.Value;
            actionSetGameParameter.gameParameterActionSpecificParams.bypassTransition = (byte)numBypassTransition.Value;
            actionSetGameParameter.gameParameterActionSpecificParams.valueMeaning = (byte)numValueMeaning.Value;
            actionSetGameParameter.gameParameterActionSpecificParams.rangedParameter._base = (float)numRangedBase.Value;
            actionSetGameParameter.gameParameterActionSpecificParams.rangedParameter.min = (float)numRangedMin.Value;
            actionSetGameParameter.gameParameterActionSpecificParams.rangedParameter.max = (float)numRangedMax.Value;
            actionSetGameParameter.exceptParams.listElementException = exceptions.ToList();
            actionSetGameParameter.exceptParams.exceptionListSize = (ulong)actionSetGameParameter.exceptParams.listElementException.Count;
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
