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
using MikePhil.Charting.Charts;
using Etl_Analytics_Mobile_Version_01.Class;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using MikePhil.Charting.Data;
using Android.Graphics;
using Android.Support.V4.App;

namespace Etl_Analytics_Mobile_Version_01.Fragments
{
    public class ChartAllTablesDialog : Android.Support.V4.App.DialogFragment
    {
        private View mView;
        private BarChart mChartAllTables;
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
            mChartAllTables = mView.FindViewById<BarChart>(Resource.Id.chartAllTablesDialog);

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

            mChartAllTables.Data = data;
            mChartAllTables.AxisRight.SetDrawLabels(false);
            mChartAllTables.XAxis.SetDrawLabels(false);
            mChartAllTables.AnimateXY(3000, 3000);

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