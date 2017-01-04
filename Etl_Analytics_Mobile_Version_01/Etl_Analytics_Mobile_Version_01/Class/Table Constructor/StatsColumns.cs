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
    public class StatsColumns
    {
        public int TABLE_ID { get; set; }
        public DateTime DATE_ID { get; set; }
        public string OWNER { get; set; }
        public string TABLE_NAME { get; set; }
        public string COLUMN_NAME { get; set; }
        public int NULL_ROWS { get; set; }
        public int NOT_NULL_ROWS { get; set; }
        public float FILL_PERCENTAGE { get; set; }
        public string LOW_OCCUPANCY { get; set; }
    }
}