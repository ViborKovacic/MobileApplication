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
using static Android.Views.View;
using MikePhil.Charting.Listener;
using MikePhil.Charting.Highlight;

namespace Etl_Analytics_Mobile_Version_01.Fragments.StatsColumnsFragments
{
    public class FragmentStatsColumnsChart : Android.Support.V4.App.Fragment, IOnChartValueSelectedListenerSupport
    {
        private View view;
        private PieChart mPieChart;
        private WebService webService;
        private List<StatsColumns> mListStatsColumns;
        private List<PieEntry> mListOfEntry;
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

            MyPieChart();

            mPieChart.SetOnChartValueSelectedListener(this);

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

            mListOfEntry = new List<PieEntry>();

            mListOfEntry.Add(new PieEntry(resoultHighOccupancy, "High occupancy"));
            mListOfEntry.Add(new PieEntry(resoultLowOccupncy, "Low occupancy"));

            dataSet = new PieDataSet(mListOfEntry, "");

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

        public void OnNothingSelected()
        {
            //throw new NotImplementedException();
        }

        public void OnValueSelected(Entry e, Highlight h)
        {
            if (e == null)
            {
                return;
            }

            PieEntry entry = mListOfEntry[int.Parse(h.GetX().ToString())];
            string entryLabel = entry.Label;

            if (entryLabel == "High occupancy")
            {
                List<StatsColumns> searchedList = (from table in mListStatsColumns
                                                  where table.LOW_OCCUPANCY.Contains("NO", StringComparison.OrdinalIgnoreCase)
                                                  select table).ToList<StatsColumns>();

                //SearchList list = new SearchList(searchedList);
                //var trans = FragmentManager.BeginTransaction();
                //PieChartDialog pieChartDialog = new PieChartDialog();
                //pieChartDialog.Show(trans, "Dialog Fragment");
            }
            else
            {
                List<StatsColumns> searchedList = (from table in mListStatsColumns
                                                   where table.LOW_OCCUPANCY.Contains("YES", StringComparison.OrdinalIgnoreCase)
                                                   select table).ToList<StatsColumns>();

                //SearchList list = new SearchList(searchedList);
                //var trans = FragmentManager.BeginTransaction();
                //PieChartDialog pieChartDialog = new PieChartDialog();
                //pieChartDialog.Show(trans, "Dialog Fragment");
            }
            
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

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.descriptionChart:

                    Bundle bundle = new Bundle();
                    bundle.PutString("StatsColumns", "StatsColumnsChart");

                    var trans = FragmentManager.BeginTransaction();
                    DescritpionDialog descriptionDialog = new DescritpionDialog();

                    descriptionDialog.Arguments = bundle;
                    descriptionDialog.Show(trans, "Dialog Fragment");

                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }

        }

    }
}