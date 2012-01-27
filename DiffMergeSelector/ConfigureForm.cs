using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DiffMergeProxyRunner.Models;
using DiffMergeProxyRunner.Services;
using DiffMergeSelector.Services;
using DiffMergeSelector.Models;

namespace DiffMergeProxyRunner
{
    public partial class ConfigureForm : Form
    {
        Config Config;

        public ConfigureForm()
        {
            InitializeComponent();

            listView1.ListViewItemSorter = new ListViewOrderComparer();

            Config = Config.Load();

            FillLists(Config.ToolParameters);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var tof = new ToolOptionsForm(null);
            if (tof.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var tp = tof.ToolParameters;
                tp.OrderIndex = listView1.Items.Count;
                var item = new ListViewItem();
                FillListItem(item, tp);
                item.Tag = tp;
                listView1.Items.Add(item);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void EditSelectedItem()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var item = listView1.SelectedItems[0];
                var tp = (ToolParameters)item.Tag;
                var tof = new ToolOptionsForm(tp);
                if (tof.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tp = tof.ToolParameters;
                    FillListItem(item, tp);
                }
            }
        }

        private void FillListItem(ListViewItem item, ToolParameters tp)
        {
            item.Tag = tp;
            item.Group = listView1.Groups[(int)tp.ToolCategory];
            item.SubItems.Clear();
            item.Text = tp.Name;
            item.Name = tp.Name;
            item.SubItems.Add(tp.Path);
            item.SubItems.Add(tp.CommandLine);
        }

        private void FillLists(IEnumerable<ToolParameters> dataItems)
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (var dataItem in dataItems)
            {
                var item = new ListViewItem();
                FillListItem(item, dataItem);
                listView1.Items.Add(item);
            }
            listView1.Sort();
            listView1.EndUpdate();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var item = listView1.SelectedItems[0];
                listView1.Items.Remove(item);
            }
        }

        private IEnumerable<ToolParameters> GetDataFromUI()
        {
            var list = listView1
                .Items
                .OfType<ListViewItem>()
                .Select(i => (ToolParameters)i.Tag)
                .OrderBy(i => i.OrderIndex)
                .GroupBy(i => i.ToolCategory)
                .SelectMany(i => i)
                .ToList();

            var orderIndex = 0;
            list.ForEach(i => i.OrderIndex = ++orderIndex);
            return list;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Config.ToolParameters = GetDataFromUI().ToArray();
            Config.Save();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditSelectedItem();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var item = listView1.SelectedItems[0];
                var data = (ToolParameters)item.Tag;
                var group = listView1.Groups[(int)data.ToolCategory];

                var index = group.Items.IndexOf(item);
                index--;
                if (index < 0)
                {
                    index = group.Items.Count - 1;
                }

                var othData = (ToolParameters)group.Items[index].Tag;
                var t = othData.OrderIndex;
                othData.OrderIndex = data.OrderIndex;
                data.OrderIndex = t;
                listView1.Sort();
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var item = listView1.SelectedItems[0];
                var data = (ToolParameters)item.Tag;
                var group = listView1.Groups[(int)data.ToolCategory];

                var index = group.Items.IndexOf(item);
                index++;
                if (index >= group.Items.Count)
                {
                    index = 0;
                }

                var othData = (ToolParameters)group.Items[index].Tag;
                var t = othData.OrderIndex;
                othData.OrderIndex = data.OrderIndex;
                data.OrderIndex = t;
                listView1.Sort();
            }
        }
    }
}
