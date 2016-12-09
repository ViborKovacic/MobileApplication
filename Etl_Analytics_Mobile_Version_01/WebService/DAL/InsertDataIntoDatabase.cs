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
    public class InsertDataIntoDatabase
    {
        OracleConnection conn = DBConnection.Instance.GetConnString();

        private string first_name;
        private string last_name;
        private string user_name;
        private string email;
        private string password;
        private int user_type;

        public void ProcedureInsertIntoUserTable(UserTable user)
        {
            first_name = user.FIRST_NAME;
            last_name = user.LAST_NAME;
            user_name = user.USER_NAME;
            email = user.EMAIL;
            password = user.PASSWORD;
            user_type = user.USER_TYPE;

            var paramIn = new OracleDynamicParameters();
            paramIn.Add("vpFirstName", dbType: OracleDbType.Varchar2, value: first_name, direction: ParameterDirection.Input);
            paramIn.Add("vpLastName", dbType: OracleDbType.Varchar2, value: last_name, direction: ParameterDirection.Input);
            paramIn.Add("vpUserName", dbType: OracleDbType.Varchar2, value: user_name, direction: ParameterDirection.Input);
            paramIn.Add("vpEmail", dbType: OracleDbType.Varchar2, value: email, direction: ParameterDirection.Input);
            paramIn.Add("vpPassword", dbType: OracleDbType.Varchar2, value: password, direction: ParameterDirection.Input);
            paramIn.Add("npUserType", dbType: OracleDbType.Int32, value: user_type, direction: ParameterDirection.Input);
            conn.Query<UserTable>("INSITE_DEMO.INSERT_ANALITYCS_DATA.INSERT_INTO_USER_TABLE", paramIn, commandType: CommandType.StoredProcedure);
        }
    }
}