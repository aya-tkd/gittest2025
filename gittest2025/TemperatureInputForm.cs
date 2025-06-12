using System;
using System.Windows.Forms;

namespace gittest2025
{
    public partial class TemperatureInputForm : Form
    {
        public decimal Temperature => numericUpDownTemperature.Value;
        public DateTime RecordTime => dateTimePickerRecordTime.Value;

        public TemperatureInputForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}