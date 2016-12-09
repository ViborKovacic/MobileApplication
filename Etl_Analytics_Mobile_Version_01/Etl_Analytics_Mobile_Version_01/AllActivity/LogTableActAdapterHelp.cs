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
using Etl_Analytics_Mobile_Version_01.Class;
using Android.Support.V7.App;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "LogTableActAdapterHelp", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme3")]
    public class LogTableActAdapterHelp : AppCompatActivity
    {
        ExpandableListViewAdapter mAdapter;
        ExpandableListView expandableListView;
        List<string> group = new List<string>();
        Dictionary<string, List<string>> dicMyMap = new Dictionary<string, List<string>>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.LogTableTry);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Moj bar";
            expandableListView = FindViewById<ExpandableListView>(Resource.Id.expendableListView);

            SetData(out mAdapter);
            expandableListView.SetAdapter(mAdapter);
        }

        private void SetData(out ExpandableListViewAdapter mAdapter)
        {
            List<string> grupA = new List<string>();
            grupA.Add("A-1");
            grupA.Add("A-2");
            grupA.Add("A-3");

            List<string> groupB = new List<string>();
            groupB.Add("B-1");
            groupB.Add("B-2");
            groupB.Add("B-3");
            groupB.Add("B-4");

            group.Add("Group A");
            group.Add("Group B");

            dicMyMap.Add(group[0], grupA);
            dicMyMap.Add(group[1], groupB);

            mAdapter = new ExpandableListViewAdapter(this, group, dicMyMap);

        }
    }
}