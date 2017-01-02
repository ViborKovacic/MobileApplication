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

namespace Etl_Analytics_Mobile_Version_01.Fragments
{
    public class FragmentChart : Android.Support.V4.App.Fragment
    {
        private Dictionary<string, List<BarEntry>> dicOfDataSets;
        private List<float> listOfEntry;
        private List<string> listTableNames;
        private WebService webService;
        private List<StatsTables> listStatsTables;
        private BarDataSet dataSet;
        private View view;
        private BarChart chartAllTables;
        private BarChart chartSuccess;
        private BarChart chartError;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            
            listOfEntry = new List<float>();
            listTableNames = new List<string>();
            webService = new WebService();
            listStatsTables = webService.GetAllDataStatsTable();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.StatsTableGraph, container, false);
            chartAllTables = view.FindViewById<BarChart>(Resource.Id.chartAllTables);
            chartSuccess = view.FindViewById<BarChart>(Resource.Id.chartSuccess);
            chartError = view.FindViewById<BarChart>(Resource.Id.chartError);            

            ChartAllTables();
            ChartSuccess();
            ChartError();

            chartAllTables.Click += ChartAllTables_Click;
            chartSuccess.Click += ChartSuccess_Click;
            chartError.Click += ChartError_Click;

            return view;
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
            dicOfDataSets = new Dictionary<string, List<BarEntry>>();

            foreach (StatsTables row in listStatsTables)
            {
                if (!listTableNames.Contains(row.table_name))
                {
                    listTableNames.Add(row.table_name);
                }
            }

            int counter = 0;


            foreach (string table in listTableNames)
            {
                List<BarEntry> barEntry = new List<BarEntry>();
                foreach (StatsTables item in listStatsTables)
                {
                    if (table == item.table_name)
                    {
                        barEntry.Add(new BarEntry(counter, item.diff_last_trans));
                        counter++;
                    }
                }
                dicOfDataSets.Add(table, barEntry);
            }

            BarData data = new BarData();

            foreach (KeyValuePair<string, List<BarEntry>> dicDataSet in dicOfDataSets)
            {
                dataSet = new BarDataSet(dicDataSet.Value, dicDataSet.Key);

                foreach (BarEntry item in dicDataSet.Value)
                {
                    if (item.GetY() > 70)
                    {
                        dataSet.SetColor(Color.Red, 200);

                    }

                    else
                    {
                        dataSet.AddColor(Color.Green);
                    }
                }

                data.AddDataSet(dataSet);
            }

            chartAllTables.Data = data;
            chartAllTables.AxisRight.SetDrawLabels(false);
            chartAllTables.XAxis.SetDrawLabels(false);
            chartAllTables.AnimateXY(3000, 3000);
        }

        private void ChartSuccess()
        {
            dicOfDataSets = new Dictionary<string, List<BarEntry>>();

            List<StatsTables> searchedTable = (from table in listStatsTables
                                               where table.big_deviation.Contains("NO", StringComparison.OrdinalIgnoreCase)
                                               select table).ToList<StatsTables>();

            foreach (StatsTables row in searchedTable)
            {
                if (!listTableNames.Contains(row.table_name))
                {
                    listTableNames.Add(row.table_name);
                }
            }

            int counter = 0;

            foreach (string table in listTableNames)
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
                dicOfDataSets.Add(table, barEntry);
            }

            BarData data = new BarData();

            foreach (KeyValuePair<string, List<BarEntry>> dicDataSet in dicOfDataSets)
            {
                dataSet = new BarDataSet(dicDataSet.Value, dicDataSet.Key);
                dataSet.SetColor(Color.Green, 200);
                data.AddDataSet(dataSet);
            }

            chartSuccess.Data = data;
            chartSuccess.AxisRight.SetDrawLabels(false);
            chartSuccess.XAxis.SetDrawLabels(false);
            chartSuccess.AnimateXY(3000, 3000);
        }

        private void ChartError()
        {
            dicOfDataSets = new Dictionary<string, List<BarEntry>>();

            List<StatsTables> searchedTable = (from table in listStatsTables
                                               where table.big_deviation.Contains("YES", StringComparison.OrdinalIgnoreCase)
                                               select table).ToList<StatsTables>();

            foreach (StatsTables row in searchedTable)
            {
                if (!listTableNames.Contains(row.table_name))
                {
                    listTableNames.Add(row.table_name);
                }
            }

            int counter = 0;

            foreach (string table in listTableNames)
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
                dicOfDataSets.Add(table, barEntry);
            }

            BarData data = new BarData();

            foreach (KeyValuePair<string, List<BarEntry>> dicDataSet in dicOfDataSets)
            {
                dataSet = new BarDataSet(dicDataSet.Value, dicDataSet.Key);
                dataSet.SetColor(Color.Red, 200);
                data.AddDataSet(dataSet);
            }

            chartError.Data = data;
            chartError.AxisRight.SetDrawLabels(false);
            chartError.XAxis.SetDrawLabels(false);
            chartError.AnimateXY(3000, 3000);
        }
    }
}