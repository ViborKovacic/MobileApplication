using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Etl_Analytics_Mobile_Version_01.Fragments.StatsColumnsFragments;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "StatsColumnsAct", Icon = "@drawable/xs", Theme = "@style/MyTheme2")]
    public class StatsColumnsAct : ActionBarActivity
    {
        private LinearLayout mLayoutChart;
        private LinearLayout mLayoutDeviation;
        private LinearLayout mLayoutAllTable;
        private FragmentStatsColumnsChart mFragmentChart;
        private FragmentStatsColumnsAllTable mFragmentAllTable;
        private SupportFragment mCurrentFragment;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Action_bar);

            mLayoutChart = FindViewById<LinearLayout>(Resource.Id.linerLayoutChart);
            mLayoutDeviation = FindViewById<LinearLayout>(Resource.Id.linearLayoutDeviation);
            mLayoutAllTable = FindViewById<LinearLayout>(Resource.Id.linearLayoutAllTable);


            if (SupportFragmentManager.FindFragmentByTag("FragmentChart") != null)
            {
                mFragmentChart = SupportFragmentManager.FindFragmentByTag("FragmentChart") as FragmentStatsColumnsChart;
            }
            else
            {
                mFragmentChart = new FragmentStatsColumnsChart();
                mFragmentAllTable = new FragmentStatsColumnsAllTable();

                var trans = SupportFragmentManager.BeginTransaction();
                trans.Add(Resource.Id.fragmenContainerActionBar, mFragmentChart, "FragmentChart");
                trans.Commit();

                mCurrentFragment = mFragmentChart;
            }

            mLayoutChart.Click += LayoutChart_Click;
            mLayoutDeviation.Click += LayoutBigDeviation_Click;
            mLayoutAllTable.Click += LayoutAllTable_Click;
        }

        private void LayoutChart_Click(object sender, System.EventArgs e)
        {
            ReplaceFragment(mFragmentChart);
        }

        private void LayoutBigDeviation_Click(object sender, System.EventArgs e)
        {
            ReplaceFragment(mFragmentChart);
        }

        private void LayoutAllTable_Click(object sender, System.EventArgs e)
        {
            ReplaceFragment(mFragmentAllTable);
        }

        private void ReplaceFragment(SupportFragment fragment)
        {
            if (fragment.IsVisible)
            {
                return;
            }
            else
            {
                var trans = SupportFragmentManager.BeginTransaction();
                trans.Replace(Resource.Id.fragmenContainerActionBar, fragment);
                trans.AddToBackStack(null);
                trans.Commit();

                mCurrentFragment = fragment;
            }
        }
    }
}