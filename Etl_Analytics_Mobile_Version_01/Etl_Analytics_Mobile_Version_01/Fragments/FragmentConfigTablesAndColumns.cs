using System.Collections.Generic;

using Android.Content;
using Android.OS;
using Android.Views;
using Etl_Analytics_Mobile_Version_01.Class;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using Android.Support.V7.Widget;

namespace Etl_Analytics_Mobile_Version_01.Fragments
{
    public class FragmentConfigTablesAndColumns : Android.Support.V4.App.Fragment
    {
        private RecyclerView mRecyclerView;
        private RecyclerView.LayoutManager mLayoutManager;
        private RecyclerView.Adapter mAdapter;
        private WebService webService;
        private List<TableName> mListTable;
        private List<ColumnName> mListColumn;
        private Context mContext;
        private View mView;
        private MyList<ListTableNames> mListTableNames;
        private MyList<ListColumnNames> mListColumnNames;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here           
            mListTable = new List<TableName>();
            mListColumn = new List<ColumnName>();
            webService = new WebService();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            mView = inflater.Inflate(Resource.Layout.FragmentConfigTablesAndColumns, container, false);
            mRecyclerView = mView.FindViewById<RecyclerView>(Resource.Id.recyclerViewConfigTables);
            mLayoutManager = new LinearLayoutManager(mView.Context, LinearLayoutManager.Vertical, false);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            mListTable = webService.GetAllDataTableName("INSITE_DEMO");

            mListTableNames = new MyList<ListTableNames>();

            foreach (TableName row in mListTable)
            {
                mListColumn = webService.GetAllColumnNames("INSITE_DEMO", row.TABLE_NAME);
                mListColumnNames = new MyList<ListColumnNames>();
                foreach (ColumnName item in mListColumn)
                {
                    mListColumnNames.Add(new ListColumnNames
                    {
                        ColumnName = item.COLUMN_NAME,
                        ColumnSelected = true
                    });
                }

                mListTableNames.Add(new ListTableNames
                {
                    TableName = row.TABLE_NAME,
                    TableChecked = true,
                    ListColumnNames = mListColumnNames
                });
            }

            mAdapter = new ConfigTableAdapter(mListTableNames, mRecyclerView);
            mRecyclerView.SetAdapter(mAdapter);

            return mView;
        }
    }
}