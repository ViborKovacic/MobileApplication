using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Etl_Analytics_Mobile_Version_01.Class;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private EditText mSearch;
        private LinearLayout mLinearLayoutActionBar;
        private string mHelpVariable;
        private bool mAnimatedDown;
        private bool mIsAnimating;
        private List<StatsTables> mListStatsTables;
        private List<StatsColumns> mListStatsColumns;
        private WebService mWebService = new WebService();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Action_bar);

            mListStatsTables = new List<StatsTables>();
            mListStatsTables = mWebService.GetAllDataStatsTable();

            mPagerActionBar = FindViewById<ViewPager>(Resource.Id.pagerActionBar);
            mTabLayout = FindViewById<TabLayout>(Resource.Id.slidingTabsActionBar);
            mToolbar = FindViewById<SupportToolbar>(Resource.Id.ActionBarToolbar);
            mLinearLayoutActionBar = FindViewById<LinearLayout>(Resource.Id.linearLayoutActionBar);
            mSearch = FindViewById<EditText>(Resource.Id.etSearch);

            mSearch.Alpha = 0;
            mSearch.Focusable = false;

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
            mPagerActionBar.Adapter = mAdapter;
            mTabLayout.SetupWithViewPager(mPagerActionBar);

            mSearch.TextChanged += MSearch_TextChanged;

            for (int position = 0; position < mTabLayout.TabCount; position++)
            {
                TabLayout.Tab tab = mTabLayout.GetTabAt(position);
                tab.SetCustomView(mAdapter.GetTabView(position));
            }
        }

        private void MSearch_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            List<StatsTables> searchedList = (from table in mListStatsTables
                                              where table.table_name.Contains(mSearch.Text, StringComparison.OrdinalIgnoreCase)
                                              select table).ToList<StatsTables>();

            mAdapter = new ActionBarFragmentAdapter(this, SupportFragmentManager, mHelpVariable, searchedList, true);
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
            switch (item.ItemId)
            {
                case Resource.Id.fragmentChartSearchImage:
                    if (mIsAnimating)
                    {
                        return true;
                    }
                    else
                    {
                        MyAnimation();
                    }
                    
                    return true;

                case Resource.Id.fragmentActionSearchImage:
                    if (mIsAnimating)
                    {
                        return true;
                    }
                    else
                    {
                        MyAnimation();
                    }

                    return true;

                case Resource.Id.fragmentAllTableSearchImage:
                    if (mIsAnimating)
                    {
                        return true;
                    }
                    else
                    {
                        MyAnimation();
                    }

                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        private void MyAnimation()
        {
            if (!mAnimatedDown)
            {
                //up
                MyAnimation anim = new MyAnimation(mPagerActionBar, mPagerActionBar.Height - mSearch.Height);
                anim.Duration = 500;
                mPagerActionBar.StartAnimation(anim);

                anim.AnimationStart += Anim_AnimationStartDown;
                anim.AnimationEnd += Anim_AnimationEndDown;
                mLinearLayoutActionBar.Animate().TranslationYBy(mSearch.Height).SetDuration(500).Start();
            }
            else
            {
                //down
                MyAnimation anim = new MyAnimation(mPagerActionBar, mPagerActionBar.Height + mSearch.Height);
                anim.Duration = 500;
                mPagerActionBar.StartAnimation(anim);

                anim.AnimationStart += Anim_AnimationStartUp;
                anim.AnimationEnd += Anim_AnimationEndUp;
                mLinearLayoutActionBar.Animate().TranslationYBy(-mSearch.Height).SetDuration(500).Start();
            }
            mAnimatedDown = !mAnimatedDown;
        }

        private void Anim_AnimationEndUp(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
        {
            mIsAnimating = false;
            mSearch.ClearFocus();
            //InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Context.InputMethodService);
            //inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
        }

        private void Anim_AnimationEndDown(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
        {
            mIsAnimating = false;
        }

        private void Anim_AnimationStartDown(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            mIsAnimating = true;
            mSearch.Animate().AlphaBy(1.0f).SetDuration(500).Start();
            mSearch.Focusable = true;
            mSearch.FocusableInTouchMode = true;
        }

        private void Anim_AnimationStartUp(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            mIsAnimating = true;
            mSearch.Animate().AlphaBy(-1.0f).SetDuration(300).Start();
        }
    }
}