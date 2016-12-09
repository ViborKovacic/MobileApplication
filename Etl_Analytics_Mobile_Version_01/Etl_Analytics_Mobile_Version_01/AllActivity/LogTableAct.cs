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
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Etl_Analytics_Mobile_Version_01.Class;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "LogTableAct", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme2")]
    public class LogTableAct : ActionBarActivity
    {
        private List<string> myList;
        private List<LogTable> logTable;
        private ListView myListView;
        private WebService webService;
        private List<ColumnName> columnNameList;

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

            drawerLayout.SetDrawerListener(drawerToogle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            drawerToogle.SyncState();

            //CreateListOfData();

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            drawerToogle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }

        public void DoThis()
        {
            webService = new WebService();
            logTable = webService.GetAllDataLogTable();

            columnNameList = GetColumnNames();

            myListView = FindViewById<ListView>(Resource.Id.listViewTable);
            myList = new List<string>();

            //foreach (LogTable row in logTable)
            //{
            //    foreach (ColumnName columnName in columnNameList)
            //    {
            //        myList.Add(columnName.COLUMN_NAME);
            //        myList.Add(row.);
            //    }
            //}



            foreach (LogTable nesto in logTable)
            {
                myList.Add(nesto.LOG_ID.ToString());
            }

            ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, myList);

            myListView.Adapter = arrayAdapter;
        }

        public List<ColumnName> GetColumnNames()
        {
            webService = new WebService();
            string table_name = "V_LOG_TABLE";

            logTable = webService.GetAllDataLogTable();
            columnNameList = webService.GetAllColumnNames(table_name);

            return columnNameList;

        }
    }
}