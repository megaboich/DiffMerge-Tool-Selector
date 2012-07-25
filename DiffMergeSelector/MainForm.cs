using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DiffMergeSelector.Services;
using System.IO;
using DiffMergeSelector.Models;
using DiffMergeSelector.Models;
using DiffMergeSelector;
using DiffMergeSelector.Services;

namespace DiffMergeSelector
{
    public partial class MainForm : Form
    {
        string[] _parameters;
        
        public MainForm()
        {
            InitializeComponent();

            _parameters = Environment.GetCommandLineArgs().Skip(1).ToArray();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppForm.Instance.Value.AutoCloseWhenFinished = true;
        }

        private void FillLists()
        {
            var config = Config.Instance;
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
                        var iconForFile = dataItem.GetAssociatedIcon();
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

            var config = Config.Instance;
            if (config.LastChoiceToolIndex < lvTools.Items.Count)
            {
                lvTools.Items[config.LastChoiceToolIndex].Selected = true;
            }
            numericUpDown1.Value = config.LastChoiceDuration;

            Activate();
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

        private void Execute(ToolParameters tp)
        {
            if (chRememberChoice.Checked)
            {
                var config = Config.Instance;
                config.LastChoiceToolIndex = lvTools.SelectedIndices[0];
                config.LastChoiceDuration = (int)numericUpDown1.Value;
                config.LastChoiceValid = DateTime.Now.AddMinutes(config.LastChoiceDuration);
                config.Save();
            }

            ToolExecutionManager.ExecuteTool(tp, _parameters);

            Close();
        }
    }
}
