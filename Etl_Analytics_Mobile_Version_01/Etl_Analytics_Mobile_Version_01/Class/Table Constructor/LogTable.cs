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
    public class LogTable
    {
        public int LOG_ID { get; set; }
        public int PROCEDURE_ID { get; set; }
        public string PROCEDURE_NAME { get; set; }
        public DateTime DATE_TIME { get; set; }
        public string ACTION { get; set; }
        public string ERROR_DESCRIPTION { get; set; }
    }
}