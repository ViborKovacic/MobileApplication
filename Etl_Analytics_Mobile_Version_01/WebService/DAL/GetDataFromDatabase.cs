using Dapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebService.Class;
using WebService.Models;

namespace WebService.DAL
{
    public class GetDataFromDatabase
    {
        OracleConnection conn = DBConnection.Instance.GetConnString();
        public object ProcedureGetDataFromLogTable()
        {
            var paramOut = new OracleDynamicParameters();
            paramOut.Add("c_cursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
            List<LogTable> stateTable = conn.Query<LogTable>("INSITE_DEMO.SEND_ANALYTICS_DATA.CATCH_LOG_TABLE", paramOut, commandType: CommandType.StoredProcedure).ToList();
            var json = JsonConvert.SerializeObject(stateTable);
            var jsonArray = JArray.Parse(json);
            return jsonArray;
        }

        public object ProcedureGetDataFromStatTables()
        {
            var paramOut = new OracleDynamicParameters();
            paramOut.Add("c_cursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
            List<StatsTables> stateTable = conn.Query<StatsTables>("INSITE_DEMO.SEND_ANALYTICS_DATA.CATCH_STATS_TB", paramOut, commandType: CommandType.StoredProcedure).ToList();
            var json = JsonConvert.SerializeObject(stateTable);
            var jsonArray = JArray.Parse(json);
            return jsonArray;
        }

        public object ProcedureGetDataFromStatColumns()
        {
            var paramOut = new OracleDynamicParameters();
            paramOut.Add("c_cursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
            List<StatsColumns> stateTable = conn.Query<StatsColumns>("INSITE_DEMO.SEND_ANALYTICS_DATA.CATCH_STATS_COL", paramOut, commandType: CommandType.StoredProcedure).ToList();
            var json = JsonConvert.SerializeObject(stateTable);
            var jsonArray = JArray.Parse(json);
            return jsonArray;
        }

        public object ProcedureGetDataFromConfigurationTables()
        {
            var paramOut = new OracleDynamicParameters();
            paramOut.Add("c_cursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
            List<ConfigurationTable> stateTable = conn.Query<ConfigurationTable>("INSITE_DEMO.SEND_ANALYTICS_DATA.CATCH_CONFIGURATION_TABLE", paramOut, commandType: CommandType.StoredProcedure).ToList();
            var json = JsonConvert.SerializeObject(stateTable);
            var jsonArray = JArray.Parse(json);
            return jsonArray;
        }

        public object ProcedureGetDataFromConfigurationColumns()
        {
            var paramOut = new OracleDynamicParameters();
            paramOut.Add("c_cursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
            List<ConfigurationTable> stateTable = conn.Query<ConfigurationTable>("INSITE_DEMO.SEND_ANALYTICS_DATA.CATCH_CONFIGURATION_COLUMNS", paramOut, commandType: CommandType.StoredProcedure).ToList();
            var json = JsonConvert.SerializeObject(stateTable);
            var jsonArray = JArray.Parse(json);
            return jsonArray;
        }

        public object ProcedureGetDataFromParametersValue()
        {
            var paramOut = new OracleDynamicParameters();
            paramOut.Add("c_cursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
            List<ParametersVariable> stateTable = conn.Query<ParametersVariable>("INSITE_DEMO.SEND_ANALYTICS_DATA.CATCH_PARAMETERS_VAR", paramOut, commandType: CommandType.StoredProcedure).ToList();
            var json = JsonConvert.SerializeObject(stateTable);
            var jsonArray = JArray.Parse(json);
            return jsonArray;
        }

        public object ProcedureGetDataFromUserTable()
        {
            var paramOut = new OracleDynamicParameters();
            paramOut.Add("c_cursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
            List<UserTable> stateTable = conn.Query<UserTable>("INSITE_DEMO.SEND_ANALYTICS_DATA.CATCH_USER_TABLE", paramOut, commandType: CommandType.StoredProcedure).ToList();
            var json = JsonConvert.SerializeObject(stateTable);
            var jsonArray = JArray.Parse(json);
            return jsonArray;
        }

        public object ProcedureGetDataFromColumnName(string table_name)
        {
            var paramOut = new OracleDynamicParameters();
            paramOut.Add("vTableName", dbType: OracleDbType.Varchar2, value: table_name, direction: ParameterDirection.Input);
            paramOut.Add("c_cursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
            List<ColumnName> stateTable = conn.Query<ColumnName>("INSITE_DEMO.SEND_ANALYTICS_DATA.CATCH_COLUMN_NAME", paramOut, commandType: CommandType.StoredProcedure).ToList();
            var json = JsonConvert.SerializeObject(stateTable);
            var jsonArray = JArray.Parse(json);
            return jsonArray;
        }
    }
}