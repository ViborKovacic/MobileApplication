
using Android.App;
using Android.OS;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "SlidingTabAct", MainLauncher = true, Icon = "@drawable/xs")]
    public class SlidingTabAct : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ActionBar.SetCustomView(Resource.Layout.Action_bar);
            ActionBar.SetDisplayShowCustomEnabled(true);
            // Create your application here
            SetContentView(Resource.Layout.StatsTable);
        }
    }
}