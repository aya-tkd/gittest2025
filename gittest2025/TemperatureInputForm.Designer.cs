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
            ((System.ComponentModel.ISupportInitialize)numericUpDownTemperature).BeginInit();
            SuspendLayout();
            // 
            // numericUpDownTemperature
            // 
            numericUpDownTemperature.DecimalPlaces = 1;
            numericUpDownTemperature.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownTemperature.Location = new Point(20, 20);
            numericUpDownTemperature.Maximum = new decimal(new int[] { 420, 0, 0, 65536 });
            numericUpDownTemperature.Minimum = new decimal(new int[] { 350, 0, 0, 65536 });
            numericUpDownTemperature.Name = "numericUpDownTemperature";
            numericUpDownTemperature.Size = new Size(120, 23);
            numericUpDownTemperature.TabIndex = 0;
            numericUpDownTemperature.Value = new decimal(new int[] { 365, 0, 0, 65536 });
            // 
            // dateTimePickerRecordTime
            // 
            dateTimePickerRecordTime.CustomFormat = "yyyy/MM/dd HH:mm";
            dateTimePickerRecordTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerRecordTime.Location = new Point(20, 60);
            dateTimePickerRecordTime.Name = "dateTimePickerRecordTime";
            dateTimePickerRecordTime.Size = new Size(200, 23);
            dateTimePickerRecordTime.TabIndex = 1;
            dateTimePickerRecordTime.Value = new DateTime(2025, 6, 12, 11, 52, 57, 312);
            // 
            // btnOK
            // 
            btnOK.Location = new Point(20, 100);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(120, 100);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "ƒLƒƒƒ“ƒZƒ‹";
            btnCancel.Click += btnCancel_Click;
            // 
            // TemperatureInputForm
            // 
            ClientSize = new Size(250, 150);
            Controls.Add(numericUpDownTemperature);
            Controls.Add(dateTimePickerRecordTime);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TemperatureInputForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "‘Ì‰·“ü—Í";
            ((System.ComponentModel.ISupportInitialize)numericUpDownTemperature).EndInit();
            ResumeLayout(false);
        }
    }
}