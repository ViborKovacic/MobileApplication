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
using MikePhil.Charting.Charts;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using MikePhil.Charting.Interfaces.Datasets;
using MikePhil.Charting.Data;
using Android.Support.V7.App;
using Java.Util;
using Etl_Analytics_Mobile_Version_01.Class;
using MikePhil.Charting.Util;
using Android.Graphics;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "Activity1", Theme = "@style/MyTheme2")]
    public class MPAndroidChart : AppCompatActivity
    {
        private List<BarEntry> listOfEntrys;
        private List<string> listOfStrings;
        private WebService webService;
        private List<StatsTables> listStatsTables;
        private BarDataSet dataSet;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Graph);
            listOfEntrys = new List<BarEntry>();
            listOfStrings = new List<string>();

            BarChart chart = FindViewById<BarChart>(Resource.Id.chart);
            webService = new WebService();
            listStatsTables = webService.GetAllDataStatsTable();

            int counter = 0;

            foreach (StatsTables item in listStatsTables)
            {
                listOfEntrys.Add(new BarEntry(counter, item.diff_last_trans));
                counter++;
            }

            listOfStrings.Add("January");
            listOfStrings.Add("February");
            listOfStrings.Add("March");
            listOfStrings.Add("April");
            listOfStrings.Add("May");
            listOfStrings.Add("June");


            dataSet = new BarDataSet(listOfEntrys, "Statistics");
            dataSet.SetColor(Color.Black, 100);
            dataSet.SetStackLabels(listOfStrings.ToArray());

            BarData data = new BarData();
            data.AddDataSet(dataSet);

            chart.Data = data;
            
        }
    }
}