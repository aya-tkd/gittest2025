namespace gittest2025
{
    partial class TemperatureInputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownTemperature = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerRecordTime = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelTemperature = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTemperature)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownTemperature
            // 
            this.numericUpDownTemperature.DecimalPlaces = 1;
            this.numericUpDownTemperature.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownTemperature.Location = new System.Drawing.Point(20, 99);
            this.numericUpDownTemperature.Maximum = new decimal(new int[] {
            420,
            0,
            0,
            65536});
            this.numericUpDownTemperature.Minimum = new decimal(new int[] {
            350,
            0,
            0,
            65536});
            this.numericUpDownTemperature.Name = "numericUpDownTemperature";
            this.numericUpDownTemperature.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownTemperature.TabIndex = 1;
            this.numericUpDownTemperature.Value = new decimal(new int[] {
            365,
            0,
            0,
            65536});
            // 
            // dateTimePickerRecordTime
            // 
            this.dateTimePickerRecordTime.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dateTimePickerRecordTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerRecordTime.Location = new System.Drawing.Point(20, 38);
            this.dateTimePickerRecordTime.Name = "dateTimePickerRecordTime";
            this.dateTimePickerRecordTime.Size = new System.Drawing.Size(210, 23);
            this.dateTimePickerRecordTime.TabIndex = 0;
            this.dateTimePickerRecordTime.Value = new System.DateTime(2025, 6, 12, 11, 52, 57, 312);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(20, 148);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "登録";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(130, 148);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "閉じる";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(17, 17);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(31, 15);
            this.labelDate.TabIndex = 4;
            this.labelDate.Text = "日付";
            // 
            // labelTemperature
            // 
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Location = new System.Drawing.Point(17, 78);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(31, 15);
            this.labelTemperature.TabIndex = 5;
            this.labelTemperature.Text = "体温";
            // 
            // TemperatureInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 200);
            this.Controls.Add(this.labelTemperature);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dateTimePickerRecordTime);
            this.Controls.Add(this.numericUpDownTemperature);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemperatureInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "体温入力";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTemperature)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownTemperature;
        private System.Windows.Forms.DateTimePicker dateTimePickerRecordTime;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelTemperature;
    }
}
