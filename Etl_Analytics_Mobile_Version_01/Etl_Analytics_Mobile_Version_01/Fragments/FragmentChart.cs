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
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using Etl_Analytics_Mobile_Version_01.Class;
using MikePhil.Charting.Charts;
using Android.Graphics;

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
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.Graph, container, false);
            BarChart chart = view.FindViewById<BarChart>(Resource.Id.chart);

            dicOfDataSets = new Dictionary<string, List<BarEntry>>();
            listOfEntry = new List<float>();
            listTableNames = new List<string>();            
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

            string[] testTableNames = listTableNames.ToArray();

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
                dataSet = new BarDataSet(dicDataSet.Value, dicDataSet.Key + "\n");
                dataSet.SetStackLabels(testTableNames);
                dataSet.SetColor(Color.Red, 200);
                dataSet.Label = dicDataSet.Key;

                foreach (BarEntry item in dicDataSet.Value)
                {
                    if (item.GetY() > 70)
                    {
                        dataSet.AddColor(Color.Red);

                    }

                    else
                    {
                        dataSet.SetColor(Color.Blue, 200);
                    }
                }

                data.AddDataSet(dataSet);
            }

            chart.Data = data;
            chart.AxisRight.SetDrawLabels(false);
            chart.XAxis.SetDrawLabels(false);
            chart.AnimateXY(3000, 3000);

            return view;
        }
    }
}