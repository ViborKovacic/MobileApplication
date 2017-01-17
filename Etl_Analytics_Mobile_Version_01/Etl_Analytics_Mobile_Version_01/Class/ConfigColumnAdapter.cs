using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;

namespace Etl_Analytics_Mobile_Version_01.Class
{
    public class ConfigColumnAdapter : RecyclerView.Adapter
    {
        private MyList<ListColumnNames> mListColumnName;
        private RecyclerView mRecyclerViewConfigColumn;

        public ConfigColumnAdapter(MyList<ListColumnNames> listColumnName, RecyclerView recyclerViewConfigColumn)
        {
            mListColumnName = listColumnName;
            mRecyclerViewConfigColumn = recyclerViewConfigColumn;
        }

        public override int ItemCount
        {
            get
            {
                return mListColumnName.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ConfigColumnHolder myHolder = holder as ConfigColumnHolder;
            myHolder.mColumnName.Text = mListColumnName[position].ColumnName;
            myHolder.mCheckBoxColumnName.Checked = mListColumnName[position].ColumnSelected;
            myHolder.mCheckBoxColumnName.Click += delegate
            {
                View v = (View)mRecyclerViewConfigColumn.Parent;
                var mainChk = v.FindViewById<CheckBox>(Resource.Id.checkBoxConfigTable);
                bool allFalse = true;
                mListColumnName[position].ColumnSelected = myHolder.mCheckBoxColumnName.Checked;
                for (int i = 0; i < mListColumnName.Count; i++)
                {
                    if (mListColumnName[i].ColumnSelected == true)
                    {
                        allFalse = false;
                        break;
                    }
                }
                if (allFalse)
                    mainChk.Checked = false;
                else
                    mainChk.Checked = true;

            };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ConfigColumnRow, parent, false);
            var layout = view.FindViewById<LinearLayout>(Resource.Id.linearLayoutConfigColumnRow);
            float scale = layout.Context.Resources.DisplayMetrics.Density;
            parent.SetMinimumHeight((int)(45 * scale + 0.5f) * mListColumnName.Count);
            TextView txtConfigColumn = view.FindViewById<TextView>(Resource.Id.textViewColumnRow);
            CheckBox checkBoxConfigColumn = view.FindViewById<CheckBox>(Resource.Id.checkBoxConfigColumnRow);

            ConfigColumnHolder holderConfigColumn = new ConfigColumnHolder(view)
            {
                mColumnName = txtConfigColumn,
                mCheckBoxColumnName = checkBoxConfigColumn                
            };

            return holderConfigColumn;
        }
    }
}