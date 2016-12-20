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
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using Android.Support.V4.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;


namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "Log table", Icon = "@drawable/icon", Theme = "@style/MyTheme3")]
    public class LogTableAct : ActionBarActivity
    {
        ExpandableListViewAdapter mAdapter;
        ExpandableListView expandableListView;
        List<string> group = new List<string>();
        Dictionary<string, List<string>> dicMyMap = new Dictionary<string, List<string>>();
        WebService webService;
        List<LogTable> logTable;

        private SupportToolbar suppToolbar;
        private MyActionBarDrawerToggle drawerToogle;
        private DrawerLayout drawerLayout;
        private ListView viewDrawer;
        List<string> listDrawer;
        ArrayAdapter adapterDrawer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LogTable);
            suppToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.Drawer);
            viewDrawer = FindViewById<ListView>(Resource.Id.ListView);
            expandableListView = FindViewById<ExpandableListView>(Resource.Id.expendableListView);

            SetData(out mAdapter);
            expandableListView.SetAdapter(mAdapter);

            

            listDrawer = new List<string>();
            listDrawer.Add("Log table");
            listDrawer.Add("Configuration columns");
            listDrawer.Add("Configuration table");
            listDrawer.Add("Stats columns");
            listDrawer.Add("Stats tables");
            listDrawer.Add("User table");

            adapterDrawer = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, listDrawer);
            viewDrawer.Adapter = adapterDrawer;

            SetSupportActionBar(suppToolbar);

            drawerToogle = new MyActionBarDrawerToggle(this /*host*/, drawerLayout, Resource.String.open_drawer, Resource.String.close_drawer);

            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            drawerToogle.SyncState();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        private void SetData(out ExpandableListViewAdapter mAdapter)
        {
            webService = new WebService();
            logTable = new List<LogTable>();
            logTable = webService.GetAllDataLogTable();
            int counter = 0;

            foreach (LogTable row in logTable)
            {
                List<string> groupA = new List<string>();
                group.Add((counter + 1).ToString() + " " + row.PROCEDURE_NAME.ToString() + " " + row.DATE_TIME.ToString() + " " + row.ACTION.ToString()); ;
                groupA.Add(" Id procedure: " + row.PROCEDURE_ID.ToString());
                //groupA.Add(" Ime procedure: " + row.PROCEDURE_NAME.ToString());
                if (row.ERROR_DESCRIPTION != null)
                {
                    groupA.Add(" Error: " + row.ERROR_DESCRIPTION);
                }             

                dicMyMap.Add(group[counter], groupA);
                counter++;
            }

            mAdapter = new ExpandableListViewAdapter(this, group, dicMyMap);

        }
    }
}