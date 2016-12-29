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
using Android.Support.V7.Widget;
using Etl_Analytics_Mobile_Version_01.Class;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;

namespace Etl_Analytics_Mobile_Version_01.Fragments
{
    public class Fragment2 : Android.Support.V4.App.Fragment
    {

        private RecyclerView mRecycleView;
        private RecyclerView.LayoutManager mLayoutManager;
        private RecyclerView.Adapter mAdapter;
        private List<LogTable> mListLogTable;
        private WebService webService;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.Fragment2, container, false);

            mRecycleView = view.FindViewById<RecyclerView>(Resource.Id.fragment2RecycleView);
            webService = new WebService();
            mListLogTable = new List<LogTable>();
            mListLogTable = webService.GetAllDataLogTable();


            //Create our layout manager
            mLayoutManager = new LinearLayoutManager(container.Context);
            mRecycleView.SetLayoutManager(mLayoutManager);
            mAdapter = new Fragment2RecycleAdapter(mListLogTable, mRecycleView, container.Context);
            mRecycleView.SetAdapter(mAdapter);



            return view;
        }
    }
}