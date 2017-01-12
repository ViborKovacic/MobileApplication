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
using Java.Util;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;

namespace Etl_Analytics_Mobile_Version_01.Class
{
    public class SearchList
    {
        private static List<StatsTables> mListSearchStatsTables;
        public SearchList()
        {

        }
        public SearchList(List<StatsTables> list)
        {
            mListSearchStatsTables = new List<StatsTables>();
            mListSearchStatsTables = list;
        }

        public List<StatsTables> GetDataFromSearchListStatsTable()
        {
            return mListSearchStatsTables;
        }
    }
}