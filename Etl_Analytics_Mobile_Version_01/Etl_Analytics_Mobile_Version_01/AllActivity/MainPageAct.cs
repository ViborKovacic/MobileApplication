using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Widget;
using Android.OS;
using Etl_Analytics_Mobile_Version_01.Class;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using System.Threading;
using Android.Views;
using Android.Views.InputMethods;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Org.Json;
using System.Net.Http;
using RestSharp;
using Newtonsoft.Json.Linq;
using Android.Support.V7.App;
using Etl_Analytics_Mobile_Version_01.Resources;
using Android.Content;
using Android.Graphics;
using Android.Support.V7.Widget;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "MainPageAct", Icon = "@drawable/icon", Theme = "@style/MyTheme2")]
    public class MainPageAct : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MainPage);
            DoThis();
            RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
        }

        private void DoThis()
        {
            GridView gridView;
            string[] gridViewString = {
                             "Log table","Configuration columns \n\n\n",
                             "Configuration table","Stats columns\n\n\n",
                             "Stats tables","User table"
                    };

            int[] imageId = {
                            Resource.Drawable.location,Resource.Drawable.sound,
                            Resource.Drawable.note,Resource.Drawable.list,
                            Resource.Drawable.location,Resource.Drawable.sound
                    };

            SetContentView(Resource.Layout.MainPage);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Log table";

            CustomGridViewAdapter adapter = new CustomGridViewAdapter(this, gridViewString, imageId);
            gridView = FindViewById<GridView>(Resource.Id.grid_view_image_text);
            gridView.Adapter = adapter;

            gridView.ItemClick += (s, ed) =>
            {
                Toast.MakeText(this, "Open: " + gridViewString[ed.Position].Replace("\n", ""), ToastLength.Short).Show();
                //Opening LogTable list
                if ("Log table" == gridViewString[ed.Position])
                {
                    Intent intent = new Intent(this, typeof(StatsColumns));
                    this.StartActivity(intent);
                }
                else if ("Configuration table" == gridViewString[ed.Position])
                {
                    Intent intent = new Intent(this, typeof(StatsColumns));
                    this.StartActivity(intent);
                }
                else if ("Stats tables" == gridViewString[ed.Position])
                {
                    Intent intent = new Intent(this, typeof(StatsTableAct));
                    intent.PutExtra("StatsTable", "StatsTable");
                    this.StartActivity(intent);
                }

                else if ("Stats columns\n\n\n" == gridViewString[ed.Position])
                {
                    Intent intent = new Intent(this, typeof(StatsTableAct));
                    intent.PutExtra("StatsColumns", "StatsColumns");
                    this.StartActivity(intent);
                }

                else if ("User table" == gridViewString[ed.Position])
                {
                    Intent intent = new Intent(this, typeof(UserTableAct));
                    this.StartActivity(intent);
                }

                else if ("Configuration columns \n\n\n" == gridViewString[ed.Position])
                {
                    Intent intent = new Intent(this, typeof(DrawerLayoutActionBar));
                    this.StartActivity(intent);
                }

            };
        }
    }
}