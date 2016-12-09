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

namespace Etl_Analytics_Mobile_Version_01.Class
{
    public class OnSignUpEventArgs : EventArgs
    {
        private string mfirstName;
        private string mlastName;
        private string muserName;
        private string meMail;
        private string mpassword;

        public string FirstName
        {
            get { return mfirstName; }
            set { mfirstName = value; }
        }

        public string LastName
        {
            get { return mlastName; }
            set { mlastName = value; }
        }

        public string UserName
        {
            get { return muserName; }
            set { muserName = value; }
        }

        public string Email
        {
            get { return meMail; }
            set { meMail = value; }
        }

        public string Password
        {
            get { return mpassword; }
            set { mpassword = value; }
        }

        public OnSignUpEventArgs(string firstName, string lastName, string userName, string eMail, string password) : base()
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = eMail;
            Password = password;
        }
    }
}