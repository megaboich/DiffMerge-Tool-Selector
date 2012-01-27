using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DiffMergeProxyRunner.Services;
using System.IO;
using DiffMergeProxyRunner.Models;
using DiffMergeSelector.Models;

namespace DiffMergeProxyRunner
{
    public partial class MainForm : Form
    {
        string[] _parameters;

        public MainForm(string[] parameters)
        {
            InitializeComponent();

            _parameters = parameters;
        }

        private void FillLists()
        {
            var config = Config.Load();
            var dataItems = config.ToolParameters;

            lvTools.BeginUpdate();
            lvTools.Items.Clear();
            imageList1.Images.Clear();
            foreach (var dataItem in dataItems)
            {
                var item = new ListViewItem();
                item.Text = dataItem.Name;
                item.Tag = dataItem;
                item.Group = lvTools.Groups[(int)dataItem.ToolCategory];

                try
                {
                    if (File.Exists(dataItem.Path))
                    {
                        var iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(dataItem.Path);
                        imageList1.Images.Add(iconForFile);
                        item.ImageIndex = imageList1.Images.Count - 1;
                    }
                }
                catch
                {

                }
                
                lvTools.Items.Add(item);
            }
            lvTools.EndUpdate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int i = 0;
            
            _parameters.ToList().ForEach(p =>
            {
                lvParams.Items.Add(new ListViewItem(new[] { (++i).ToString(), p }));
            });

            FillLists();

            var config = Config.Load();
            if (config.LastChoiceToolIndex < lvTools.Items.Count)
            {
                lvTools.Items[config.LastChoiceToolIndex].Selected = true;
            }
            numericUpDown1.Value = config.LastChoiceDuration;
            if (DateTime.Now < config.LastChoiceValid)
            {
                var tp = (ToolParameters)lvTools.Items[config.LastChoiceToolIndex].Tag;
                Execute(tp);
            }
        }

        private void btnConfigureDiffMergeTools_Click(object sender, EventArgs e)
        {
            var confDialog = new ConfigureForm();
            confDialog.ShowDialog();
            FillLists();
        }

        private void lvTools_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvTools.SelectedItems.Count > 0)
            {
                var item = lvTools.SelectedItems[0];
                var tp = (ToolParameters)item.Tag;

                Execute(tp);
            }
        }

        private string GetParam(int index)
        {
            if (index >= _parameters.Length)
            {
                return string.Empty;
            }

            return "\"" + _parameters[index] + "\"";
        }

        private void Execute(ToolParameters tp)
        {
            if (chRememberChoice.Checked)
            {
                var config = Config.Load();
                config.LastChoiceToolIndex = lvTools.SelectedIndices[0];
                config.LastChoiceDuration = (int)numericUpDown1.Value;
                config.LastChoiceValid = DateTime.Now.AddMinutes((int)numericUpDown1.Value);
                config.Save();
            }

            var commandLine = tp.CommandLine;

            if (string.IsNullOrWhiteSpace(commandLine))
            {
                commandLine = "%1 %2 %3 %4 %5 %6 %7 %8 %9";
            }

            commandLine = commandLine
                .Replace("%1", GetParam(0))
                .Replace("%2", GetParam(1))
                .Replace("%3", GetParam(2))
                .Replace("%4", GetParam(3))
                .Replace("%5", GetParam(4))
                .Replace("%6", GetParam(5))
                .Replace("%7", GetParam(6))
                .Replace("%8", GetParam(7))
                .Replace("%9", GetParam(8))
                ;

            if (checkBox1.Checked)
            {
                Hide();
                ShowInTaskbar = false;
            }

            try
            {
                var process = System.Diagnostics.Process.Start(tp.Path, commandLine);
                if (checkBox1.Checked)
                {
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            if (checkBox1.Checked)
            {
                Close();
            }
        }
    }
}
