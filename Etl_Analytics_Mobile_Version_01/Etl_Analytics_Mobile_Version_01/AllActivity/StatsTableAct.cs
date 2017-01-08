using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Etl_Analytics_Mobile_Version_01.Class;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;


namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "SlidingTabAct", Icon = "@drawable/xs", Theme = "@style/MyTheme2")]
    public class StatsTableAct : AppCompatActivity
    {
        private ViewPager pagerActionBar;
        private TabLayout tabLayout;
        private SupportToolbar mToolbar;
        private ActionBarFragmentAdapter mAdapter;
        private EditText mSearch;
        private LinearLayout mConatainer;
        private ListView mListView;
        private string mHelpVariable;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Action_bar);

            pagerActionBar = FindViewById<ViewPager>(Resource.Id.pagerActionBar);
            tabLayout = FindViewById<TabLayout>(Resource.Id.slidingTabsActionBar);
            mToolbar = FindViewById<SupportToolbar>(Resource.Id.ActionBarToolbar);
            mListView = FindViewById<ListView>(Resource.Id.listViewStatsColumns);
            mConatainer = FindViewById<LinearLayout>(Resource.Id.LinearLayoutContainer);
            mSearch = FindViewById<EditText>(Resource.Id.etSearch);

            mSearch.Alpha = 0;

            mToolbar.Title = "Table statistics";

            SetSupportActionBar(mToolbar);

            SupportActionBar.SetHomeButtonEnabled(true);
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
            pagerActionBar.Adapter = mAdapter;

            tabLayout.SetupWithViewPager(pagerActionBar);
            for (int position = 0; position < tabLayout.TabCount; position++)
            {
                TabLayout.Tab tab = tabLayout.GetTabAt(position);
                tab.SetCustomView(mAdapter.GetTabView(position));
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.searchImage:

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
            //throw new NotImplementedException();
        }
    }
}