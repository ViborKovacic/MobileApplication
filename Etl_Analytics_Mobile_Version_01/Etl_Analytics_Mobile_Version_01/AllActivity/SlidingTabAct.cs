using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Etl_Analytics_Mobile_Version_01.Class;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using Android.Views.InputMethods;


namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "Log table", MainLauncher = true, Icon = "@drawable/xs")]
    public class SlidingTabAct : Activity
    {
        private List<LogTable> mLogTable;
        WebService webService;
        private FrameLayout mFrameLayout;
        private EditText mSearch;
        private LinearLayout mContainer;
        private bool mAnimatedDown;
        private bool mIsAnimating;
        private ExpandableListViewAdapter mAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SlidingBar);

            mSearch = FindViewById<EditText>(Resource.Id.etSearch);
            mContainer = FindViewById<LinearLayout>(Resource.Id.llContainer);
            mFrameLayout = FindViewById<FrameLayout>(Resource.Id.sample_content_fragment);

            webService = new WebService();
            mLogTable = webService.GetAllDataLogTable();

            mSearch.Alpha = 0;
            mSearch.TextChanged += MSearch_TextChanged;

            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            SlidingTabsFragment fragment = new SlidingTabsFragment();
            transaction.Replace(Resource.Id.sample_content_fragment, fragment);
            transaction.Commit();

        }

        private void MSearch_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            ExpandableListView expandableListView;
            List<LogTable> searchLogTable = (from logTable in mLogTable where logTable.PROCEDURE_NAME.Contains(mSearch.Text.ToUpper()) select logTable).ToList<LogTable>();
            List<string> testLista = new List<string>();
            Dictionary<string, List<string>> dicMyMap = new Dictionary<string, List<string>>();

            expandableListView = FindViewById<ExpandableListView>(Resource.Id.expendableListView);
            int counter = 0;
            

            foreach (LogTable item in searchLogTable)
            {
                testLista.Add("Proba " + counter);
                List<string> itemTest = new List<string>();
                itemTest.Add(item.LOG_ID.ToString());
                itemTest.Add(item.PROCEDURE_ID.ToString());
                itemTest.Add(item.PROCEDURE_NAME.ToString());
                itemTest.Add(item.DATE_TIME.ToString());
                itemTest.Add(item.ACTION.ToString());
                //itemTest.Add(item.ERROR_DESCRIPTION.ToString());

                dicMyMap.Add(testLista[counter], itemTest);
                counter++;
            }


            mAdapter = new ExpandableListViewAdapter(this, testLista, dicMyMap);
            expandableListView.SetAdapter(mAdapter);

            //FragmentTransaction transaction = FragmentManager.BeginTransaction();
            //SlidingTabsFragment fragment = new SlidingTabsFragment();
            //transaction.Replace(Resource.Id.sample_content_fragment, fragment);
            //transaction.Commit();
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
                        MyAnimation anim = new MyAnimation(mContainer, mContainer.Height - mSearch.Height);
                        anim.Duration = 500;
                        mContainer.StartAnimation(anim);
                        anim.AnimationStart += anim_AnimationStartDown;
                        anim.AnimationEnd += anim_AnimationEndDown;
                        mContainer.Animate().TranslationYBy(mSearch.Height).SetDuration(500).Start();
                    }

                    else
                    {
                        //Listview is down
                        MyAnimation anim = new MyAnimation(mContainer, mContainer.Height + mSearch.Height);
                        anim.Duration = 500;
                        mContainer.StartAnimation(anim);
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