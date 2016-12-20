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
    public class MyView2 : RecyclerView.ViewHolder
    {
        public View mMainView { get; set; }

        public MyView2(View view) : base(view)
        {
            mMainView = view;
        }
    }
}