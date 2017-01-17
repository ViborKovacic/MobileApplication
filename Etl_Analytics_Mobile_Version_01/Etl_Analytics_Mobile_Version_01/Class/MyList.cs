using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace Etl_Analytics_Mobile_Version_01.Class
{
    public class MyList<T>
    {
        private List<T> mItems;
        private RecyclerView.Adapter mAdapter;

        public MyList()
        {
            mItems = new List<T>();
        }

        public RecyclerView.Adapter Adapter
        {
            get { return mAdapter; }
            set { mAdapter = value; }
        }

        public void Add(T item)
        {
            mItems.Add(item);

            if (Adapter != null)
            {
                Adapter.NotifyItemInserted(0);
            }

        }

        public T Where(Func<T, bool> p)
        {
            return mItems.Where(p).FirstOrDefault();
        }


        public void Remove(int position)
        {
            mItems.RemoveAt(position);

            if (Adapter != null)
            {
                Adapter.NotifyItemRemoved(0);
            }
        }

        public T this[int index]
        {
            get { return mItems[index]; }
            set { mItems[index] = value; }
        }

        public int Count
        {
            get { return mItems.Count; }
        }

    }
}