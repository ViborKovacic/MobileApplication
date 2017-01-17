using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;

namespace Etl_Analytics_Mobile_Version_01.Class
{
    public class ConfigTableAdapter : RecyclerView.Adapter
    {
        private MyList<ListTableNames> mListTableName;
        private RecyclerView mRecyclerView;
        private Context mContext;

        public ConfigTableAdapter(MyList<ListTableNames> listTableName, RecyclerView recyclerView)
        {
            mListTableName = listTableName;
            mRecyclerView = recyclerView;
        }

        public override int ItemCount
        {
            get
            {
                return mListTableName.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ConfigTableHolder tableHolder = holder as ConfigTableHolder;

            tableHolder.mViewConfigTable.Click += (s, e) => MViewConfigTable_Click(s, e, tableHolder);

            ConfigColumnAdapter adapter = new ConfigColumnAdapter(mListTableName[position].ListColumnNames, tableHolder.mConfigColumn);
            mListTableName[position].ListColumnNames.Adapter = adapter;
            tableHolder.mConfigColumn.SetAdapter(adapter);

            if (mListTableName[position].SubRec == null)
            {
                float scale = tableHolder.mConfigColumn.Context.Resources.DisplayMetrics.Density;
                tableHolder.mConfigColumn.SetMinimumHeight((int)(45 * scale + 0.5f) * mListTableName[position].ListColumnNames.Count);
                mListTableName[position].SubRec = tableHolder.mConfigColumn;
            }

            tableHolder.mTitle.Text = mListTableName[position].TableName;
            tableHolder.mChecked.Checked = mListTableName[position].TableChecked;
            tableHolder.mChecked.Click += delegate
            {
                for (int i = 0; i < mListTableName[position].ListColumnNames.Count; i++)
                    mListTableName[position].ListColumnNames[i].ColumnSelected = tableHolder.mChecked.Checked;
                adapter = new ConfigColumnAdapter(mListTableName[position].ListColumnNames, tableHolder.mConfigColumn); 
                mListTableName[position].ListColumnNames.Adapter = adapter;
                tableHolder.mConfigColumn.SetAdapter(adapter);
                mListTableName[position].TableChecked = tableHolder.mChecked.Checked;
            };
        }

        private void MViewConfigTable_Click(object sender, EventArgs e, ConfigTableHolder mTableHolder)
        {
            mTableHolder.mConfigColumn.Visibility = (mTableHolder.mConfigColumn.Visibility == ViewStates.Gone) ? ViewStates.Visible : ViewStates.Gone;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            mContext = parent.Context;

            View view = LayoutInflater.From(mContext).Inflate(Resource.Layout.ConfigTableRow, parent, false);
            TextView textView = view.FindViewById<TextView>(Resource.Id.textViewConfigTable);
            CheckBox checkBox = view.FindViewById<CheckBox>(Resource.Id.checkBoxConfigTable);

            RecyclerView recycleView = view.FindViewById<RecyclerView>(Resource.Id.recyclerViewConfigTableRow);
            LinearLayoutManager linerLayoutManager = new LinearLayoutManager(mContext, LinearLayoutManager.Vertical, false);

            recycleView.SetLayoutManager(linerLayoutManager);

            ConfigTableHolder tableHolder = new ConfigTableHolder(view)
            {
                mTitle = textView,
                mChecked = checkBox,
                mConfigColumn = recycleView
            };

            return tableHolder;
        }
    }
}