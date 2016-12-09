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
    public class UserTable
    {
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string USER_NAME { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public int USER_TYPE { get; set; }
    }
}