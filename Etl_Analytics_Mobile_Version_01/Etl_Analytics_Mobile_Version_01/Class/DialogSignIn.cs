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
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Etl_Analytics_Mobile_Version_01.Class
{
    public class DialogSignIn : DialogFragment
    {
        private EditText txtFirstName;
        private EditText txtLastName;
        private EditText txtUsertName;
        private EditText txtEmail;
        private EditText txtPassword;
        private Button btnSignUp;

        public event EventHandler<OnSignUpEventArgs> eventOnSignUp;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.SignInDialog, container, false);

            txtFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            txtLastName = view.FindViewById<EditText>(Resource.Id.txtLastName);
            txtUsertName = view.FindViewById<EditText>(Resource.Id.txtUserName);
            txtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            btnSignUp = view.FindViewById<Button>(Resource.Id.btnDialogSignUp);

            btnSignUp.Click += BtnSignUp_Click;
            return view;
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            UserTable user = new UserTable();
            WebService webService = new WebService();
            int counterUserName = 0;
            int counterEmail = 0;

            user.FIRST_NAME = txtFirstName.Text;
            user.LAST_NAME = txtLastName.Text;
            user.USER_NAME = txtUsertName.Text;
            user.EMAIL = txtEmail.Text;
            user.PASSWORD = txtEmail.Text;

            List<UserTable> userTable = new List<UserTable>();
            userTable = webService.GetAllDataUserTable();

            foreach (UserTable row in userTable)
            {
                
                if (user.USER_NAME == row.USER_NAME.ToString())
                {
                    counterUserName++;
                }

                else if(user.EMAIL == row.EMAIL.ToString())
                {
                    counterEmail++;
                }
            }

            if (counterUserName == 0 && counterEmail == 0)
            {
                string response = webService.AddNewUser(user);
                eventOnSignUp.Invoke(this, new OnSignUpEventArgs(txtFirstName.Text, txtLastName.Text, txtUsertName.Text, txtEmail.Text, txtPassword.Text));
            }
            else if(counterUserName != 0)
            {
                this.Dismiss();
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                DialogSignIn signInDialog = new DialogSignIn();
                signInDialog.Show(transaction, "Dialog Fragment");

                txtFirstName.Text = user.FIRST_NAME.ToString();
                txtLastName.Text = user.LAST_NAME.ToString();
                txtEmail.Text = user.EMAIL.ToString();
                txtPassword.Text = user.PASSWORD.ToString();

            }
            else if (counterEmail != 0)
            {
                this.Dismiss();
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                DialogSignIn signInDialog = new DialogSignIn();
                signInDialog.Show(transaction, "Dialog Fragment");

                txtFirstName.Text = user.FIRST_NAME.ToString();
                txtLastName.Text = user.LAST_NAME.ToString();
                txtEmail.Text = user.USER_NAME.ToString();
                txtPassword.Text = user.PASSWORD.ToString();
            }
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Hide the title bar
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation; //Set animation
        }
    }
}