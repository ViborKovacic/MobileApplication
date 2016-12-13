using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;

namespace Etl_Analytics_Mobile_Version_01.Class
{
    public class SlidingTabsFragment : Fragment
    {
        private SlidingTabScrollView mSlidingTabScrollView;
        private ViewPager mViewPager;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
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
            List<string> items = new List<string>();

            public SamplePagerAdapter() : base()
            {
                items.Add("Chart");
                items.Add("Table");
                items.Add("Description");
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
                View view = LayoutInflater.From(container.Context).Inflate(Resource.Layout.pager_item, container, false);
                container.AddView(view);

                if (position == 0)
                {
                    //First slide
                    view = null;
                } 
                else if (position == 1)
                {
                    ExpandableListViewAdapter mAdapter;
                    ExpandableListView expandableListView;
                    List<string> group = new List<string>();
                    Dictionary<string, List<string>> dicMyMap = new Dictionary<string, List<string>>();
                    WebService webService;
                    List<LogTable> logTable;

                    expandableListView = view.FindViewById<ExpandableListView>(Resource.Id.expendableListView);

                    webService = new WebService();
                    logTable = new List<LogTable>();
                    logTable = webService.GetAllDataLogTable();
                    int counter = 0;

                    foreach (LogTable row in logTable)
                    {
                        List<string> groupA = new List<string>();
                        group.Add((counter + 1).ToString() + " " + row.PROCEDURE_NAME.ToString() + " " + row.DATE_TIME.ToString() + " " + row.ACTION.ToString()); ;
                        groupA.Add(" Id procedure: " + row.PROCEDURE_ID.ToString());
                        //groupA.Add(" Ime procedure: " + row.PROCEDURE_NAME.ToString());
                        if (row.ERROR_DESCRIPTION != null)
                        {
                            groupA.Add(" Error: " + row.ERROR_DESCRIPTION);
                        }

                        dicMyMap.Add(group[counter], groupA);
                        counter++;
                    }


                    mAdapter = new ExpandableListViewAdapter(container.Context, group, dicMyMap);
                    expandableListView.SetAdapter(mAdapter);
                }
                else if (position == 2)
                {
                    //third slide
                    view = null;
                }

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