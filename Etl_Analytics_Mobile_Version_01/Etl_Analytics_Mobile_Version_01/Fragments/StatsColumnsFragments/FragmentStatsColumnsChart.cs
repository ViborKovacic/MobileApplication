using System;
using System.Collections.Generic;
using System.Linq;
using Android.OS;
using Android.Views;
using MikePhil.Charting.Charts;
using MikePhil.Charting.Components;
using Android.Graphics;
using MikePhil.Charting.Data;
using Etl_Analytics_Mobile_Version_01.Class;
using MikePhil.Charting.Formatter;
using MikePhil.Charting.Animation;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using Android.Widget;

namespace Etl_Analytics_Mobile_Version_01.Fragments.StatsColumnsFragments
{
    public class FragmentStatsColumnsChart : Android.Support.V4.App.Fragment
    {
        private View view;
        private View mActionBarView;
        private PieChart mPieChart;
        private WebService webService;
        private List<StatsColumns> mListStatsColumns;
        private PieDataSet dataSet;
        private float sumOfLowOccupancy;
        private float sumOfHighOccupancy;
        private float resoultHighOccupancy;
        private float resoultLowOccupncy;
        private ImageView mImageViewChart;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            mListStatsColumns = new List<StatsColumns>();
            webService = new WebService();
            mListStatsColumns = webService.GetAllDataStatsColumns();
            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mImageViewChart = new ImageView(container.Context);

            view = inflater.Inflate(Resource.Layout.StatsColumnsGraph, container, false);
            mPieChart = view.FindViewById<PieChart>(Resource.Id.pieChart);

            mActionBarView = inflater.Inflate(Resource.Layout.Action_bar, container, false);
            //mImageViewChart = mActionBarView.FindViewById<ImageView>(Resource.Id.imageChart);

            mImageViewChart.SetImageResource(Resource.Drawable.pie_chart_icon);
            //mImageViewChart.SetImageDrawable(pie_chart_icon);

            MyPieChart();

            return view;
        }

        private void MyPieChart()
        {
            sumOfLowOccupancy = (from table in mListStatsColumns
                                     where table.LOW_OCCUPANCY.Contains("YES", StringComparison.OrdinalIgnoreCase)
                                     select table).Count();


            sumOfHighOccupancy = (from table in mListStatsColumns
                                      where table.LOW_OCCUPANCY.Contains("NO", StringComparison.OrdinalIgnoreCase)
                                      select table).Count();

            resoultHighOccupancy = (sumOfHighOccupancy / sumOfLowOccupancy) * 100;

            resoultLowOccupncy = (sumOfLowOccupancy / sumOfHighOccupancy) * 100;

            List<PieEntry> listOfEntry = new List<PieEntry>();

            listOfEntry.Add(new PieEntry(resoultHighOccupancy, "High occupancy"));
            listOfEntry.Add(new PieEntry(resoultLowOccupncy, "Low occupancy"));

            dataSet = new PieDataSet(listOfEntry, "");

            dataSet.SliceSpace = 3;
            dataSet.SelectionShift = 2;
            dataSet.SetColor(Color.DarkGreen, 200);
            dataSet.AddColor(Color.DarkRed);

            PieData data = new PieData(dataSet);

            data.SetValueFormatter(new PercentFormatter());
            data.SetValueTextSize(11f);
            data.SetValueTextColor(Color.Black);

            mPieChart.Data = data;

            mPieChart.HighlightValues(null);

            mPieChart.SetUsePercentValues(true);
            mPieChart.Description.Enabled = false;
            mPieChart.SetExtraOffsets(5, 10, 5, 5);

            mPieChart.DrawHoleEnabled = true;
            mPieChart.SetHoleColor(Color.White);
            mPieChart.HoleRadius = 7;
            mPieChart.SetTransparentCircleAlpha(10);

            mPieChart.RotationAngle = 0;
            mPieChart.RotationEnabled = true;
            
            mPieChart.HighlightPerTapEnabled = true;

            mPieChart.AnimateY(2000, Easing.EasingOption.EaseInOutQuad);

            Legend legend = mPieChart.Legend;
            legend.Position = Legend.LegendPosition.RightOfChart;
            legend.XEntrySpace = 7;
            legend.YEntrySpace = 5;

            mPieChart.Invalidate();
        }
    }
}