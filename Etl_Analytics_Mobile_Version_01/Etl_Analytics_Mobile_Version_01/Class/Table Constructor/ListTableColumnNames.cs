using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace Etl_Analytics_Mobile_Version_01.Class.Table_Constructor
{
    public class ListTableNames
    {
        public string TableName { get; set; }
        public bool TableChecked { get; set; }
        public RecyclerView SubRec { get; set; }
        public MyList<ListColumnNames> ListColumnNames { get; set; }
    }

    public class ListColumnNames
    {
        public string ColumnName { get; set; }
        public bool ColumnSelected { get; set; }
    }
}