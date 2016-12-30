using Android.OS;
using Android.Views;
using Android.Widget;
using Etl_Analytics_Mobile_Version_01.Class;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Etl_Analytics_Mobile_Version_01.Fragments
{
    public class FragmentBigDeviation : Android.Support.V4.App.Fragment
    {
        private ListView mListView;
        private StatsTableAdapter mStatsTableAdapter;
        private List<StatsTables> mListStatsTable;
        private WebService mWebService;
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

            mListStatsTable = mWebService.GetAllDataStatsTable();

            List<StatsTables> searchedTable = (from table in mListStatsTable
                                               where table.big_deviation.Contains("YES", StringComparison.OrdinalIgnoreCase)
                                               select table).ToList<StatsTables>();
            mStatsTableAdapter = new StatsTableAdapter(container.Context, Resource.Layout.StatsTableRow, searchedTable);

            mListView.Adapter = mStatsTableAdapter;
            return view;
        }
    }
}