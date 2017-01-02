using System.Collections.Generic;
using Android.OS;
using Android.Views;
using MikePhil.Charting.Charts;
using MikePhil.Charting.Data;
using Etl_Analytics_Mobile_Version_01.Class;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using System.Linq;
using System;
using Android.Graphics;

namespace Etl_Analytics_Mobile_Version_01.Fragments.StatsTable
{
    public class ChartSuccessDialog : Android.Support.V4.App.DialogFragment
    {
        private View mView;
        private BarChart chartError;
        private Dictionary<string, List<BarEntry>> dicOfDataSets;
        private List<float> listOfEntry;
        private List<string> listTableNames;
        private WebService webService;
        private List<StatsTables> listStatsTables;
        private BarDataSet dataSet;

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
            mView = inflater.Inflate(Resource.Layout.ChartAllTablesDialog, container, false);
            chartError = mView.FindViewById<BarChart>(Resource.Id.chartAllTablesDialog);

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

            chartError.Data = data;
            chartError.AxisRight.SetDrawLabels(false);
            chartError.XAxis.SetDrawLabels(false);
            chartError.AnimateXY(3000, 3000);

            return mView;
        }
    }
}