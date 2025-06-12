namespace gittest2025
{
    partial class TemperatureInputForm
    {
        private NumericUpDown numericUpDownTemperature;
        private DateTimePicker dateTimePickerRecordTime;
        private Button btnOK;
        private Button btnCancel;

        private void InitializeComponent()
        {
            numericUpDownTemperature = new NumericUpDown();
            dateTimePickerRecordTime = new DateTimePicker();
            btnOK = new Button();
            btnCancel = new Button();

            // numericUpDownTemperature
            numericUpDownTemperature.DecimalPlaces = 1;
            numericUpDownTemperature.Minimum = 35.0M;
            numericUpDownTemperature.Maximum = 42.0M;
            numericUpDownTemperature.Increment = 0.1M;
            numericUpDownTemperature.Value = 36.5M;
            numericUpDownTemperature.Location = new Point(20, 20);
            numericUpDownTemperature.Size = new Size(120, 23);

            // dateTimePickerRecordTime
            dateTimePickerRecordTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerRecordTime.CustomFormat = "yyyy/MM/dd HH:mm";
            dateTimePickerRecordTime.Value = DateTime.Now;
            dateTimePickerRecordTime.Location = new Point(20, 60);
            dateTimePickerRecordTime.Size = new Size(200, 23);

            // btnOK
            btnOK.Text = "OK";
            btnOK.Location = new Point(20, 100);
            btnOK.Click += btnOK_Click;

            // btnCancel
            btnCancel.Text = "ƒLƒƒƒ“ƒZƒ‹";
            btnCancel.Location = new Point(120, 100);
            btnCancel.Click += btnCancel_Click;

            // TemperatureInputForm
            ClientSize = new Size(250, 150);
            Controls.Add(numericUpDownTemperature);
            Controls.Add(dateTimePickerRecordTime);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Text = "‘Ì‰·“ü—Í";
        }
    }
}