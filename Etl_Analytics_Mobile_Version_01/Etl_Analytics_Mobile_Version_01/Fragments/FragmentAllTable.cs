using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using Etl_Analytics_Mobile_Version_01.Class;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;

namespace Etl_Analytics_Mobile_Version_01.Fragments
{
    public class FragmentAllTable : Android.Support.V4.App.Fragment
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

            mStatsTableAdapter = new StatsTableAdapter(container.Context, Resource.Layout.StatsTableRow, mListStatsTable);
            mListView.Adapter = mStatsTableAdapter;

            return view;
        }
    }
}