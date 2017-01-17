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
    class StatsColumnsAdapter : BaseAdapter<StatsColumns>
    {
        private Context mContext;
        private int mRowLayout;
        private List<StatsColumns> mStatsColumns;
        private int[] mAlternatingColors;

        public StatsColumnsAdapter(Context context, int rowLayout, List<StatsColumns> statsColumns)
        {
            mContext = context;
            mRowLayout = rowLayout;
            mStatsColumns = statsColumns;
            mAlternatingColors = new int[] { 0xF2F2F2, 0x264B26 };
        }

        public override int Count
        {
            get { return mStatsColumns.Count; }
        }

        public override StatsColumns this[int position]
        {
            get { return mStatsColumns[position]; }
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

            TextView tableName = row.FindViewById<TextView>(Resource.Id.txtStatsColumnsTableName);
            tableName.Text = mStatsColumns[position].TABLE_NAME;

            TextView columnName = row.FindViewById<TextView>(Resource.Id.txtStatsColumnsColumnName);
            columnName.Text = mStatsColumns[position].COLUMN_NAME;

            TextView date = row.FindViewById<TextView>(Resource.Id.txtStatsColumnsDate);
            date.Text = mStatsColumns[position].DATE_ID.ToString();

            TextView nullRows = row.FindViewById<TextView>(Resource.Id.txtStatsColumnsNullRows);
            nullRows.Text = mStatsColumns[position].NULL_ROWS.ToString();

            TextView notNullRows = row.FindViewById<TextView>(Resource.Id.txtStatsColumnsNotNullRows);
            notNullRows.Text = mStatsColumns[position].NOT_NULL_ROWS.ToString();

            TextView fillPrecentage = row.FindViewById<TextView>(Resource.Id.txtStatsColumnsFillPrecentage);
            fillPrecentage.Text = mStatsColumns[position].FILL_PERCENTAGE.ToString();

            if ((position % 2) == 1)
            {
                //Green background, set text white
                date.SetTextColor(Color.White);
                tableName.SetTextColor(Color.White);
                columnName.SetTextColor(Color.White);
                nullRows.SetTextColor(Color.White);
                notNullRows.SetTextColor(Color.White);
                fillPrecentage.SetTextColor(Color.White);
            }

            else
            {
                //White background, set text black
                date.SetTextColor(Color.Black);
                tableName.SetTextColor(Color.Black);
                columnName.SetTextColor(Color.Black);
                nullRows.SetTextColor(Color.Black);
                notNullRows.SetTextColor(Color.Black);
                fillPrecentage.SetTextColor(Color.Black);
            }

            return row;
        }

        private Color GetColorFromInteger(int color)
        {
            return Color.Rgb(Color.GetRedComponent(color), Color.GetGreenComponent(color), Color.GetBlueComponent(color));
        }
    }
}