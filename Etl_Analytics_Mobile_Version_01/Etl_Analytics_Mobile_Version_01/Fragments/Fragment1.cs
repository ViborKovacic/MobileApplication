using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Etl_Analytics_Mobile_Version_01.Class;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;

namespace Etl_Analytics_Mobile_Version_01.Fragments
{
    public class Fragment1 : Android.Support.V4.App.Fragment
    {
        private ExpandableListViewAdapter mAdapter;
        private ExpandableListView expandableListView;
        private List<string> group = new List<string>();
        private Dictionary<string, List<string>> dicMyMap; 
        private WebService webService;
        private List<LogTable> logTable;
        private ViewGroup mContainer;
        private View view;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here           
            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            view = inflater.Inflate(Resource.Layout.Fragment1, container, false);
            expandableListView = view.FindViewById<ExpandableListView>(Resource.Id.expendableListView);

            mContainer = container;            

            SetData(out mAdapter);
            expandableListView.SetAdapter(mAdapter);
            return view;
        }

        private void SetData(out ExpandableListViewAdapter mAdapter)
        {
            webService = new WebService();
            logTable = new List<LogTable>();
            logTable = webService.GetAllDataLogTable();
            dicMyMap = new Dictionary<string, List<string>>();
            int counter = 0;

            foreach (LogTable row in logTable)
            {
                List<string> groupA = new List<string>();
                group.Add((counter + 1).ToString() + " " + row.PROCEDURE_NAME.ToString() + " " + row.DATE_TIME.ToString() + " " + row.ACTION.ToString()); ;
                groupA.Add(" Id procedure: " + row.PROCEDURE_ID.ToString());
                //groupA.Add(" Ime procedure: " + row.PROCEDURE_NAME.ToString());
                if (row.ERROR_DESCRIPTION != null)
                {
                    groupA.Add(" Error: " + row.ERROR_DESCRIPTION);
                }

                dicMyMap.Add(group[counter], groupA);
                counter++;
            }

            mAdapter = new ExpandableListViewAdapter(mContainer.Context, group, dicMyMap);

        }
    }
}