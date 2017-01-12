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
using MikePhil.Charting.Data;
using Etl_Analytics_Mobile_Version_01.Class;
using MikePhil.Charting.Charts;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using MikePhil.Charting.Util;
using MikePhil.Charting.Components;
using Android.Graphics;

namespace Etl_Analytics_Mobile_Version_01.Fragments.StatsColumnsFragments
{
    public class PieChartDialog : Android.Support.V4.App.DialogFragment
    {
        private View mView;
        private BarChart mChartStatsColumns;
        private Dictionary<string, List<BarEntry>> mDicOfDataSets;
        private List<float> mListOfEntry;
        private List<string> mListColumnNames;
        private WebService mWebService;
        private List<StatsColumns> mListStatsColumns;
        private BarDataSet mDataSet;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            mListOfEntry = new List<float>();
            mListColumnNames = new List<string>();
            mWebService = new WebService();
            mListStatsColumns = mWebService.GetAllDataStatsColumns();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mView = inflater.Inflate(Resource.Layout.ChartAllTablesDialog, container, false);
            mChartStatsColumns = mView.FindViewById<BarChart>(Resource.Id.chartAllTablesDialog);

            mDicOfDataSets = new Dictionary<string, List<BarEntry>>();

            foreach (StatsColumns row in mListStatsColumns)
            {
                if (!mListColumnNames.Contains(row.COLUMN_NAME))
                {
                    mListColumnNames.Add(row.COLUMN_NAME);
                }
            }

            int counter = 0;


            foreach (string table in mListColumnNames)
            {
                List<BarEntry> barEntry = new List<BarEntry>();
                foreach (StatsColumns item in mListStatsColumns)
                {
                    if (table == item.COLUMN_NAME)
                    {
                        barEntry.Add(new BarEntry(counter, item.FILL_PERCENTAGE));
                        counter++;
                    }
                }
                mDicOfDataSets.Add(table, barEntry);
            }

            BarData data = new BarData();

            int[] chartColors = ColorTemplate.ColorfulColors.ToArray();
            int colorCounter = 0;

            foreach (KeyValuePair<string, List<BarEntry>> dicDataSet in mDicOfDataSets)
            {
                mDataSet = new BarDataSet(dicDataSet.Value, dicDataSet.Key);
                mDataSet.SetColors(chartColors[colorCounter]);
                data.AddDataSet(mDataSet);
                colorCounter++;
            }

            LimitLine limitLine = new LimitLine(70f);
            limitLine.LineColor = Color.DarkRed;
            limitLine.Enabled = true;

            XAxis xAxis = mChartStatsColumns.XAxis;
            xAxis.SetCenterAxisLabels(false);
            xAxis.SetDrawLabels(false);
            xAxis.Position = XAxis.XAxisPosition.BottomInside;
            xAxis.SetDrawGridLines(false);

            YAxis yAxis = mChartStatsColumns.AxisLeft;
            yAxis.SetDrawGridLines(true);
            yAxis.AddLimitLine(limitLine);

            Legend l = mChartStatsColumns.Legend;
            l.VerticalAlignment = Legend.LegendVerticalAlignment.Top;
            l.HorizontalAlignment = Legend.LegendHorizontalAlignment.Right;
            l.Orientation = Legend.LegendOrientation.Vertical;
            l.WordWrapEnabled = true;
            l.SetDrawInside(true);

            mChartStatsColumns.Data = data;
            mChartStatsColumns.AxisRight.SetDrawLabels(false);
            mChartStatsColumns.XAxis.SetDrawLabels(false);
            mChartStatsColumns.AnimateXY(3000, 3000);

            mChartStatsColumns.Description.Enabled = true;
            mChartStatsColumns.Description.Text = "All Columns chart";

            mChartStatsColumns.Invalidate();

            return mView;
        }


        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}