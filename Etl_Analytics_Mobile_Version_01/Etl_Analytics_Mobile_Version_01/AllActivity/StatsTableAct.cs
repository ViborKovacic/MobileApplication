using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Etl_Analytics_Mobile_Version_01.Class;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;


namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "SlidingTabAct", Icon = "@drawable/xs", Theme = "@style/MyTheme2")]
    public class StatsTableAct : AppCompatActivity
    {
        private ViewPager mPagerActionBar;
        private TabLayout mTabLayout;
        private SupportToolbar mToolbar;
        private ActionBarFragmentAdapter mAdapter;
        private string mHelpVariable;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Action_bar);

            mPagerActionBar = FindViewById<ViewPager>(Resource.Id.pagerActionBar);
            mTabLayout = FindViewById<TabLayout>(Resource.Id.slidingTabsActionBar);
            mToolbar = FindViewById<SupportToolbar>(Resource.Id.ActionBarToolbar);

            mToolbar.Title = "Table statistics";

            SetSupportActionBar(mToolbar);

            SupportActionBar.SetDisplayShowTitleEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            Bundle intentFormActivity = Intent.Extras;
            if (intentFormActivity != null)
            {
                mHelpVariable = intentFormActivity.GetString("StatsTable");
                if (mHelpVariable != null)
                {
                    mHelpVariable = "StastTable";
                }
                else
                {
                    mHelpVariable = intentFormActivity.GetString("StatsColumns");
                    if (mHelpVariable != null)
                    {
                        mHelpVariable = "StatsColumns";
                    }
                }
            }

            mAdapter = new ActionBarFragmentAdapter(this, SupportFragmentManager, mHelpVariable);
            mPagerActionBar.Adapter = mAdapter;
            mTabLayout.SetupWithViewPager(mPagerActionBar);

            for (int position = 0; position < mTabLayout.TabCount; position++)
            {
                TabLayout.Tab tab = mTabLayout.GetTabAt(position);
                tab.SetCustomView(mAdapter.GetTabView(position));
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return base.OnOptionsItemSelected(item);
        }
    }
}
