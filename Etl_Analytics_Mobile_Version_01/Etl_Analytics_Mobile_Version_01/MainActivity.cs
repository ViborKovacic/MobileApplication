using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Etl_Analytics_Mobile_Version_01.Class;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using System.Threading;
using Android.Views;
using System.Collections.Generic;
using Android.Views.InputMethods;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Org.Json;
using System.Net.Http;
using System.Text;
using RestSharp;
using Newtonsoft.Json.Linq;
using Android.Support.V7.App;
using Etl_Analytics_Mobile_Version_01.Resources;
using Android.Content;
using Android.Graphics;
using Etl_Analytics_Mobile_Version_01.AllActivity;

namespace Etl_Analytics_Mobile_Version_01
{
    [Activity(Label = "Etl_Analytics_Mobile_Version", Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        private Button btnSignIn;
        private Button btnLogIn;
        private ProgressBar progressBar;
        private ProgressDialog progressBarDialog;
        private EditText txtUserName;
        private EditText txtPassword;
        LinearLayout mLinearLayout; 

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.LogIn);

            txtUserName = FindViewById<EditText>(Resource.Id.txtUserName);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);

            btnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
            btnLogIn = FindViewById<Button>(Resource.Id.btnLogIn);

            //remove keyboar on click anywhere
            mLinearLayout = FindViewById<LinearLayout>(Resource.Id.LogInID);
            mLinearLayout.Click += MLinearLayout_Click;

            btnSignIn.Click += btnSignIn_Click;
            btnLogIn.Click += BtnLogIn_Click;
        }

        private void MLinearLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            WebService webService = new WebService();
            List<UserTable> userTalbe = new List<UserTable>();

            progressBarDialog = new ProgressDialog(this);
            progressBarDialog.SetCancelable(false);
            progressBarDialog.SetMessage("Opening application...");
            progressBarDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
            progressBarDialog.Show();

            
            new Thread(new ThreadStart(delegate {

                RemoveKeyboard(txtPassword);
                                
                userTalbe = webService.GetAllDataUserTable();

                bool flag = false;

                foreach (UserTable row in userTalbe)
                {
                    if (txtUserName.Text == row.USER_NAME && txtPassword.Text == row.PASSWORD)
                    {

                        flag = true;
                        Intent intent = new Intent(this, typeof(MainPageAct));
                        this.StartActivity(intent);
                        this.Finish(); //that user can't return back on this layout
                    }
                }

                if (flag == false)
                {
                    RunOnUiThread(() => { progressBarDialog.Dismiss(); });
                    string title = "Warning!!!";
                    string message = "The username or password is incrrect";
                    RunOnUiThread(() => { AlertDialogShow(title, message); });
                }
                else
                {
                    RunOnUiThread(() => { Toast.MakeText(this, "App is opened", ToastLength.Long).Show(); });

                    RunOnUiThread(() => { progressBarDialog.Hide(); });
                    RunOnUiThread(() => { progressBarDialog.SetMessage("Opened"); });
                }

            })).Start();

            
        }

        void btnSignIn_Click(object sender, EventArgs e)
        {
            //Pull up dialog
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            DialogSignIn signInDialog = new DialogSignIn();
            signInDialog.Show(transaction, "Dialog Fragment");

            signInDialog.eventOnSignUp += SignInDialog_eventOnSignUp; // On new event
        }

        //Simulate Server Request
        private void SignInDialog_eventOnSignUp(object sender, OnSignUpEventArgs e)
        {
            progressBar.Visibility = ViewStates.Visible; //progress bar set to visible
            string title = "Created";
            string message = "User successfuly created";
            AlertDialogShow(title, message);
            Thread thread = new Thread(ActLikeARequest); //start the thread that takes 3 sec
            thread.Start();
        }

        public void ActLikeARequest()
        {
            Thread.Sleep(3000); // 3 sec
            RunOnUiThread(() => { progressBar.Visibility = ViewStates.Invisible; });
        }

        public void AlertDialogShow(string title, string message)
        {
            Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
            alert.SetTitle(title);
            alert.SetMessage(message);
            alert.SetNeutralButton("OK", delegate {
                alert.Dispose();
            });
            alert.Show();
        }

        public void RemoveKeyboard(EditText text)
        {
            InputMethodManager manager = (InputMethodManager)GetSystemService(InputMethodService);
            manager.HideSoftInputFromWindow(text.WindowToken, 0);
        }
    }
}

