
using Android.App;
using Android.OS;
using Android.Widget;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "SlidingTabAct", Icon = "@drawable/xs")]
    public class SlidingTabAct : Activity
    {
        private LinearLayout layoutChart;
        private LinearLayout layoutBigDeviation;
        private LinearLayout layoutAllTable;
        private LinearLayout layoutContacts;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ActionBar.SetCustomView(Resource.Layout.Action_bar);
            ActionBar.SetDisplayShowCustomEnabled(true);
            // Create your application here
            SetContentView(Resource.Layout.StatsTable);

            layoutChart = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            layoutBigDeviation = FindViewById<LinearLayout>(Resource.Id.linearLayout2);
            layoutAllTable = FindViewById<LinearLayout>(Resource.Id.linearLayout3);
            layoutContacts = FindViewById<LinearLayout>(Resource.Id.linearLayout4);
        }
    }
}