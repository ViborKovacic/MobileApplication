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
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Etl_Analytics_Mobile_Version_01.Class;
using Android.Support.V4.Widget;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "DrawerLayoutActionBar", Theme = "@style/MyThemeDrawerLayout")]
    public class DrawerLayoutActionBar : ActionBarActivity
    {
        private SupportToolbar mToolbar;
        private MyActionBarDrawerToggle mDrawerToggle;
        private DrawerLayout mDrawerLayout;
        private ListView mLeftDrawer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.DrawerLayout);

            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbarDrawer);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.Drawer);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.ListViewLeft);

            SetSupportActionBar(mToolbar);

            mDrawerToggle = new MyActionBarDrawerToggle(this, mDrawerLayout, Resource.String.open_drawer, Resource.String.close_drawer);

            mDrawerLayout.SetDrawerListener(mDrawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            mDrawerToggle.SyncState();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }
    }
}