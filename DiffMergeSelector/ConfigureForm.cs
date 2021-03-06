﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DiffMergeSelector.Models;
using DiffMergeSelector.Services;
using DiffMergeSelector.Services;
using DiffMergeSelector.Models;

namespace DiffMergeSelector
{
    public partial class ConfigureForm : Form
    {
        public ConfigureForm()
        {
            InitializeComponent();

            FillLists(Config.Instance.ToolParameters);
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
                    item.Tag = tp;
                    FillLists(GetDataFromUI());
                }
            }
        }

        private void FillListItem(ListViewItem item, ToolParameters tp)
        {
            item.Tag = tp;
            item.Group = listView1.Groups[(int)tp.ToolCategory];
            item.Text = "  " + tp.Name;
            item.Name = tp.Name;
            item.SubItems.Clear();
            item.SubItems.Add(tp.Path);
            item.SubItems.Add(tp.CommandLine);
        }

        private void FillLists(IEnumerable<ToolParameters> dataItems)
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            imageList1.Images.Clear();
            foreach (var dataItem in dataItems)
            {
                var item = new ListViewItem();
                FillListItem(item, dataItem);
                var img = dataItem.GetAssociatedIcon();
                if (img != null)
                {
                    imageList1.Images.Add(img);
                    item.ImageIndex = imageList1.Images.Count - 1;
                }
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
            Config.Instance.ToolParameters = GetDataFromUI().ToArray();
            Config.Instance.Save();
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

                FillLists(GetDataFromUI());
                foreach (ListViewItem it in listView1.Items)
                {
                    if (it.Tag == (object)data)
                    {
                        it.Selected = true;
                    }
                }
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

                FillLists(GetDataFromUI());
                foreach (ListViewItem it in listView1.Items)
                {
                    if (it.Tag == (object)data)
                    {
                        it.Selected = true;
                    }
                }
            }
        }
    }
}
