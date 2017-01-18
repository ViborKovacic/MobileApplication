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
    public class ParametersVariable
    {
        public int TABLE_ID { get; set; }
        public string PARAMETER_CODE { get; set; }
        public string PARAMETER_CODE_TYPE { get; set; }
        public string PARAMETER_DESCRIPTION { get; set; }
        public string PARAMETER_VALUE { get; set; }
    }
}