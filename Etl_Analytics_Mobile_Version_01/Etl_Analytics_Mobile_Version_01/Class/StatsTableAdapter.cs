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
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using Android.Graphics;

namespace Etl_Analytics_Mobile_Version_01.Class
{
    class StatsTableAdapter : BaseAdapter<StatsTables>
    {
        private Context mContext;
        private int mRowLayout;
        private List<StatsTables> mStatsTable;
        private int[] mAlternatingColors;

        public StatsTableAdapter(Context context, int rowLayout, List<StatsTables> statsTable)
        {
            mContext = context;
            mRowLayout = rowLayout;
            mStatsTable = statsTable;
            mAlternatingColors = new int[] { 0xF2F2F2, 0x003D58 };
        }

        public override int Count
        {
            get { return mStatsTable.Count; }
        }

        public override StatsTables this[int position]
        {
            get { return mStatsTable[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(mRowLayout, parent, false);
            }

            row.SetBackgroundColor(GetColorFromInteger(mAlternatingColors[position % mAlternatingColors.Length]));

            TextView tableName = row.FindViewById<TextView>(Resource.Id.txtTableName);
            tableName.Text = mStatsTable[position].table_name;

            TextView date = row.FindViewById<TextView>(Resource.Id.txtDate);
            date.Text = mStatsTable[position].date_id.ToString();

            TextView nullColumns = row.FindViewById<TextView>(Resource.Id.txtNullColumns);
            nullColumns.Text = mStatsTable[position].null_columns.ToString();

            TextView amountOfData = row.FindViewById<TextView>(Resource.Id.txtAmount);
            amountOfData.Text = mStatsTable[position].amount_of_trs_data.ToString();

            TextView difference = row.FindViewById<TextView>(Resource.Id.txtDifference);
            difference.Text = mStatsTable[position].diff_last_trans.ToString();

            TextView bigDeviation = row.FindViewById<TextView>(Resource.Id.txtBigDeviation);
            bigDeviation.Text = mStatsTable[position].big_deviation;

            if ((position % 2) == 1)
            {
                //Green background, set text white
                tableName.SetTextColor(Color.White);
                date.SetTextColor(Color.White);
                nullColumns.SetTextColor(Color.White);
                amountOfData.SetTextColor(Color.White);
                difference.SetTextColor(Color.White);
                bigDeviation.SetTextColor(Color.White);
            }

            else
            {
                //White background, set text black
                tableName.SetTextColor(Color.Black);
                date.SetTextColor(Color.Black);
                nullColumns.SetTextColor(Color.Black);
                amountOfData.SetTextColor(Color.Black);
                difference.SetTextColor(Color.Black);
                bigDeviation.SetTextColor(Color.Black);
            }

            return row;
        }

        private Color GetColorFromInteger(int color)
        {
            return Color.Rgb(Color.GetRedComponent(color), Color.GetGreenComponent(color), Color.GetBlueComponent(color));
        }
    }
}