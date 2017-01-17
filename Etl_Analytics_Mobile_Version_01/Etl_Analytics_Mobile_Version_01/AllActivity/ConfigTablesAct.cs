using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Etl_Analytics_Mobile_Version_01.Class;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportFragment = Android.Support.V4.App.Fragment;
using Etl_Analytics_Mobile_Version_01.Fragments;
using Android.Content;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "Configuration", Icon = "@drawable/icon", Theme = "@style/MyTheme2")]
    public class ConfigTablesAct : ActionBarActivity

    {
        private SupportToolbar suppToolbar;
        private MyActionBarDrawerToggle drawerToogle;
        private DrawerLayout drawerLayout;
        private ListView viewDrawer;
        private List<string> listDrawer;
        private ArrayAdapter adapterDrawer;
        private SupportFragment mCurrentFragment;
        private FragmentConfigTablesAndColumns mFragmentConfigTables;
        private Fragment2 mFragment2;
        private Stack<SupportFragment> mStackFragment;
        private Intent intent;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ConfigTables);
            suppToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.Drawer);
            viewDrawer = FindViewById<ListView>(Resource.Id.ListView);

            if (SupportFragmentManager.FindFragmentByTag("Fragment1") != null)
            {
                mFragmentConfigTables = SupportFragmentManager.FindFragmentByTag("Fragment1") as FragmentConfigTablesAndColumns;
            }
            else
            {
                mFragmentConfigTables = new FragmentConfigTablesAndColumns();
                mFragment2 = new Fragment2();

                var trans = SupportFragmentManager.BeginTransaction();
                trans.Add(Resource.Id.fragmentContainer, mFragmentConfigTables, "Fragment1");
                trans.Commit();

                mCurrentFragment = mFragmentConfigTables;
            }

            listDrawer = new List<string>();
            listDrawer.Add("Configuration columns");
            listDrawer.Add("Configuration table");
            listDrawer.Add("Stats columns");
            listDrawer.Add("Stats tables");
            listDrawer.Add("User table");

            adapterDrawer = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, listDrawer);
            viewDrawer.Adapter = adapterDrawer;

            viewDrawer.ItemClick += ViewDrawer_ItemClick;

            SetSupportActionBar(suppToolbar);

            drawerToogle = new MyActionBarDrawerToggle(this /*host*/, drawerLayout, Resource.String.open_drawer, Resource.String.close_drawer);

            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            drawerToogle.SyncState();
        }

        private void ViewDrawer_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            string switchCheck = listDrawer[e.Position];

            switch (switchCheck)
            {
                case "Configuration columns":
                    intent = new Intent(this, typeof(DrawerLayoutActionBar));
                    this.StartActivity(intent);
                    break;
                case "Configuration table":
                    intent = new Intent(this, typeof(StatsTableAct));
                    this.StartActivity(intent);
                    break;
                case "Stats columns":
                    intent = new Intent(this, typeof(TestStatsTableAct));
                    this.StartActivity(intent);
                    break;
                case "Stats tables":
                    intent = new Intent(this, typeof(UserTableAct));
                    this.StartActivity(intent);
                    break;
                case "User table":
                    intent = new Intent(this, typeof(StatsTableAct));
                    this.StartActivity(intent);
                    break;
                default:
                    break;
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case 16908332 /*Hamburger*/:

                    return base.OnOptionsItemSelected(item);
                case Resource.Id.searchImage:
                    return base.OnOptionsItemSelected(item);
                case Resource.Id.action_fragment1:
                    ReplaceFragment(mFragmentConfigTables);
                    return true;
                case Resource.Id.action_fragment2:
                    ReplaceFragment(mFragment2);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public void ReplaceFragment(SupportFragment fragment)
        {
            if (fragment.IsVisible)
            {
                return;
            }

            else
            {
                var trans = SupportFragmentManager.BeginTransaction();
                trans.Replace(Resource.Id.fragmentContainer, fragment);
                trans.AddToBackStack(null);
                trans.Commit();

                mCurrentFragment = fragment;
            }
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }
    }
}