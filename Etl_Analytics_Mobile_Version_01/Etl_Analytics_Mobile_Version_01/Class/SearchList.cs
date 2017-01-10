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
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;

namespace Etl_Analytics_Mobile_Version_01.Class
{
    public class SearchList
    {
        public static List<StatsTables> mListSearchStatsTables;
        public SearchList()
        {
            mListSearchStatsTables = new List<StatsTables>();
        }

        public void PutDataToSearchedListStatsTable(List<StatsTables> list)
        {
            mListSearchStatsTables = list;
        }
        public List<StatsTables> GetDataFromSearchListStatsTable()
        {
            return mListSearchStatsTables;
        }
    }
}