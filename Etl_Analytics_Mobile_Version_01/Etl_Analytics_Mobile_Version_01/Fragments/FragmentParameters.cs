using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using Etl_Analytics_Mobile_Version_01.Class;

namespace Etl_Analytics_Mobile_Version_01.Fragments
{
    public class FragmentParameters : Android.Support.V4.App.Fragment
    {
        private View mView;
        private TextView mTitleMain;
        private TextView mTitleDate;
        private TextView mTitleTable;
        private TextView mTitleColumn;

        private EditText mTextDate;
        private EditText mTextTable;
        private EditText mTextColumn;

        private Button mButtonSave;

        //private Dictionary<string, string> mDicParamVar;
        private List<ParametersVariable> mListParamVariable;
        private WebService mWebService;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            mWebService = new WebService();
            mListParamVariable = new List<ParametersVariable>();
            //mDicParamVar = new Dictionary<string, string>();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mView = inflater.Inflate(Resource.Layout.FragmentParameters, container, false);
            mTitleMain = mView.FindViewById<TextView>(Resource.Id.fragmentParametersTitle);
            mTitleDate = mView.FindViewById<TextView>(Resource.Id.fragmentParametersDataByDate);
            mTitleTable = mView.FindViewById<TextView>(Resource.Id.fragmentParametersLimitTable);
            mTitleColumn = mView.FindViewById<TextView>(Resource.Id.fragmentParametersLimitColumn);

            mTextDate = mView.FindViewById<EditText>(Resource.Id.deleteDataByDay);
            mTextTable = mView.FindViewById<EditText>(Resource.Id.precentageLimitValueTable);
            mTextColumn = mView.FindViewById<EditText>(Resource.Id.precentageLimitValueColumn);

            mTextDate.ClearFocus();
            mTextTable.ClearFocus();
            mTextColumn.ClearFocus();

            mButtonSave = mView.FindViewById<Button>(Resource.Id.frgParaSave);

            mTitleMain.Text = "Configuration Parameters variable";
            mTitleDate.Text = "Set days in past";
            mTitleTable.Text = "Set limit precentage of value for table";
            mTitleColumn.Text = "Set limit precentage of value for column";

            mListParamVariable = mWebService.GetAllDataParametersValue();

            foreach (ParametersVariable row in mListParamVariable)
            {
                //mDicParamVar.Add(row.PARAMETER_CODE, row.PARAMETER_VALUE);

                if (row.PARAMETER_CODE == "DELETE_DATA_BY_DAY")
                {
                    mTextDate.Text = row.PARAMETER_VALUE.ToString();
                }
                else if (row.PARAMETER_CODE == "PRECENTAGE_LIMIT_VALUE_TABLE")
                {
                    mTextTable.Text = row.PARAMETER_VALUE.ToString();
                }
                else if (row.PARAMETER_CODE == "PRECENTAGE_LIMIT_VALUE_COLUMN")
                {
                    mTextColumn.Text = row.PARAMETER_VALUE.ToString();
                }
            }

            mButtonSave.Click += MButtonSave_Click;

            return mView;
        }

        private void MButtonSave_Click(object sender, EventArgs e)
        {
            //foreach (KeyValuePair<string, string> header in mDicParamVar)
            //{
            //    mWebService.UpdateParametersVariable(header.Key, header.Value);
            //}
        }
    }
}