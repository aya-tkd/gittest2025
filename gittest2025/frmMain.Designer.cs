namespace gittest2025
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button2 = new Button();
            btnAddTemperature = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            menuItemDelete = new ToolStripMenuItem();
            pictureBoxGraph = new PictureBox();
            panelDetails = new Panel();
            lblSelectedTemperature = new Label();
            lblSelectedDateTime = new Label();
            lblTitle = new Label();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGraph).BeginInit();
            panelDetails.SuspendLayout();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(590, 296);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(90, 30);
            button2.TabIndex = 1;
            button2.Text = "閉じる";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnAddTemperature
            // 
            btnAddTemperature.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddTemperature.Location = new Point(20, 296);
            btnAddTemperature.Name = "btnAddTemperature";
            btnAddTemperature.Size = new Size(90, 30);
            btnAddTemperature.TabIndex = 4;
            btnAddTemperature.Text = "体温入力";
            btnAddTemperature.UseVisualStyleBackColor = true;
            btnAddTemperature.Click += btnAddTemperature_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { menuItemDelete });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(99, 26);
            // 
            // menuItemDelete
            // 
            menuItemDelete.Name = "menuItemDelete";
            menuItemDelete.Size = new Size(98, 22);
            menuItemDelete.Text = "削除";
            menuItemDelete.Click += menuItemDelete_Click;
            // 
            // pictureBoxGraph
            // 
            pictureBoxGraph.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxGraph.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxGraph.Location = new Point(20, 10);
            pictureBoxGraph.Name = "pictureBoxGraph";
            pictureBoxGraph.Size = new Size(470, 271);
            pictureBoxGraph.TabIndex = 3;
            pictureBoxGraph.TabStop = false;
            // 
            // panelDetails
            // 
            panelDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelDetails.BackColor = Color.FromArgb(240, 240, 255);
            panelDetails.BorderStyle = BorderStyle.FixedSingle;
            panelDetails.Controls.Add(lblSelectedTemperature);
            panelDetails.Controls.Add(lblSelectedDateTime);
            panelDetails.Controls.Add(lblTitle);
            panelDetails.Location = new Point(500, 10);
            panelDetails.Name = "panelDetails";
            panelDetails.Padding = new Padding(10);
            panelDetails.Size = new Size(180, 271);
            panelDetails.TabIndex = 5;
            // 
            // lblSelectedTemperature
            // 
            lblSelectedTemperature.Dock = DockStyle.Top;
            lblSelectedTemperature.Font = new Font("Yu Gothic UI", 9.75F);
            lblSelectedTemperature.Location = new Point(10, 65);
            lblSelectedTemperature.Name = "lblSelectedTemperature";
            lblSelectedTemperature.Padding = new Padding(5);
            lblSelectedTemperature.Size = new Size(158, 25);
            lblSelectedTemperature.TabIndex = 0;
            lblSelectedTemperature.Text = "体温: ";
            lblSelectedTemperature.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSelectedDateTime
            // 
            lblSelectedDateTime.Dock = DockStyle.Top;
            lblSelectedDateTime.Font = new Font("Yu Gothic UI", 9.75F);
            lblSelectedDateTime.Location = new Point(10, 40);
            lblSelectedDateTime.Name = "lblSelectedDateTime";
            lblSelectedDateTime.Padding = new Padding(5);
            lblSelectedDateTime.Size = new Size(158, 25);
            lblSelectedDateTime.TabIndex = 1;
            lblSelectedDateTime.Text = "日時: ";
            lblSelectedDateTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.FromArgb(200, 200, 255);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(158, 30);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "選択データ";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(panelDetails);
            Controls.Add(pictureBoxGraph);
            Controls.Add(btnAddTemperature);
            Controls.Add(button2);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmMain";
            Text = "Form1";
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxGraph).EndInit();
            panelDetails.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button button2;
        private Button btnAddTemperature;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem menuItemDelete;
        private PictureBox pictureBoxGraph;
        private Panel panelDetails;
        private Label lblSelectedDateTime;
        private Label lblSelectedTemperature;
        private Label lblTitle;
    }
}
