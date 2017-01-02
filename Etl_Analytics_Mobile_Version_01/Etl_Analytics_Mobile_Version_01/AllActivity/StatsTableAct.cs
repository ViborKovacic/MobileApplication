using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Etl_Analytics_Mobile_Version_01.Fragments;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "SlidingTabAct", Icon = "@drawable/xs", Theme ="@style/MyTheme2")]
    public class StatsTableAct : ActionBarActivity
    {
        private LinearLayout layoutChart;
        private LinearLayout layoutBigDeviation;
        private LinearLayout layoutAllTable;
        private SupportFragment mCurrentFragment;
        private FragmentChart mFragmentChart;
        private FragmentAllTable mFragmentAllTable;
        private FragmentBigDeviation mFragmentBigDeviation;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Action_bar);

            layoutChart = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            layoutBigDeviation = FindViewById<LinearLayout>(Resource.Id.linearLayout2);
            layoutAllTable = FindViewById<LinearLayout>(Resource.Id.linearLayout3);

            if (SupportFragmentManager.FindFragmentByTag("FragmentChart") != null)
            {
                mFragmentChart = SupportFragmentManager.FindFragmentByTag("FragmentChart") as FragmentChart;
            }
            else
            {
                mFragmentChart = new FragmentChart();
                mFragmentAllTable = new FragmentAllTable();
                mFragmentBigDeviation = new FragmentBigDeviation();

                var trans = SupportFragmentManager.BeginTransaction();
                trans.Add(Resource.Id.fragmenContainerActionBar, mFragmentChart, "FragmentChart");
                trans.Commit();

                mCurrentFragment = mFragmentChart;                
            }

            layoutChart.Click += LayoutChart_Click;
            layoutBigDeviation.Click += LayoutBigDeviation_Click;
            layoutAllTable.Click += LayoutAllTable_Click;
        }

        private void LayoutChart_Click(object sender, System.EventArgs e)
        {
            ReplaceFragment(mFragmentChart);
        }

        private void LayoutBigDeviation_Click(object sender, System.EventArgs e)
        {
            ReplaceFragment(mFragmentBigDeviation);
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