using LumiTool.Data.Wwise;
using System.ComponentModel;

namespace LumiTool.Forms.WwiseActions
{
    public partial class FormWwiseActionMute : FormWwiseActionBase
    {
        BindingList<WwiseObjectIDext> exceptions;

        public FormWwiseActionMute(ActionMute action) : base(action)
        {
            InitializeComponent();

            exceptions = new BindingList<WwiseObjectIDext>(action.exceptParams.listElementException);

            numFadeCurve.Value = action.fadeCurve;
            listExceptions.DataSource = exceptions;
        }

        public FormWwiseActionMute()
        {
            InitializeComponent();
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
