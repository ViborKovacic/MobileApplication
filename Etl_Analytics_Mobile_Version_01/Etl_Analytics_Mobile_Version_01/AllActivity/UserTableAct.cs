using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.V7.Widget;
using Etl_Analytics_Mobile_Version_01.Class;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;

namespace Etl_Analytics_Mobile_Version_01.AllActivity
{
    [Activity(Label = "UserTableAct", Icon = "@drawable/icon", Theme = "@style/CustomActionBarTheme3")]
    public class UserTableAct : Activity
    {
        private RecyclerView mRecycleView;
        private RecyclerView.LayoutManager mLayoutManager;
        private RecyclerView.Adapter mAdapter;
        private List<UserTable> mListUserTable;
        private WebService webService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UserTableMain);

            mRecycleView = FindViewById<RecyclerView>(Resource.Id.userTableRecycleView);
            webService = new WebService();
            mListUserTable = new List<UserTable>();
            mListUserTable = webService.GetAllDataUserTable();
            
            mLayoutManager = new LinearLayoutManager(this);
            mRecycleView.SetLayoutManager(mLayoutManager);
            mAdapter = new RecyclerAdapter(mListUserTable, mRecycleView, this);
            mRecycleView.SetAdapter(mAdapter);

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbarrecycleview, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.add:
                    mListUserTable.Add(new UserTable() { USER_NAME = "New user name", FIRST_NAME = "New first name", LAST_NAME = "New last name", EMAIL = "New email", PASSWORD = "New password", USER_TYPE = int.Parse("0") });
                    mAdapter.NotifyItemInserted(0);
                    return true;

                case Resource.Id.discard:
                    mListUserTable.RemoveAt(mListUserTable.Count - 1);
                    mAdapter.NotifyItemRemoved(0);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}