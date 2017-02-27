
using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading;
using Android.Views;
using Android.Support.V7.App;
using Android.Content;
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
        private LinearLayout mLienarParameterVar;
        private LinearLayout mLinearUsers;
        private Intent intent;
        private ProgressDialog progressBarDialog;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            ISharedPreferences preferences = Application.Context.GetSharedPreferences("RememberMe", FileCreationMode.Private);
            int grant = preferences.GetInt("Privilege", -1);

            if (grant == 0)
            {
                SetContentView(Resource.Layout.MainPageAdmin);
                mLienarLogTable = FindViewById<LinearLayout>(Resource.Id.linearLogTable);
                mLienarNesto = FindViewById<LinearLayout>(Resource.Id.linearNesto);
                mLienarStatsTable = FindViewById<LinearLayout>(Resource.Id.linearStatsTable);
                mLienarStatsColumn = FindViewById<LinearLayout>(Resource.Id.linearStatsColumn);

                mLienarLogTable.Click += delegate
                {
                    Intent intent = new Intent(this, typeof(TestStatsTableAct));
                    this.StartActivity(intent);
                };

                mLienarNesto.Click += delegate
                {

                };

                mLienarStatsTable.Click += delegate
                {
                    intent = new Intent(this, typeof(StatsTableAct));
                    StartActivity("StatsTable");
                };

                mLienarStatsColumn.Click += delegate
                {
                    intent = new Intent(this, typeof(StatsTableAct));
                    StartActivity("StatsColumns");
                };
            }
            else
            {
                SetContentView(Resource.Layout.MainPageAdmin);
                mLienarLogTable = FindViewById<LinearLayout>(Resource.Id.linearLogTable);
                mLienarNesto = FindViewById<LinearLayout>(Resource.Id.linearNesto);
                mLienarStatsTable = FindViewById<LinearLayout>(Resource.Id.linearStatsTable);
                mLienarStatsColumn = FindViewById<LinearLayout>(Resource.Id.linearStatsColumn);
                mLienarParameterVar = FindViewById<LinearLayout>(Resource.Id.linearParameterVar);
                mLinearUsers = FindViewById<LinearLayout>(Resource.Id.linearUsers);

                mLienarLogTable.Click += delegate
                {
                    Intent intent = new Intent(this, typeof(TestStatsTableAct));
                    this.StartActivity(intent);
                };

                mLienarNesto.Click += delegate
                {

                };

                mLienarStatsTable.Click += delegate
                {
                    intent = new Intent(this, typeof(StatsTableAct));
                    StartActivity("StatsTable");
                };

                mLienarStatsColumn.Click += delegate
                {
                    progressBarDialog = new ProgressDialog(this);
                    progressBarDialog.SetCancelable(false);
                    progressBarDialog.SetMessage("Gethering data from server...");
                    progressBarDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
                    progressBarDialog.Show();

                    new System.Threading.Thread(new ThreadStart(delegate
                    {                    
                        intent = new Intent(this, typeof(StatsTableAct));
                        StartActivity("StatsColumns");

                        RunOnUiThread(() => { progressBarDialog.Dismiss(); });
                    })).Start();
                };

                mLienarParameterVar.Click += delegate
                {
                    intent = new Intent(this, typeof(ConfigTablesAct));
                    StartActivity("ParameterVar");
                };

                mLinearUsers.Click += delegate
                {
                    intent = new Intent(this, typeof(UserTableAct));
                    StartActivity("User");
                };
            }

            mSupportToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);

            SetSupportActionBar(mSupportToolbar);
            SupportActionBar.Title = "Etl Iniste2";

            RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
        }


        private void ProgressBarDialog()
        {
            progressBarDialog = new ProgressDialog(this);
            progressBarDialog.SetCancelable(false);
            progressBarDialog.SetMessage("Gethering data from server...");
            progressBarDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
            progressBarDialog.Show();
        }

        public void StartActivity(string extra)
        {
            intent.PutExtra(extra, extra);
            this.StartActivity(intent);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.mainPage_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.LogOut:

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