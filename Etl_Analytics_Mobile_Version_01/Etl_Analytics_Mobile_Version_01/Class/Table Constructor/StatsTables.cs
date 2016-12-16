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

namespace Etl_Analytics_Mobile_Version_01.Class.Table_Constructor
{
    public class StatsTables
    {
        public int table_id { get; set; }
        public string table_name { get; set; }
        public DateTime date_id { get; set; }
        public int null_columns { get; set; }
        public int amount_of_trs_data { get; set; }
        public float diff_last_trans { get; set; }
        public string big_deviation { get; set; }
    }
}