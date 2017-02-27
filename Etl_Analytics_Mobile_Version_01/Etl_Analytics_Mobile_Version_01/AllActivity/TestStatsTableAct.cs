using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Etl_Analytics_Mobile_Version_01.Class;
using Android.Views.InputMethods;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "Table statistics", Icon = "@drawable/icon")]
    public class TestStatsTableAct : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SlidingBar);
            
        }
    }
}