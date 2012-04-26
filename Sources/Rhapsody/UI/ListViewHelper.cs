using System;
using System.Linq;
using System.Windows.Forms;

namespace Rhapsody.UI
{
    internal static class ListViewHelper
    {
        public static void ResizeColumnToFit(this ListView listView, ColumnHeader columnHeader)
        {
            columnHeader.Width = listView.Width - listView.Columns.Cast<ColumnHeader>().Where(c => c != columnHeader).Sum(c => c.Width) - SystemInformation.VerticalScrollBarWidth - 5;
        }
    }
}
