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
    public class Fragment2View : RecyclerView.ViewHolder
    {
        public View mMainView { get; set; }
        public TextView mLogId { get; set; }
        public TextView mProcedureId { get; set; }
        public TextView mProcedureName { get; set; }
        public TextView mDate { get; set; }
        public TextView mAction { get; set; }
        public TextView mErrorDescription { get; set; }

        public Fragment2View(View view) : base(view)
        {
            mMainView = view;
        }
    }
}