using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using Etl_Analytics_Mobile_Version_01.Class;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using Android.Support.V4.View;
using Android.Content;
using System.Linq;
using System;

namespace Etl_Analytics_Mobile_Version_01.Fragments
{
    public class FragmentAllTable : Android.Support.V4.App.Fragment
    {
        private ListView mListView;
        private StatsTableAdapter mStatsTableAdapter;
        private List<StatsTables> mListStatsTable;
        private WebService mWebService;

        private EditText mSearch;

        private bool mAnimatedDown;
        private bool mIsAnimating;
        private ViewPager mPagerActionBar;
        private LinearLayout mLinearLayoutActionBar;
        private Context mNest;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            mListStatsTable = new List<StatsTables>();
            mWebService = new WebService();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.StatsTableAllTable, container, false);
            mListView = view.FindViewById<ListView>(Resource.Id.listViewStatsTable);

            View mojPogled = inflater.Inflate(Resource.Layout.Action_bar, container, false);
            mPagerActionBar = mojPogled.FindViewById<ViewPager>(Resource.Id.pagerActionBar);
            mSearch = mojPogled.FindViewById<EditText>(Resource.Id.etSearch);
            mLinearLayoutActionBar = mojPogled.FindViewById<LinearLayout>(Resource.Id.linearLayoutActionBar);

            mSearch.TextChanged += MSearch_TextChanged;
            mNest = container.Context;

            mListStatsTable = mWebService.GetAllDataStatsTable();

            mStatsTableAdapter = new StatsTableAdapter(container.Context, Resource.Layout.StatsTableRow, mListStatsTable);
            mListView.Adapter = mStatsTableAdapter;

            return view;
        }

        private void MSearch_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            List<StatsTables> searchedList = (from table in mListStatsTable
                                              where table.table_name.Contains(mSearch.Text, StringComparison.OrdinalIgnoreCase)
                                              select table).ToList<StatsTables>();

            mStatsTableAdapter = new StatsTableAdapter(mNest, Resource.Layout.StatsTableRow, searchedList);
            mListView.Adapter = mStatsTableAdapter;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            HasOptionsMenu = true;
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            inflater.Inflate(Resource.Menu.fragmentChartToolBar, menu);
            base.OnCreateOptionsMenu(menu, inflater);
        }
    }
}