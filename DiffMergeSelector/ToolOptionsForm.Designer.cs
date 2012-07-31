namespace DiffMergeSelector
{
    partial class ToolOptionsForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.edName = new System.Windows.Forms.TextBox();
            this.lbPath = new System.Windows.Forms.Label();
            this.edPath = new System.Windows.Forms.TextBox();
            this.edCommandLine = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowsePath = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbMerge = new System.Windows.Forms.RadioButton();
            this.rbDiff = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.edIcon = new System.Windows.Forms.TextBox();
            this.btnBrowseIcon = new System.Windows.Forms.Button();
            this.imgIcon = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(297, 301);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(378, 301);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(12, 20);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(38, 13);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "Name:";
            // 
            // edName
            // 
            this.edName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edName.Location = new System.Drawing.Point(52, 17);
            this.edName.Name = "edName";
            this.edName.Size = new System.Drawing.Size(401, 20);
            this.edName.TabIndex = 3;
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Location = new System.Drawing.Point(12, 143);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(32, 13);
            this.lbPath.TabIndex = 4;
            this.lbPath.Text = "Path:";
            // 
            // edPath
            // 
            this.edPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edPath.Location = new System.Drawing.Point(46, 140);
            this.edPath.Name = "edPath";
            this.edPath.Size = new System.Drawing.Size(371, 20);
            this.edPath.TabIndex = 5;
            this.edPath.TextChanged += new System.EventHandler(this.edPath_TextChanged);
            // 
            // edCommandLine
            // 
            this.edCommandLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edCommandLine.Location = new System.Drawing.Point(30, 182);
            this.edCommandLine.Name = "edCommandLine";
            this.edCommandLine.Size = new System.Drawing.Size(423, 20);
            this.edCommandLine.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Command Line Parameters:";
            // 
            // btnBrowsePath
            // 
            this.btnBrowsePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowsePath.Location = new System.Drawing.Point(423, 138);
            this.btnBrowsePath.Name = "btnBrowsePath";
            this.btnBrowsePath.Size = new System.Drawing.Size(30, 23);
            this.btnBrowsePath.TabIndex = 8;
            this.btnBrowsePath.Text = "...";
            this.btnBrowsePath.UseVisualStyleBackColor = true;
            this.btnBrowsePath.Click += new System.EventHandler(this.btnBrowsePath_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbMerge);
            this.groupBox1.Controls.Add(this.rbDiff);
            this.groupBox1.Location = new System.Drawing.Point(11, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 60);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Category: ";
            // 
            // rbMerge
            // 
            this.rbMerge.AutoSize = true;
            this.rbMerge.Location = new System.Drawing.Point(140, 24);
            this.rbMerge.Name = "rbMerge";
            this.rbMerge.Size = new System.Drawing.Size(79, 17);
            this.rbMerge.TabIndex = 1;
            this.rbMerge.Text = "Merge Tool";
            this.rbMerge.UseVisualStyleBackColor = true;
            // 
            // rbDiff
            // 
            this.rbDiff.AutoSize = true;
            this.rbDiff.Checked = true;
            this.rbDiff.Location = new System.Drawing.Point(52, 24);
            this.rbDiff.Name = "rbDiff";
            this.rbDiff.Size = new System.Drawing.Size(65, 17);
            this.rbDiff.TabIndex = 0;
            this.rbDiff.TabStop = true;
            this.rbDiff.Text = "Diff Tool";
            this.rbDiff.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Custom Icon:";
            // 
            // edIcon
            // 
            this.edIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edIcon.Location = new System.Drawing.Point(56, 246);
            this.edIcon.Name = "edIcon";
            this.edIcon.Size = new System.Drawing.Size(361, 20);
            this.edIcon.TabIndex = 10;
            // 
            // btnBrowseIcon
            // 
            this.btnBrowseIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseIcon.Location = new System.Drawing.Point(423, 244);
            this.btnBrowseIcon.Name = "btnBrowseIcon";
            this.btnBrowseIcon.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseIcon.TabIndex = 12;
            this.btnBrowseIcon.Text = "...";
            this.btnBrowseIcon.UseVisualStyleBackColor = true;
            this.btnBrowseIcon.Click += new System.EventHandler(this.btnBrowseIcon_Click);
            // 
            // imgIcon
            // 
            this.imgIcon.Location = new System.Drawing.Point(18, 247);
            this.imgIcon.Name = "imgIcon";
            this.imgIcon.Size = new System.Drawing.Size(32, 32);
            this.imgIcon.TabIndex = 13;
            this.imgIcon.TabStop = false;
            // 
            // ToolOptionsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(465, 336);
            this.Controls.Add(this.imgIcon);
            this.Controls.Add(this.btnBrowseIcon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edIcon);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBrowsePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edCommandLine);
            this.Controls.Add(this.edPath);
            this.Controls.Add(this.lbPath);
            this.Controls.Add(this.edName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "ToolOptionsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tool Parameters";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox edName;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.TextBox edPath;
        private System.Windows.Forms.TextBox edCommandLine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowsePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbMerge;
        private System.Windows.Forms.RadioButton rbDiff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edIcon;
        private System.Windows.Forms.Button btnBrowseIcon;
        private System.Windows.Forms.PictureBox imgIcon;
    }
}