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
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using System.Threading;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "Insite2", MainLauncher = true, NoHistory = true, Icon = "@drawable/icon", Theme = "@style/Theme.Splash")]
    public class LoadingScreen : Activity
    {
        private WebService mWebService;
        private List<UserTable> mListUserName;
        //private ProgressDialog progressBarDialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //SetContentView(Resource.Layout.LoadingScreen);

            mListUserName = new List<UserTable>();
            mWebService = new WebService();

            mListUserName = mWebService.GetAllDataUserTable();

            ISharedPreferences preferences = Application.Context.GetSharedPreferences("RememberMe", FileCreationMode.Private);
            string UserName = preferences.GetString("UserName", String.Empty);
            string Password = preferences.GetString("Password", String.Empty);
            int Privilege = preferences.GetInt("Privilege", -1);



            if (UserName == String.Empty || Password == String.Empty || Privilege == -1)
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                this.StartActivity(intent);
            }
            else
            {
                bool flag = false;

                foreach (UserTable row in mListUserName)
                {
                    if (UserName == row.USER_NAME && Password == row.PASSWORD)
                    {
                        flag = true;

                        Intent intent = new Intent(this, typeof(MainPageAct));
                        this.StartActivity(intent);
                        this.Finish(); //that user can't return back on this layout
                    }
                }

                if (flag == false)
                {
                    ISharedPreferencesEditor editor = preferences.Edit();
                    editor.Clear();
                    editor.Apply();

                    Intent intent = new Intent(this, typeof(MainActivity));
                    this.StartActivity(intent);
                    this.Finish();
                }
                else
                {
                    RunOnUiThread(() => { Toast.MakeText(this, "Hellow " + UserName, ToastLength.Long).Show(); });
                }
                
            }
        }        
    }
}