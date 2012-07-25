namespace DiffMergeSelector
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Diff Tools", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Merge Tools", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lvParams = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnConfigureDiffMergeTools = new System.Windows.Forms.Button();
            this.lvTools = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.chRememberChoice = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Command Line Parameters:";
            // 
            // lvParams
            // 
            this.lvParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvParams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvParams.Location = new System.Drawing.Point(18, 29);
            this.lvParams.Name = "lvParams";
            this.lvParams.Size = new System.Drawing.Size(624, 123);
            this.lvParams.TabIndex = 1;
            this.lvParams.UseCompatibleStateImageBehavior = false;
            this.lvParams.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 25;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 579;
            // 
            // btnConfigureDiffMergeTools
            // 
            this.btnConfigureDiffMergeTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfigureDiffMergeTools.Location = new System.Drawing.Point(567, 167);
            this.btnConfigureDiffMergeTools.Name = "btnConfigureDiffMergeTools";
            this.btnConfigureDiffMergeTools.Size = new System.Drawing.Size(75, 23);
            this.btnConfigureDiffMergeTools.TabIndex = 7;
            this.btnConfigureDiffMergeTools.Text = "Configure...";
            this.btnConfigureDiffMergeTools.UseVisualStyleBackColor = true;
            this.btnConfigureDiffMergeTools.Click += new System.EventHandler(this.btnConfigureDiffMergeTools_Click);
            // 
            // lvTools
            // 
            this.lvTools.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            listViewGroup1.Header = "Diff Tools";
            listViewGroup1.Name = "Diff Tools";
            listViewGroup2.Header = "Merge Tools";
            listViewGroup2.Name = "Merge Tools";
            this.lvTools.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lvTools.HideSelection = false;
            this.lvTools.LargeImageList = this.imageList1;
            this.lvTools.Location = new System.Drawing.Point(18, 210);
            this.lvTools.Name = "lvTools";
            this.lvTools.Size = new System.Drawing.Size(624, 271);
            this.lvTools.TabIndex = 7;
            this.lvTools.UseCompatibleStateImageBehavior = false;
            this.lvTools.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvTools_MouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // chRememberChoice
            // 
            this.chRememberChoice.AutoSize = true;
            this.chRememberChoice.Location = new System.Drawing.Point(221, 172);
            this.chRememberChoice.Name = "chRememberChoice";
            this.chRememberChoice.Size = new System.Drawing.Size(146, 17);
            this.chRememberChoice.TabIndex = 9;
            this.chRememberChoice.Text = "Remember my choice for ";
            this.chRememberChoice.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(367, 171);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(440, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "minutes";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 493);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.chRememberChoice);
            this.Controls.Add(this.lvTools);
            this.Controls.Add(this.btnConfigureDiffMergeTools);
            this.Controls.Add(this.lvParams);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiffMerge Tool Selector";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvParams;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lvTools;
        private System.Windows.Forms.Button btnConfigureDiffMergeTools;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chRememberChoice;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
    }
}

