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

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "Log table", Icon = "@drawable/icon", Theme = "@style/MyTheme2"/*, ConfigurationChanges =Android.Content.PM.ConfigChanges.ScreenSize | Android.Content.PM.ConfigChanges.Orientation*/)]
    public class LogTableAct : ActionBarActivity

    {
        private SupportToolbar suppToolbar;
        private MyActionBarDrawerToggle drawerToogle;
        private DrawerLayout drawerLayout;
        private ListView viewDrawer;
        private List<string> listDrawer;
        private ArrayAdapter adapterDrawer;
        private SupportFragment mCurrentFragment;
        private Fragment1 mFragment1;
        private Fragment2 mFragment2;
        private Stack<SupportFragment> mStackFragment;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LogTable);
            suppToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.Drawer);
            viewDrawer = FindViewById<ListView>(Resource.Id.ListView);

            if (SupportFragmentManager.FindFragmentByTag("Fragment1") != null)
            {
                mFragment1 = SupportFragmentManager.FindFragmentByTag("Fragment1") as Fragment1;
            }
            else
            {
                mFragment1 = new Fragment1();
                mFragment2 = new Fragment2();

                var trans = SupportFragmentManager.BeginTransaction();
                trans.Add(Resource.Id.fragmentContainer, mFragment1, "Fragment1");
                trans.Commit();

                mCurrentFragment = mFragment1;
            }            

            mStackFragment = new Stack<SupportFragment>();          

            listDrawer = new List<string>();
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

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_fragment1:
                    ReplaceFragment(mFragment1);
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