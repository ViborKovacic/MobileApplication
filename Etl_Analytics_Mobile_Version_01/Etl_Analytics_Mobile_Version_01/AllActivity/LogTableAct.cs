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
    [Activity(Label = "Log table", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme3")]
    public class LogTableAct : ActionBarActivity
    {
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

            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            drawerToogle.SyncState();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }
    }
}