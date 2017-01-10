using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using Etl_Analytics_Mobile_Version_01.Class;

namespace Etl_Analytics_Mobile_Version_01.Fragments.StatsColumnsFragments
{
    public class FragmentStatsColumnsAllTable : Android.Support.V4.App.Fragment
    {
        private View view;
        private ListView mListView;
        private List<StatsColumns> mListStatsColumns;
        private WebService webService;
        private StatsColumnsAdapter mTableAdapter;
        private EditText mSearch;
        private LinearLayout mConatainer;
        private Context mContext;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            mListStatsColumns = new List<StatsColumns>();
            webService = new WebService();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.StatsColumnsAllTable, container, false);
            mListView = view.FindViewById<ListView>(Resource.Id.listViewStatsColumns);
            mSearch = view.FindViewById<EditText>(Resource.Id.etSearch);
            mConatainer = view.FindViewById<LinearLayout>(Resource.Id.LinearLayoutContainer);
            mContext = container.Context;

            mListStatsColumns = webService.GetAllDataStatsColumns();

            mTableAdapter = new StatsColumnsAdapter(container.Context, Resource.Layout.StatsColumnsRow, mListStatsColumns);
            mListView.Adapter = mTableAdapter;

            mSearch.TextChanged += MSearch_TextChanged;

            return view;
        }

        private void MSearch_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            List<StatsColumns> searchedStatsColumns = (from row in mListStatsColumns
                                                       where row.TABLE_NAME.Contains(mSearch.Text, StringComparison.OrdinalIgnoreCase)
                                                       || row.COLUMN_NAME.Contains(mSearch.Text, StringComparison.OrdinalIgnoreCase)
                                                       || row.DATE_ID.ToString().Contains(mSearch.Text, StringComparison.OrdinalIgnoreCase)
                                                       || row.FILL_PERCENTAGE.ToString().Contains(mSearch.Text, StringComparison.OrdinalIgnoreCase)
                                                       select row).ToList<StatsColumns>();

            mTableAdapter = new StatsColumnsAdapter(mContext, Resource.Layout.StatsColumnsRow, searchedStatsColumns);
            mListView.Adapter = mTableAdapter;
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            inflater.Inflate(Resource.Menu.fragmentAllTable, menu);
            base.OnCreateOptionsMenu(menu, inflater);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.search:
                    MyAnimation anim = new MyAnimation(mListView, mListView.Height - mSearch.Height);
                    anim.Duration = 500;
                    mListView.StartAnimation(anim);

                    anim.AnimationStart += Anim_AnimationStartDown;
                    mConatainer.Animate().TranslationYBy(-mSearch.Height).SetDuration(500).Start();

                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        private void Anim_AnimationStartDown(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}