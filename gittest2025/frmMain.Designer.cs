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
            button1 = new Button();
            button2 = new Button();
            btnAddTemperature = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            menuItemDelete = new ToolStripMenuItem();
            pictureBoxGraph = new PictureBox();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGraph).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(447, 287);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(109, 39);
            button1.TabIndex = 0;
            button1.Text = "確認";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(571, 287);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(109, 39);
            button2.TabIndex = 1;
            button2.Text = "閉じる";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnAddTemperature
            // 
            btnAddTemperature.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddTemperature.Location = new Point(20, 287);
            btnAddTemperature.Name = "btnAddTemperature";
            btnAddTemperature.Size = new Size(109, 39);
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
            pictureBoxGraph.Size = new Size(660, 271);
            pictureBoxGraph.TabIndex = 3;
            pictureBoxGraph.TabStop = false;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(pictureBoxGraph);
            Controls.Add(btnAddTemperature);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmMain";
            Text = "Form1";
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxGraph).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button btnAddTemperature;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem menuItemDelete;
        private PictureBox pictureBoxGraph;
    }
}
