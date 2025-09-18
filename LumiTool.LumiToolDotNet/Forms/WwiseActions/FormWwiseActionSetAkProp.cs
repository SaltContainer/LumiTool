using LumiTool.Data.Wwise;
using System.ComponentModel;

namespace LumiTool.Forms.WwiseActions
{
    public partial class FormWwiseActionSetAkProp : FormWwiseActionBase
    {
        BindingList<WwiseObjectIDext> exceptions;

        public FormWwiseActionSetAkProp(ActionSetAkProp action) : base(action)
        {
            InitializeComponent();

            exceptions = new BindingList<WwiseObjectIDext>(action.exceptParams.listElementException);

            numFadeCurve.Value = action.fadeCurve;
            numRandomBase.Value = (decimal)action.akPropActionSpecificParams.randomizerModifier._base;
            numRandomMin.Value = (decimal)action.akPropActionSpecificParams.randomizerModifier.min;
            numRandomMax.Value = (decimal)action.akPropActionSpecificParams.randomizerModifier.max;
            listExceptions.DataSource = exceptions;
        }

        public FormWwiseActionSetAkProp()
        {
            InitializeComponent();
        }

        protected override void SaveProperties()
        {
            base.SaveProperties();

            var actionSetAkProp = action as ActionSetAkProp;
            actionSetAkProp.fadeCurve = (byte)numFadeCurve.Value;
            actionSetAkProp.akPropActionSpecificParams.randomizerModifier._base = (float)numRandomBase.Value;
            actionSetAkProp.akPropActionSpecificParams.randomizerModifier.min = (float)numRandomMin.Value;
            actionSetAkProp.akPropActionSpecificParams.randomizerModifier.max = (float)numRandomMax.Value;
            actionSetAkProp.exceptParams.listElementException = exceptions.ToList();
            actionSetAkProp.exceptParams.exceptionListSize = (ulong)actionSetAkProp.exceptParams.listElementException.Count;
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
