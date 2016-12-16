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
using BarChart;
using Etl_Analytics_Mobile_Version_01.Class;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using Android.Graphics;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "TestGraphs")]
    public class TestGraphs : Activity
    {
        private  List<StatsTables> listStatsTable;
        private  StatsTableAdapter listAdapter;
        private  ListView listViewStatsTable;
        private  WebService webService;
        private  View view;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.Graph);

            webService = new WebService();
            listStatsTable = new List<StatsTables>();
            listStatsTable = webService.GetAllDataStatsTable();

            float[] data = new float[listStatsTable.Count];
            int counter = 0;         

            foreach (StatsTables item in listStatsTable)
            {
                data[counter] = item.diff_last_trans;
                counter++;
            }

            //BarModel test = new BarModel();

            //foreach (StatsTables item in listStatsTable)
            //{
            //    test.Legend = item.table_name;
            //}

           var viewChart = new BarChartView(this)
            {
                ItemsSource = Array.ConvertAll(data, v => new BarModel {
                    Value = v,
                    Legend = "Table name",
                    ValueCaptionHidden = false,
                })
            };
            viewChart.AutoLevelsEnabled = false;
            for (int i = 0; i <= 100; i += 10)
            {
                viewChart.AddLevelIndicator(i);
            }
            viewChart.LegendColor = Color.Red;
            viewChart.SetBackgroundColor(Color.White);
            viewChart.LegendFontSize = 30;
            viewChart.BarCaptionFontSize = 20;
            viewChart.BarCaptionOuterColor = Color.Black;
            viewChart.BarCaptionInnerColor = Color.White;
            viewChart.BarWidth = 100;
            viewChart.BarOffset = 100;

            AddContentView(viewChart, new ViewGroup.LayoutParams(
              WindowManagerLayoutParams.FillParent, ViewGroup.LayoutParams.FillParent));
        }
    }
}