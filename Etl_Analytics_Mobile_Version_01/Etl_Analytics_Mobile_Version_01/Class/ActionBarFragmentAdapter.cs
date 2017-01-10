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
using Etl_Analytics_Mobile_Version_01.Fragments;
using Android.Support.V4.App;
using FragmentManagerSupport = Android.Support.V4.App.FragmentManager;
using FragmentSupport = Android.Support.V4.App.Fragment;
using Java.Lang;
using Android.Graphics;
using Etl_Analytics_Mobile_Version_01.Fragments.StatsColumnsFragments;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;

namespace Etl_Analytics_Mobile_Version_01.Class
{
    public class ActionBarFragmentAdapter : FragmentPagerAdapter
    {
        private int mPageNumber = 3;
        private string[] mTabNames = { "Chart", "Deviation", "All table" };
        private string[] mColumNames = { "Chart", "Low occupacy", "All table" };
        private Context mContext;
        private View view;
        private ImageView image;
        private TextView textView;
        private string mActivityName;
        private List<StatsTables> mListStatsTable;
        private bool mIsSearched;

        public ActionBarFragmentAdapter(Context context, FragmentManagerSupport fm, string activityName) : base(fm)
        {
            mContext = context;
            mActivityName = activityName;
        }

        public ActionBarFragmentAdapter(Context context, FragmentManagerSupport fm, string activityName, List<StatsTables> list, bool search) : base(fm)
        {
            mContext = context;
            mActivityName = activityName;
            mListStatsTable = list;
            mIsSearched = search;
        }
        public override int Count
        {
            get { return mPageNumber; }
        }

        public override FragmentSupport GetItem(int position)
        {
            if (mActivityName == "StastTable")
            {
                Bundle bundle = new Bundle();
                if (mIsSearched == true)
                {                    
                    bundle.PutString("StatsTable", "Yes");
                    SearchList list = new SearchList();
                    list.PutDataToSearchedListStatsTable(mListStatsTable);
                }
                else
                {
                    bundle.PutString("StatsTable", "No");
                }

                switch (position)
                {
                    case 0:                        
                        FragmentChart fragmentChart = new FragmentChart();
                        fragmentChart.Arguments = bundle;
                        return fragmentChart;
                    case 1:
                        return new FragmentBigDeviation();
                    case 2:
                        return new FragmentAllTable();
                    default:
                        return new FragmentChart();
                }
            }
            else
            {
                switch (position)
                {
                    case 0:
                        return new FragmentStatsColumnsChart();
                    case 1:
                        return new FragmentBigDeviation();
                    case 2:
                        return new FragmentStatsColumnsAllTable();
                    default:
                        return new FragmentStatsColumnsChart();
                }
            }
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            // Generate title based on item position
            return CharSequence.ArrayFromStringArray(mTabNames)[position];
        }

        public View GetTabView(int position)
        {
            view = LayoutInflater.From(mContext).Inflate(Resource.Layout.ActionBarTab, null);

            image = view.FindViewById<ImageView>(Resource.Id.imageActionBarTab);
            textView = view.FindViewById<TextView>(Resource.Id.textViewActionBarTab);

            textView.Text = mTabNames[position];
            textView.SetTextColor(Color.ParseColor("#FFFFFF"));

            if (mActivityName == "StastTable")
            {
                switch (position)
                {
                    case 0:
                        image.SetImageResource(Resource.Drawable.barchart_icon);
                        break;
                    case 1:
                        image.SetImageResource(Resource.Drawable.list_icon);
                        break;
                    case 2:
                        image.SetImageResource(Resource.Drawable.table_icon);
                        break;
                }
            }
            else
            {
                switch (position)
                {
                    case 0:
                        image.SetImageResource(Resource.Drawable.pie_chart_icon);
                        break;
                    case 1:
                        image.SetImageResource(Resource.Drawable.list_icon);
                        break;
                    case 2:
                        image.SetImageResource(Resource.Drawable.table_icon);
                        break;
                }
            }

            return view;
        }
    }
}