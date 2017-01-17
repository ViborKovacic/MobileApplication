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

namespace Etl_Analytics_Mobile_Version_01.Class
{
    public class ConfigTableHolder : RecyclerView.ViewHolder
    {
        public View mViewConfigTable { get; set; }
        public TextView mTitle { get; set; }
        public CheckBox mChecked { get; set; }
        public RecyclerView mConfigColumn { get; set; }
        public ConfigTableHolder(View view) : base(view)
        {
            mViewConfigTable = view;
        }
    }
}