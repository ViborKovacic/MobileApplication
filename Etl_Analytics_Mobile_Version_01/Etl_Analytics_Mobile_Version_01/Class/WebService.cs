using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Etl_Analytics_Mobile_Version_01.Class.Table_Constructor;
using Etl_Analytics_Mobile_Version_01;
using System.Threading;
using Android.Views;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Org.Json;
using System.Net.Http;
using System.Text;
using RestSharp;
using Newtonsoft.Json.Linq;


namespace Etl_Analytics_Mobile_Version_01.Class
{
    public class WebService : Activity
    {
        private RestClient client;
        private RestRequest request;

        public List<LogTable> GetAllDataLogTable()
        {
            List<LogTable> logTable = new List<LogTable>();
            client = new RestClient("http://insite2crm6.in2.hr");
            request = new RestRequest("etlservice/api/LogTable", Method.GET);
            logTable = client.Execute<List<LogTable>>(request).Data;

            return logTable;
        }

        public List<UserTable> GetAllDataUserTable()
        {
            List<UserTable> userTable = new List<UserTable>();
            client = new RestClient("http://insite2crm6.in2.hr");
            request = new RestRequest("etlservice/api/UserTable", Method.GET);
            userTable = client.Execute<List<UserTable>>(request).Data;

            return userTable;
        }

        public string AddNewUser(UserTable json)
        {
            client = new RestClient("http://insite2crm6.in2.hr");
            var request = new RestRequest("etlservice/api/UserTable", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(json);
            IRestResponse response = client.Execute(request);
            return response.Content.ToString();
        }

        public List<ColumnName> GetAllColumnNames(string owner, string table_name)
        {
            List<ColumnName> columnNamesList = new List<ColumnName>();
            client = new RestClient("http://insite2crm6.in2.hr");
            request = new RestRequest("etlservice/api/ColumnName", Method.GET);
            request.AddParameter("table_name", table_name);
            request.AddParameter("owner", owner);
            columnNamesList = client.Execute<List<ColumnName>>(request).Data;

            return columnNamesList;
        }

        public List<StatsTables> GetAllDataStatsTable()
        {
            List<StatsTables> statTable = new List<StatsTables>();
            client = new RestClient("http://insite2crm6.in2.hr");
            request = new RestRequest("etlservice/api/StatsTables", Method.GET);
            statTable = client.Execute<List<StatsTables>>(request).Data;

            return statTable;
        }

        public List<TableName> GetAllDataTableName(string owner)
        {
            List<TableName> tableName = new List<TableName>();
            client = new RestClient("http://insite2crm6.in2.hr");
            request = new RestRequest("etlservice/api/TableNames", Method.GET);
            request.AddParameter("owner", owner);
            tableName = client.Execute<List<TableName>>(request).Data;

            return tableName;
        }
    }
}