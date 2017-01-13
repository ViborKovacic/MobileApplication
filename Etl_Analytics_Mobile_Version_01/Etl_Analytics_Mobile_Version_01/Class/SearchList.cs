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
        private static List<StatsColumns> mListSearch;
        public SearchList()
        {

        }
        public SearchList(List<StatsColumns> list)
        {
            mListSearch = new List<StatsColumns>();
            mListSearch = list;
        }

        public List<StatsColumns> GetDataFromSearchList()
        {
            return mListSearch;
        }
    }
}