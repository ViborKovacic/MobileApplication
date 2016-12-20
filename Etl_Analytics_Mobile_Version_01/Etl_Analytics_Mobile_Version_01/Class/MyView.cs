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
    public class MyView : RecyclerView.ViewHolder
    {
        public View mMainView { get; set; }
        public TextView mFIRST_NAME { get; set; }
        public TextView mLAST_NAME { get; set; }
        public TextView mUSER_NAME { get; set; }
        public TextView mEMAIL { get; set; }
        public TextView mPASSWORD { get; set; }
        public TextView mUSER_TYPE { get; set; }

        public MyView(View view) : base(view)
        {
            mMainView = view;
        }

    }
}