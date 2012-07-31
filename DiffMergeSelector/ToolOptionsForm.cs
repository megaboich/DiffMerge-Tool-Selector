using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DiffMergeSelector.Models;

namespace DiffMergeSelector
{
    public partial class ToolOptionsForm : Form
    {
        public ToolParameters ToolParameters { get; set; }

        public ToolOptionsForm(ToolParameters toolParameters)
        {
            InitializeComponent();
            

            if (toolParameters != null)
            {
                ToolParameters = toolParameters.Clone();
            }
            else
            {
                ToolParameters = new ToolParameters();
            }

            edName.Text = ToolParameters.Name;
            edPath.Text = ToolParameters.Path;
            edCommandLine.Text = ToolParameters.CommandLine;
            edIcon.Text = ToolParameters.CustomImagePath;
            switch (ToolParameters.ToolCategory)
            {
                case ToolCategory.Diff:
                    rbDiff.Checked = true;
                    break;
                case ToolCategory.Merge:
                    rbMerge.Checked = true;
                    break;
            }

            imgIcon.Image = ToolParameters.GetAssociatedIcon();
        }

        private void btnBrowsePath_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Exe files|*.exe;*.cmd;*.bat|All files|*.*";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                edPath.Text = openFileDialog1.FileName;
                ToolParameters.Path = edPath.Text;
                imgIcon.Image = ToolParameters.GetAssociatedIcon();
            }
        }

        private void btnBrowseIcon_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Images files|*.jpg;*.jpeg;*.png;*.bmp;*.ico;*.gif|All files|*.*";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                edIcon.Text = openFileDialog1.FileName;
                ToolParameters.CustomImagePath = edIcon.Text;
                imgIcon.Image = ToolParameters.GetAssociatedIcon();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            edName.BackColor = SystemColors.Window;
            if (string.IsNullOrWhiteSpace(edName.Text))
            {
                edName.BackColor = Color.LightPink;
                return;
            }

            edPath.BackColor = SystemColors.Window;
            if (string.IsNullOrWhiteSpace(edPath.Text))
            {
                edPath.BackColor = Color.LightPink;
                return;
            }

            ToolParameters = new ToolParameters
            {
                Name = edName.Text,
                Path = edPath.Text,
                CustomImagePath = edIcon.Text,
                CommandLine = edCommandLine.Text,
                ToolCategory = rbDiff.Checked ? ToolCategory.Diff : ToolCategory.Merge,
            };

            DialogResult = System.Windows.Forms.DialogResult.OK;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void edPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
