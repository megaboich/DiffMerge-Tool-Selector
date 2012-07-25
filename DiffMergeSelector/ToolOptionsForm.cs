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
            ToolParameters = toolParameters;

            if (ToolParameters != null)
            {
                edName.Text = ToolParameters.Name;
                edPath.Text = ToolParameters.Path;
                edCommandLine.Text = ToolParameters.CommandLine;
                switch (ToolParameters.ToolCategory)
                {
                    case ToolCategory.Diff:
                        rbDiff.Checked = true;
                        break;
                    case ToolCategory.Merge:
                        rbMerge.Checked = true;
                        break;
                }
            }
        }

        private void btnBrowsePath_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                edPath.Text = openFileDialog1.FileName;
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
    }
}
