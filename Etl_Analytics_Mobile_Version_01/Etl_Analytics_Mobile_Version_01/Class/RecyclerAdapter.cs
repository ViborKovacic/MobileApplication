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
    public class RecyclerAdapter : RecyclerView.Adapter
    {
        private List<UserTable> mLIstUserTable;
        private RecyclerView mrecycleView;
        private Context mContext;
        private int mCurrentPosition = -1;
        public RecyclerAdapter(List<UserTable> listUserTable, RecyclerView recycleView, Context context)
        {
            mLIstUserTable = listUserTable;
            mrecycleView = recycleView;
            mContext = context;
        }

        public override int GetItemViewType(int position)
        {
            //if ((position % 2) == 0)
            //{
                return Resource.Layout.RowCardView;              
            //}
            //else
            //{
            //    return Resource.Layout.RowCardView2;
            //}
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //if (viewType == Resource.Layout.RowCardView)
            //{
                //RowCardView
                View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.RowCardView, parent, false);

                TextView txtUserName = row.FindViewById<TextView>(Resource.Id.txtUserName);
                TextView txtFirstName = row.FindViewById<TextView>(Resource.Id.txtFirstName);
                TextView txtLastName = row.FindViewById<TextView>(Resource.Id.txtLastName);
                TextView txtEmail = row.FindViewById<TextView>(Resource.Id.txtEmail);
                TextView txtPassword = row.FindViewById<TextView>(Resource.Id.txtPassword);
                TextView txtUserType = row.FindViewById<TextView>(Resource.Id.txtUserType);

                MyView view = new MyView(row)
                {
                    mUSER_NAME = txtUserName,
                    mFIRST_NAME = txtFirstName,
                    mLAST_NAME = txtLastName,
                    mEMAIL = txtEmail,
                    mPASSWORD = txtPassword,
                    mUSER_TYPE = txtUserType
                };

                return view;
            //}

            //else
            //{
            //    //RowCardView2
            //    View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.RowCardView2, parent, false);
            //    MyView2 view = new MyView2(row);
            //    return view;
            //}
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            //if (holder is MyView)
            //{
                MyView myholder = holder as MyView;
                int indexInvert = (mLIstUserTable.Count - 1) - position;
                myholder.mUSER_NAME.Text = mLIstUserTable[indexInvert].USER_NAME;
                myholder.mFIRST_NAME.Text = mLIstUserTable[indexInvert].FIRST_NAME;
                myholder.mLAST_NAME.Text = mLIstUserTable[indexInvert].LAST_NAME;
                myholder.mEMAIL.Text = mLIstUserTable[indexInvert].EMAIL;
                myholder.mPASSWORD.Text = mLIstUserTable[indexInvert].PASSWORD;
                myholder.mUSER_TYPE.Text = mLIstUserTable[indexInvert].USER_TYPE.ToString();

                if (position > mCurrentPosition)
                {
                    SetAnimation(myholder.mMainView);
                    mCurrentPosition = position;
                }
            //}
            //else
            //{
            //    MyView2 myholder2 = holder as MyView2;
            //    if (position > mCurrentPosition)
            //    {
            //        SetAnimation(myholder2.mMainView);
            //        mCurrentPosition = position;
            //    }
            //}
        }

        private void SetAnimation(View view)
        {
            Animation anim = AnimationUtils.LoadAnimation(mContext, Resource.Animation.SlideUpCardView);
            view.StartAnimation(anim);
        }

        public override int ItemCount
        {
            get{ return mLIstUserTable.Count; }
        }
    }
}