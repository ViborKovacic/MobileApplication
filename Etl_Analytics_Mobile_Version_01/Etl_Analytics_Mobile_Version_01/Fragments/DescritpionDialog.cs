using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MikePhil.Charting.Data;
using Etl_Analytics_Mobile_Version_01.Class;
using MikePhil.Charting.Charts;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using MikePhil.Charting.Util;
using MikePhil.Charting.Components;
using Android.Graphics;

namespace Etl_Analytics_Mobile_Version_01.Fragments.StatsColumnsFragments
{
    public class DescritpionDialog : Android.Support.V4.App.DialogFragment
    {
        private View mView;
        private TextView mDescriptionTitle;
        private TextView mDescriptionBody;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mView = inflater.Inflate(Resource.Layout.DescriptionDialog, container, false);
            mDescriptionTitle = mView.FindViewById<TextView>(Resource.Id.descriptionTitle);
            mDescriptionBody = mView.FindViewById<TextView>(Resource.Id.descriptionBody);

            string arguments = Arguments.GetString("Test");

            if (arguments == "Test")
            {
                mDescriptionTitle.Text = "Chart description";
                mDescriptionBody.Text = "Neki opis";
            }          

            return mView;
        }
    }
}