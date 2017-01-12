using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using Etl_Analytics_Mobile_Version_01.Class;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using Android.Support.V4.View;
using Android.Content;
using System.Linq;
using System;
using Android.Text;
using Java.Lang;
using Android.Views.InputMethods;

namespace Etl_Analytics_Mobile_Version_01.Fragments
{
    public class FragmentAllTable : Android.Support.V4.App.Fragment, ITextWatcher
    {
        private ListView mListView;
        private StatsTableAdapter mStatsTableAdapter;
        private List<StatsTables> mListStatsTable;
        private WebService mWebService;

        private EditText mSearch;        
        private LinearLayout mContainerListView;
        private Context mContext;
        private bool mKeyboard;
        private bool mAnimatedDown;
        private bool mIsAnimating;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            mListStatsTable = new List<StatsTables>();
            mWebService = new WebService();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.StatsTableAllTable, container, false);
            mListView = view.FindViewById<ListView>(Resource.Id.listViewStatsTable);
            mSearch = view.FindViewById<EditText>(Resource.Id.etSearch);
            mContainerListView = view.FindViewById<LinearLayout>(Resource.Id.containerListView);

            mContext = container.Context;

            mSearch.Alpha = 0;
            mSearch.AddTextChangedListener(this);
            

            mListStatsTable = mWebService.GetAllDataStatsTable();

            mStatsTableAdapter = new StatsTableAdapter(container.Context, Resource.Layout.StatsTableRow, mListStatsTable);
            mListView.Adapter = mStatsTableAdapter;

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            HasOptionsMenu = true;
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            inflater.Inflate(Resource.Menu.fragmentAllTable, menu);
            base.OnCreateOptionsMenu(menu, inflater);
        }

        public void AfterTextChanged(IEditable s)
        {

        }

        public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {

        }

        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            List<StatsTables> searchedList = (from table in mListStatsTable
                                              where table.table_name.Contains(mSearch.Text, StringComparison.OrdinalIgnoreCase)
                                              select table).ToList<StatsTables>();

            mStatsTableAdapter = new StatsTableAdapter(mContext, Resource.Layout.StatsTableRow, searchedList);
            mListView.Adapter = mStatsTableAdapter;
            mKeyboard = true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
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
                MyAnimation anim = new MyAnimation(mContainerListView, mContainerListView.Height - mSearch.Height);
                anim.Duration = 500;
                    mContainerListView.StartAnimation(anim);

                anim.AnimationStart += Anim_AnimationStartDown;
                anim.AnimationEnd += Anim_AnimationEndDown;
                    mContainerListView.Animate().TranslationYBy(mSearch.Height).SetDuration(500).Start();
            }
            else
            {
                //down
                MyAnimation anim = new MyAnimation(mContainerListView, mContainerListView.Height + mSearch.Height);
                anim.Duration = 500;
                mContainerListView.StartAnimation(anim);

                anim.AnimationStart += Anim_AnimationStartUp;
                anim.AnimationEnd += Anim_AnimationEndUp;
                    mContainerListView.Animate().TranslationYBy(-mSearch.Height).SetDuration(500).Start();
            }
            mAnimatedDown = !mAnimatedDown;
        }

        private void Anim_AnimationEndUp(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
        {
            mIsAnimating = false;
            mSearch.ClearFocus();

            if (mKeyboard == true)
            {            
                InputMethodManager inputManager = (InputMethodManager)mContext.GetSystemService(Context.InputMethodService);
                inputManager.ToggleSoftInput(0, 0);
            }

            mKeyboard = !mKeyboard;
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