using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.OS;
using MikePhil.Charting.Charts;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using MikePhil.Charting.Data;
using Android.Support.V7.App;
using Etl_Analytics_Mobile_Version_01.Class;
using Android.Graphics;
using MikePhil.Charting.Components;
using MikePhil.Charting.Formatter;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "Activity1", Theme = "@style/MyTheme2")]
    public class MPAndroidChart : AppCompatActivity
    {
        private Dictionary<string, List<BarEntry>> dicOfDataSets;
        private List<LegendEntry> listOfStrings;
        private List<string> listTableNames;
        private WebService webService;
        private List<StatsTables> listStatsTables;
        private BarDataSet dataSet;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Graph);
            dicOfDataSets = new Dictionary<string, List<BarEntry>>();
            listOfStrings = new List<LegendEntry>();
            listTableNames = new List<string>();
            BarChart chart = FindViewById<BarChart>(Resource.Id.chart);
            webService = new WebService();
            listStatsTables = webService.GetAllDataStatsTable();


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

            string[] test = { "" };

            foreach (KeyValuePair<string, List<BarEntry>> dicDataSet in dicOfDataSets)
            {
                dataSet = new BarDataSet(dicDataSet.Value, "");
                foreach (BarEntry item in dicDataSet.Value)
                {
                    if (item.GetY() > 70)
                    {
                        dataSet.SetColor(Color.Red, 200);                    
                    }

                    else
                    {
                        dataSet.AddColor(Color.Blue);
                    }
                }

                data.AddDataSet(dataSet);
                //data.SetValueTextColor(Color.CadetBlue);
                //data.SetValueTextSize(40);
            }

            chart.Data = data;
            chart.AnimateXY(3000, 3000);
            chart.SetDrawGridBackground(false);
        }
    }
}