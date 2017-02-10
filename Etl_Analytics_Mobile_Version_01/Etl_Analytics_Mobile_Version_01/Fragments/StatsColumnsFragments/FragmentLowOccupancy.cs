using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using Etl_Analytics_Mobile_Version_01.Class;
using Android.Text;
using Java.Lang;
using Android.Views.InputMethods;
using Etl_Analytics_Mobile_Version_01.AllActivity;
using Design = Android.Support.Design.Widget.TextInputLayout;

namespace Etl_Analytics_Mobile_Version_01.Fragments.StatsColumnsFragments
{
    public class FragmentLowOccupancy : Android.Support.V4.App.Fragment, ITextWatcher
    {
        private View view;
        private ListView mListView;
        private List<StatsColumns> mListStatsColumns;
        private WebService webService;
        private StatsColumnsAdapter mTableAdapter;

        private EditText mSearch;
        private Design mDesign;
        private LinearLayout mContainerListView;
        private Context mContext;
        private bool mAnimatedDown;
        private bool mIsAnimating;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            mListStatsColumns = new List<StatsColumns>();
            webService = new WebService();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.StatsColumnsAllTable, container, false);
            mListView = view.FindViewById<ListView>(Resource.Id.listViewStatsColumns);
            mSearch = view.FindViewById<EditText>(Resource.Id.etSearch);
            mContainerListView = view.FindViewById<LinearLayout>(Resource.Id.containerStatsColumns);
            mDesign = view.FindViewById<Design>(Resource.Id.HelpEr);

            mContext = container.Context;

            mDesign.Alpha = 0;
            mDesign.Focusable = false;

            mSearch.Focusable = false;
            mSearch.AddTextChangedListener(this);

            mListStatsColumns = webService.GetAllDataStatsColumns();

            List<StatsColumns> searchedTable = (from table in mListStatsColumns
                                               where table.LOW_OCCUPANCY.Contains("YES", StringComparison.OrdinalIgnoreCase)
                                               select table).ToList<StatsColumns>();

            mTableAdapter = new StatsColumnsAdapter(mContext, Resource.Layout.StatsColumnsRow, searchedTable);
            mListView.Adapter = mTableAdapter;

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            HasOptionsMenu = true;
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            inflater.Inflate(Resource.Menu.fragmentAction, menu);
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
            List<StatsColumns> searchedList = (from table in mListStatsColumns
                                               where table.COLUMN_NAME.Contains(mSearch.Text, StringComparison.OrdinalIgnoreCase)
                                               select table).ToList<StatsColumns>();

            mTableAdapter = new StatsColumnsAdapter(mContext, Resource.Layout.StatsColumnsRow, searchedList);
            mListView.Adapter = mTableAdapter;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
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

                case Resource.Id.descriptionAction:

                    Bundle bundle = new Bundle();
                    bundle.PutString("StatsColumns", "StatsColumnsAction");

                    var trans = FragmentManager.BeginTransaction();
                    DescritpionDialog descriptionDialog = new DescritpionDialog();

                    descriptionDialog.Arguments = bundle;
                    descriptionDialog.Show(trans, "Dialog Fragment");

                    return true;

                case 16908332:

                    Intent intent = new Intent(mContext, typeof(MainPageAct));
                    this.StartActivity(intent);

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
                MyAnimation anim = new MyAnimation(mContainerListView, mContainerListView.Height - mDesign.Height);
                anim.Duration = 500;
                mContainerListView.StartAnimation(anim);

                anim.AnimationStart += Anim_AnimationStartDown;
                anim.AnimationEnd += Anim_AnimationEndDown;
                mContainerListView.Animate().TranslationYBy(mDesign.Height).SetDuration(500).Start();
            }
            else
            {
                //down
                MyAnimation anim = new MyAnimation(mContainerListView, mContainerListView.Height + mDesign.Height);
                anim.Duration = 500;
                mContainerListView.StartAnimation(anim);

                anim.AnimationStart += Anim_AnimationStartUp;
                anim.AnimationEnd += Anim_AnimationEndUp;
                mContainerListView.Animate().TranslationYBy(-mDesign.Height).SetDuration(500).Start();
            }
            mAnimatedDown = !mAnimatedDown;
        }

        private void Anim_AnimationEndUp(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
        {
            mIsAnimating = false;


            if (mSearch.HasFocus == true)
            {
                InputMethodManager inputManager = (InputMethodManager)mContext.GetSystemService(Context.InputMethodService);
                inputManager.ToggleSoftInput(0, 0);

                mSearch.ClearFocus();
            }
        }

        private void Anim_AnimationEndDown(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
        {
            mIsAnimating = false;
        }

        private void Anim_AnimationStartDown(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            mIsAnimating = true;
            mDesign.Animate().AlphaBy(1.0f).SetDuration(500).Start();
            mSearch.Focusable = true;
            mSearch.FocusableInTouchMode = true;
        }

        private void Anim_AnimationStartUp(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            mIsAnimating = true;
            mDesign.Animate().AlphaBy(-1.0f).SetDuration(300).Start();
        }
    }
}
