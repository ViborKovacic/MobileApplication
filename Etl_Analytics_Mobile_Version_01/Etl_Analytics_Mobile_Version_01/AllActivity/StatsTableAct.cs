using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Etl_Analytics_Mobile_Version_01.Class;


namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "SlidingTabAct", Icon = "@drawable/xs", Theme ="@style/MyTheme2")]
    public class StatsTableAct : AppCompatActivity
    {
        private ViewPager pagerActionBar;
        private TabLayout tabLayout;
        private ActionBarFragmentAdapter mAdapter;
        private string mHelpVariable;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Action_bar);

            pagerActionBar = FindViewById<ViewPager>(Resource.Id.pagerActionBar);
            tabLayout = FindViewById<TabLayout>(Resource.Id.slidingTabsActionBar);

            Bundle test = Intent.Extras;
            if (test != null)
            {
                mHelpVariable = test.GetString("StatsTable");
                if (mHelpVariable != null)
                {
                    mHelpVariable = "StastTable";
                }
                else
                {
                    mHelpVariable = test.GetString("StatsColumns");
                    if (mHelpVariable != null)
                    {
                        mHelpVariable = "StatsColumns";
                    }
                }
            }

            mAdapter = new ActionBarFragmentAdapter(this, SupportFragmentManager, mHelpVariable);
            pagerActionBar.Adapter = mAdapter;

            tabLayout.SetupWithViewPager(pagerActionBar);
            for (int position = 0; position < tabLayout.TabCount; position++)
            {
                TabLayout.Tab tab = tabLayout.GetTabAt(position);
                tab.SetCustomView(mAdapter.GetTabView(position));
            }
        }
    }
}