using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Etl_Analytics_Mobile_Version_01.Class;
using Android.Views.InputMethods;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "Table statistics", Icon = "@drawable/icon")]
    public class TestStatsTableAct : Activity
    {
        private static bool mAnimatedDown;
        private static bool mIsAnimating;
        private EditText mSearch;
        private static LinearLayout mContainer;
        private View test;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SlidingBar);
            mSearch = FindViewById<EditText>(Resource.Id.etSearch);           
            mContainer = FindViewById<LinearLayout>(Resource.Id.llContainer); ;
            test = FindViewById<View>(Resource.Id.testView);

            mSearch.Alpha = 0;
            mSearch.TextChanged += MSearch_TextChanged;

            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            SlidingTabsFragment fragment = new SlidingTabsFragment();
            transaction.Replace(Resource.Id.sample_content_fragment, fragment);
            transaction.Commit();

            //HideSoftKeyboard();
        }

        public void MSearch_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            SlidingTabsFragment fragment = new SlidingTabsFragment();
            SlidingTabsFragment.mSearchText = mSearch.Text;
            transaction.Replace(Resource.Id.sample_content_fragment, fragment);
            transaction.Commit();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {

                case Resource.Id.search:
                    //Search icon has been clicked

                    if (mIsAnimating)
                    {
                        return true;
                    }

                    if (!mAnimatedDown)
                    {
                        //Listview is up
                        MyAnimation anim = new MyAnimation(test, test.Height - mSearch.Height);
                        anim.Duration = 500;
                        test.StartAnimation(anim);
                        anim.AnimationStart += anim_AnimationStartDown;
                        anim.AnimationEnd += anim_AnimationEndDown;
                        mContainer.Animate().TranslationYBy(mSearch.Height).SetDuration(500).Start();
                    }

                    else
                    {
                        //Listview is down
                        MyAnimation anim = new MyAnimation(test, test.Height + mSearch.Height);
                        anim.Duration = 500;
                        test.StartAnimation(anim);
                        anim.AnimationStart += anim_AnimationStartUp;
                        anim.AnimationEnd += anim_AnimationEndUp;
                        mContainer.Animate().TranslationYBy(-mSearch.Height).SetDuration(500).Start();
                    }

                    mAnimatedDown = !mAnimatedDown;
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        //public void HideSoftKeyboard()
        //{
        //    InputMethodManager manager = (InputMethodManager)GetSystemService(Context.InputMethodService);
        //    manager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);
        //}

        void anim_AnimationEndUp(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
        {
            mIsAnimating = false;
            mSearch.ClearFocus();
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Context.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
        }

        void anim_AnimationEndDown(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
        {
            mIsAnimating = false;
        }

        void anim_AnimationStartDown(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            mIsAnimating = true;
            mSearch.Animate().AlphaBy(1.0f).SetDuration(500).Start();
        }

        void anim_AnimationStartUp(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            mIsAnimating = true;
            mSearch.Animate().AlphaBy(-1.0f).SetDuration(300).Start();
        }
    }
}