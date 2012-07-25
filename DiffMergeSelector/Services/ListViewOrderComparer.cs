using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DiffMergeSelector.Models;

namespace DiffMergeSelector.Services
{
    public class ListViewOrderComparer : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            var xobj = (ToolParameters)((ListViewItem)x).Tag;
            var yobj = (ToolParameters)((ListViewItem)y).Tag;

            if (xobj.ToolCategory != yobj.ToolCategory)
            {
                return (xobj.ToolCategory == ToolCategory.Diff) ? -1 : 1;
            }

            if (xobj.OrderIndex > yobj.OrderIndex) return 1;

            if (xobj.OrderIndex < yobj.OrderIndex) return -1;

            return 0;
        }
    }
}
