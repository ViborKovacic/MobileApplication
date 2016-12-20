using Android.App;
using Android.OS;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "Iniste2", MainLauncher = true, NoHistory = true, Icon = "@drawable/icon", Theme = "@style/Theme.Splash")]
    public class LoadingScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            
           
            StartActivity(typeof(MainActivity));
        }

        
    }
}