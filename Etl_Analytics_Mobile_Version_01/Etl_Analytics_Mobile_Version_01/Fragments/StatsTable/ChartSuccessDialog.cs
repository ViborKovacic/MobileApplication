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
using MikePhil.Charting.Components;

namespace Etl_Analytics_Mobile_Version_01.Fragments.StatsTable
{
    public class ChartSuccessDialog : Android.Support.V4.App.DialogFragment
    {
        private View mView;
        private BarChart chartSuccess;
        private Dictionary<string, List<BarEntry>> dicOfDataSets;
        private List<float> listOfEntry;
        private List<string> listTableNames;
        private WebService webService;
        private List<StatsTables> listStatsTables;
        private BarDataSet dataSet;
        private List<BarEntry> barEntry;

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
            chartSuccess = mView.FindViewById<BarChart>(Resource.Id.chartAllTablesDialog);

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
                barEntry = new List<BarEntry>();
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

            int[] chartColors = { Color.ParseColor("#005571"), Color.ParseColor("#227691"), Color.ParseColor("#86B1C6"), Color.ParseColor("#BCD4E0"), Color.ParseColor("#FDB813"),  Color.ParseColor("#FFC54E"), Color.ParseColor("#FFD27C"), Color.ParseColor("#FFE6B9") };
            int counterColor = 0;

            foreach (KeyValuePair<string, List<BarEntry>> dicDataSet in dicOfDataSets)
            {
                dataSet = new BarDataSet(dicDataSet.Value, dicDataSet.Key);
                dataSet.SetColors(chartColors[counterColor]);
                data.AddDataSet(dataSet);
                counterColor++;
            }

            XAxis xAxis = chartSuccess.XAxis;
            xAxis.SetCenterAxisLabels(false);
            xAxis.SetDrawLabels(false);
            xAxis.Position = XAxis.XAxisPosition.BottomInside;
            xAxis.SetDrawGridLines(false);
            xAxis.SetAvoidFirstLastClipping(true);
            xAxis.XOffset = 10;

            Legend l = chartSuccess.Legend;
            l.VerticalAlignment = Legend.LegendVerticalAlignment.Top;
            l.HorizontalAlignment = Legend.LegendHorizontalAlignment.Right;
            l.Orientation = Legend.LegendOrientation.Vertical;
            l.WordWrapEnabled = true;
            l.SetDrawInside(true);

            chartSuccess.Data = data;
            chartSuccess.AxisRight.SetDrawLabels(false);
            chartSuccess.XAxis.SetDrawLabels(false);
            chartSuccess.AnimateXY(3000, 3000);

            chartSuccess.Description.Enabled = true;
            chartSuccess.Description.Text = "Tables without big deviation";

            chartSuccess.Invalidate();

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