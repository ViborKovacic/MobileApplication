using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using System;
using System.Linq;
using Android.Graphics;

namespace Etl_Analytics_Mobile_Version_01.Class
{
    public class SlidingTabsFragment : Fragment
    {
        private SlidingTabScrollView mSlidingTabScrollView;
        private ViewPager mViewPager;
        public static string mSearchText;
        private static ViewGroup mviewGroup;
        public static int test;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            mviewGroup = container;
            return inflater.Inflate(Resource.Layout.fragment_sample, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            mSlidingTabScrollView = view.FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs);
            mViewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);
            mViewPager.Adapter = new SamplePagerAdapter();

            mSlidingTabScrollView.ViewPager = mViewPager;
        }

        public class SamplePagerAdapter : PagerAdapter
        {
            private static List<StatsTables> listStatsTable;
            private static StatsTableAdapter listAdapter;
            private static ListView listViewStatsTable;
            private static WebService webService;
            private static View view;
            List<string> items = new List<string>();

            public SamplePagerAdapter() : base()
            {
                items.Add("Chart");
                items.Add("Table");
                items.Add("Description");
            }

            public override IParcelable SaveState()
            {
                return base.SaveState();
            }

            public override int Count
            {
                get { return items.Count; }
            }

            public override bool IsViewFromObject(View view, Java.Lang.Object obj)
            {
                return view == obj;
            }

            public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
            {
                webService = new WebService();
                listStatsTable = new List<StatsTables>();
                listStatsTable = webService.GetAllDataStatsTable();

                if (position == 0)
                {
                    view = LayoutInflater.From(container.Context).Inflate(Resource.Layout.LogTableChart, container, false);
                }
                else if (position == 1)
                {

                }
                else if (position == 2)
                {
                    view = LayoutInflater.From(container.Context).Inflate(Resource.Layout.StatsTableAllTable, container, false);
                    listViewStatsTable = view.FindViewById<ListView>(Resource.Id.listViewStatsTable);

                        List<StatsTables> searchedTable = (from table in listStatsTable
                                                           where table.big_deviation.Contains("YES", StringComparison.OrdinalIgnoreCase)
                                                           select table).ToList<StatsTables>();
                        listAdapter = new StatsTableAdapter(container.Context, Resource.Layout.StatsTableRow, searchedTable);

                    listViewStatsTable.Adapter = listAdapter;
                    mviewGroup = container;
                }

                container.AddView(view);
                test = position;

                return view;
            }

            public string GetHeaderTitle(int position)
            {
                return items[position];
            }

            public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object obj)
            {
                container.RemoveView((View)obj);
            }
        }
    }
}