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
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "MainPageAct", Icon = "@drawable/icon", Theme = "@style/MyTheme2")]
    public class MainPageAct : AppCompatActivity
    {
        private SupportToolbar mSupportToolbar;
        private LinearLayout mLienarLogTable;
        private LinearLayout mLienarNesto;
        private LinearLayout mLienarStatsTable;
        private LinearLayout mLienarStatsColumn;
        private ProgressDialog progressBarDialog;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            ISharedPreferences preferences = Application.Context.GetSharedPreferences("RememberMe", FileCreationMode.Private);
            int grant = preferences.GetInt("Privilege", -1);

            if (grant == 0)
            {
                SetContentView(Resource.Layout.MainPage);
                mLienarLogTable = FindViewById<LinearLayout>(Resource.Id.linearLogTable);
                mLienarNesto = FindViewById<LinearLayout>(Resource.Id.linearNesto);
                mLienarStatsTable = FindViewById<LinearLayout>(Resource.Id.linearStatsTable);
                mLienarStatsColumn = FindViewById<LinearLayout>(Resource.Id.linearStatsColumn);

                mLienarLogTable.Click += delegate
                {
                    Intent intent = new Intent(this, typeof(TestStatsTableAct));
                    this.StartActivity(intent);
                    RunOnUiThread(() => { Toast.MakeText(this, "Log table opened", ToastLength.Long).Show(); });
                };

                mLienarNesto.Click += delegate 
                {

                };

                mLienarStatsTable.Click += delegate 
                {
                    ProgressBarDialog();

                    new Thread(new ThreadStart(delegate
                    {
                        Intent intent = new Intent(this, typeof(StatsTableAct));
                        intent.PutExtra("StatsTable", "StatsTable");
                        this.StartActivity(intent);
                        RunOnUiThread(() => { Toast.MakeText(this, "Column statistics opened", ToastLength.Long).Show(); });

                        RunOnUiThread(() => { progressBarDialog.Hide(); });
                    })).Start();
                };

                mLienarStatsColumn.Click += delegate 
                {
                    Intent intent = new Intent(this, typeof(StatsTableAct));
                    ProgressBarDialog();
                    new Thread(new ThreadStart(delegate
                    {
                        
                        intent.PutExtra("StatsColumns", "StatsColumns");
                        RunOnUiThread(() => { progressBarDialog.Hide(); });
                        this.StartActivity(intent);

                        RunOnUiThread(() => { Toast.MakeText(this, "Column statistics opened", ToastLength.Long).Show(); });

                        
                    })).Start();
                };               
            }
            else
            {
                SetContentView(Resource.Layout.MainPageAdmin);
            }


            mSupportToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);

            SetSupportActionBar(mSupportToolbar);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.Title = "Etl Iniste2";

            RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.mainPage_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public void ProgressBarDialog()
        {
            progressBarDialog = new ProgressDialog(this);
            progressBarDialog.SetCancelable(false);
            progressBarDialog.SetMessage("Gethering data from server...");
            progressBarDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
            progressBarDialog.Show();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case 16908332:

                    Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
                    alert.SetTitle("Log Out");
                    alert.SetMessage("Do you want Log Out?");
                    alert.SetNeutralButton("Yes", delegate {

                        ISharedPreferences preferences = Application.Context.GetSharedPreferences("RememberMe", FileCreationMode.Private);
                        ISharedPreferencesEditor editor = preferences.Edit();
                        editor.Clear();
                        editor.Apply();

                        Intent intent = new Intent(this, typeof(MainActivity));
                        this.StartActivity(intent);
                        this.Finish();

                        
                        alert.Dispose();
                    });
                    alert.SetNegativeButton("No", delegate {

                        alert.Dispose();

                    });
                    alert.Show();

                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
            
        }
        public override void OnBackPressed()
        {
            FinishAffinity();
        }
    }
}