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
using Android.Support.V4.App;
using Etl_Analytics_Mobile_Version_01.Class.Fragments;

namespace Etl_Analytics_Mobile_Version_01.Class
{
    public class ActionBarFragmentAdapter : FragmentPagerAdapter
    {
        private int page_number = 4;
        private Context mContext;
        
        public ActionBarFragmentAdapter(Context context, Android.Support.V4.App.FragmentManager fm) : base(fm)
        {
            mContext = context;
        }

        public override int Count
        {
            get{ return page_number; }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0:
                    return new FragmentChart();
                case 1:
                    return new FragmentBigDeviation();
                default:
                    return new FragmentChart();
            }
        }
    }
}