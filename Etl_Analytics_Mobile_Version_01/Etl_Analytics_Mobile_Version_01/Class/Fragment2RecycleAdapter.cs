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
using Android.Support.V7.Widget;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using Android.Views.Animations;

namespace Etl_Analytics_Mobile_Version_01.Class
{
    public class Fragment2RecycleAdapter : RecyclerView.Adapter
    {
        private List<LogTable> mLIstLogTable;
        private RecyclerView mrecycleView;
        private Context mContext;
        private int mCurrentPosition = -1;
        public Fragment2RecycleAdapter(List<LogTable> listLogTable, RecyclerView recycleView, Context context)
        {
            mLIstLogTable = listLogTable;
            mrecycleView = recycleView;
            mContext = context;
        }

        public override int GetItemViewType(int position)
        {
           return Resource.Layout.RowCardView;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {       //RowCardView
                View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Fragment2RowCardView, parent, false);

                TextView txtLogId = row.FindViewById<TextView>(Resource.Id.txtLogId);
                TextView txtProcedureId = row.FindViewById<TextView>(Resource.Id.txtProcedureId);
                TextView txtProcedureName = row.FindViewById<TextView>(Resource.Id.txtProcedureName);
                TextView txtDate = row.FindViewById<TextView>(Resource.Id.txtDate);
                TextView txtAction = row.FindViewById<TextView>(Resource.Id.txtAction);
                TextView txtErrorDescription = row.FindViewById<TextView>(Resource.Id.txtErrorDescription);

                Fragment2View view = new Fragment2View(row)
                {
                    mLogId = txtLogId,
                    mProcedureId = txtProcedureId,
                    mProcedureName = txtProcedureName,
                    mDate = txtDate,
                    mAction = txtAction,
                    mErrorDescription = txtErrorDescription
                };

                return view;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
                Fragment2View myholder = holder as Fragment2View;
                int indexInvert = (mLIstLogTable.Count - 1) - position;
                myholder.mLogId.Text = mLIstLogTable[indexInvert].LOG_ID.ToString();
                myholder.mProcedureId.Text = mLIstLogTable[indexInvert].PROCEDURE_ID.ToString();
                myholder.mProcedureName.Text = mLIstLogTable[indexInvert].PROCEDURE_NAME;
                myholder.mDate.Text = mLIstLogTable[indexInvert].DATE_TIME.ToString();
                myholder.mAction.Text = mLIstLogTable[indexInvert].ACTION;
                myholder.mErrorDescription.Text = mLIstLogTable[indexInvert].ERROR_DESCRIPTION;

                if (position > mCurrentPosition)
                {
                    SetAnimation(myholder.mMainView);
                    mCurrentPosition = position;
                }


        }

        private void SetAnimation(View view)
        {
            Animation anim = AnimationUtils.LoadAnimation(mContext, Resource.Animation.SlideUpCardView);
            view.StartAnimation(anim);
        }

        public override int ItemCount
        {
            get { return mLIstLogTable.Count; }
        }
    }
}