using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ListViewItemComparer : IComparer
{
    private readonly int _col;
    private readonly SortOrder _order;

    public ListViewItemComparer()
    {
        _col = 0;
        _order = SortOrder.Ascending;
    }

    public ListViewItemComparer(int column, SortOrder order)
    {
        _col = column;
        _order = order;
    }

    public int Compare(object x, object y)
    {
        int returnVal = -1;
        returnVal = String.Compare(((ListViewItem)x).SubItems[_col].Text, ((ListViewItem)y).SubItems[_col].Text);
        if (_order == SortOrder.Descending)
            returnVal *= -1;
        return returnVal;
    }
}


