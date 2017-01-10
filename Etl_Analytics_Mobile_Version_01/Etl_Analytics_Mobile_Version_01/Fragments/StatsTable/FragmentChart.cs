using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.OS;
using Android.Views;
using MikePhil.Charting.Data;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using Etl_Analytics_Mobile_Version_01.Class;
using MikePhil.Charting.Charts;
using Android.Graphics;
using Etl_Analytics_Mobile_Version_01.Fragments.StatsTable;
using Android.Content;
using Android.Widget;
using Java.Util;
using MikePhil.Charting.Components;
using MikePhil.Charting.Util;
using Android.Graphics.Drawables;
using Android.Support.V4.View;
using Android.Views.InputMethods;

namespace Etl_Analytics_Mobile_Version_01.Fragments
{
    public class FragmentChart : Android.Support.V4.App.Fragment
    {
        private View view;

        private Dictionary<string, List<BarEntry>> mDicOfDataSets;
        private List<float> mListOfEntry;
        private List<string> mListTableNames;
        private List<StatsTables> mListStatsTables;

        private WebService webService;

        private BarDataSet dataSet;
        private BarChart chartAllTables;
        private BarChart chartSuccess;
        private BarChart chartError;

        private TextView mTextAllTable;
        private TextView mTextSuccess;
        private TextView mTextError;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

            mListOfEntry = new List<float>();
            mListTableNames = new List<string>();
            webService = new WebService();
            mListStatsTables = new List<StatsTables>();
            string test = Arguments.GetString("StatsTable");

            if (test == "Yes")
            {
                SearchList list = new SearchList();
                mListStatsTables = list.GetDataFromSearchListStatsTable();
            }
            else
            {
                mListStatsTables = webService.GetAllDataStatsTable();
            }            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.StatsTableGraph, container, false);
            chartAllTables = view.FindViewById<BarChart>(Resource.Id.chartAllTables);
            chartSuccess = view.FindViewById<BarChart>(Resource.Id.chartSuccess);
            chartError = view.FindViewById<BarChart>(Resource.Id.chartError);
            mTextAllTable = view.FindViewById<TextView>(Resource.Id.txtAllTable);
            mTextSuccess = view.FindViewById<TextView>(Resource.Id.textSuccess);
            mTextError = view.FindViewById<TextView>(Resource.Id.textError);

            mTextAllTable.Text = "All tables chart";
            mTextSuccess.Text = "Success tables chart";
            mTextError.Text = "Error tables chart";

            ChartAllTables();
            ChartSuccess();
            ChartError();

            chartAllTables.Click += ChartAllTables_Click;
            chartSuccess.Click += ChartSuccess_Click;
            chartError.Click += ChartError_Click;

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            HasOptionsMenu = true;
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            inflater.Inflate(Resource.Menu.fragmentChartToolBar, menu);
            base.OnCreateOptionsMenu(menu, inflater);
        }
        private void ChartError_Click(object sender, EventArgs e)
        {
            var trans = FragmentManager.BeginTransaction();
            ChartErrorDialog chartErrorDialog = new ChartErrorDialog();
            chartErrorDialog.Show(trans, "Dialog Fragment");
        }

        private void ChartSuccess_Click(object sender, EventArgs e)
        {
            var trans = FragmentManager.BeginTransaction();
            ChartSuccessDialog chartSuccesssDialog = new ChartSuccessDialog();
            chartSuccesssDialog.Show(trans, "Dialog Fragment");
        }

        private void ChartAllTables_Click(object sender, EventArgs e)
        {
            var trans = FragmentManager.BeginTransaction();
            ChartAllTablesDialog chartAllTablesDialog = new ChartAllTablesDialog();
            chartAllTablesDialog.Show(trans, "Dialog Fragment");
        }

        private void ChartAllTables()
        {
            mDicOfDataSets = new Dictionary<string, List<BarEntry>>();

            foreach (StatsTables row in mListStatsTables)
            {
                if (!mListTableNames.Contains(row.table_name))
                {
                    mListTableNames.Add(row.table_name);
                }
            }

            int counter = 0;


            foreach (string table in mListTableNames)
            {
                List<BarEntry> barEntry = new List<BarEntry>();
                foreach (StatsTables item in mListStatsTables)
                {
                    if (table == item.table_name)
                    {
                        barEntry.Add(new BarEntry(counter, item.diff_last_trans));
                        counter++;
                    }
                }
                mDicOfDataSets.Add(table, barEntry);
            }

            BarData data = new BarData();

            int[] chartColors = { Color.DarkRed, Color.DarkGreen };

            foreach (KeyValuePair<string, List<BarEntry>> dicDataSet in mDicOfDataSets)
            {
                dataSet = new BarDataSet(dicDataSet.Value, dicDataSet.Key);

                foreach (BarEntry item in dicDataSet.Value)
                {
                    if (item.GetY() > 70)
                    {
                        dataSet.SetColors(chartColors[0]);

                    }

                    else
                    {
                        dataSet.SetColors(chartColors[1]);
                    }
                }
                data.AddDataSet(dataSet);
            }

            LimitLine limitLine = new LimitLine(70f);
            limitLine.LineColor = Color.DarkRed;
            limitLine.Enabled = true;

            XAxis xAxis = chartAllTables.XAxis;
            xAxis.SetDrawLabels(false);
            xAxis.Position = XAxis.XAxisPosition.BottomInside;
            xAxis.SetDrawGridLines(true);

            YAxis yAxis = chartAllTables.AxisLeft;
            yAxis.SetDrawGridLines(true);
            yAxis.AddLimitLine(limitLine);

            chartAllTables.Data = data;
            chartAllTables.AxisRight.SetDrawLabels(false);
            chartAllTables.AnimateXY(3000, 3000);

            chartAllTables.Legend.Enabled = false;
            chartAllTables.SetTouchEnabled(true);
            chartAllTables.SetPinchZoom(false);
            chartAllTables.DoubleTapToZoomEnabled = false;

            chartAllTables.Description.Enabled = true;
            chartAllTables.Description.Text = "All tables chart";

            chartAllTables.Invalidate();
        }

        private void ChartSuccess()
        {
            mDicOfDataSets = new Dictionary<string, List<BarEntry>>();

            List<StatsTables> searchedTable = (from table in mListStatsTables
                                               where table.big_deviation.Contains("NO", StringComparison.OrdinalIgnoreCase)
                                               select table).ToList<StatsTables>();

            foreach (StatsTables row in searchedTable)
            {
                if (!mListTableNames.Contains(row.table_name))
                {
                    mListTableNames.Add(row.table_name);
                }
            }

            int counter = 0;

            foreach (string table in mListTableNames)
            {
                List<BarEntry> barEntry = new List<BarEntry>();
                foreach (StatsTables item in searchedTable)
                {
                    if (table == item.table_name)
                    {
                        barEntry.Add(new BarEntry(counter, item.diff_last_trans));
                        counter++;
                    }
                }
                mDicOfDataSets.Add(table, barEntry);
            }

            BarData data = new BarData();

            foreach (KeyValuePair<string, List<BarEntry>> dicDataSet in mDicOfDataSets)
            {
                dataSet = new BarDataSet(dicDataSet.Value, dicDataSet.Key);
                dataSet.SetColor(Color.DarkGreen, 200);
                data.AddDataSet(dataSet);
            }

            XAxis xAxis = chartSuccess.XAxis;
            xAxis.SetCenterAxisLabels(false);
            xAxis.SetDrawLabels(false);
            xAxis.Position = XAxis.XAxisPosition.BottomInside;
            xAxis.SetDrawGridLines(false);

            chartSuccess.Data = data;
            chartSuccess.AxisRight.SetDrawLabels(false);
            chartSuccess.XAxis.SetDrawLabels(false);
            chartSuccess.AnimateXY(3000, 3000);

            chartSuccess.Legend.Enabled = false;
            chartSuccess.SetTouchEnabled(true);
            chartSuccess.SetPinchZoom(false);
            chartSuccess.DoubleTapToZoomEnabled = false;

            chartSuccess.Description.Enabled = true;
            chartSuccess.Description.Text = "Tables without big deviation";

            chartSuccess.Invalidate();
        }

        private void ChartError()
        {
            mDicOfDataSets = new Dictionary<string, List<BarEntry>>();

            List<StatsTables> searchedTable = (from table in mListStatsTables
                                               where table.big_deviation.Contains("YES", StringComparison.OrdinalIgnoreCase)
                                               select table).ToList<StatsTables>();

            foreach (StatsTables row in searchedTable)
            {
                if (!mListTableNames.Contains(row.table_name))
                {
                    mListTableNames.Add(row.table_name);
                }
            }

            int counter = 0;

            foreach (string table in mListTableNames)
            {
                List<BarEntry> barEntry = new List<BarEntry>();
                foreach (StatsTables item in searchedTable)
                {
                    if (table == item.table_name)
                    {
                        barEntry.Add(new BarEntry(counter, item.diff_last_trans));
                        counter++;
                    }
                }
                mDicOfDataSets.Add(table, barEntry);
            }

            BarData data = new BarData();

            foreach (KeyValuePair<string, List<BarEntry>> dicDataSet in mDicOfDataSets)
            {
                dataSet = new BarDataSet(dicDataSet.Value, dicDataSet.Key);
                dataSet.SetColor(Color.DarkRed, 200);
                data.AddDataSet(dataSet);
            }

            XAxis xAxis = chartError.XAxis;
            xAxis.SetCenterAxisLabels(false);
            xAxis.SetDrawLabels(false);
            xAxis.Position = XAxis.XAxisPosition.BottomInside;
            xAxis.SetDrawGridLines(false);

            chartError.Data = data;
            chartError.AxisRight.SetDrawLabels(false);
            chartError.XAxis.SetDrawLabels(false);
            chartError.AnimateXY(2000, 2000);

            chartError.Legend.Enabled = false;
            chartError.SetTouchEnabled(true);
            chartError.SetPinchZoom(false);
            chartError.DoubleTapToZoomEnabled = false;

            chartError.Description.Enabled = true;
            chartError.Description.Text = "Tables with big deviation";

            chartError.Invalidate();
        }
    }
}