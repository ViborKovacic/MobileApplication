using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Class
{
    public class DBConnection
        {
            private static DBConnection instance;
            private string connectionString;
            private OracleConnection connection;

            public static DBConnection Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new DBConnection();
                    }

                    return instance;
                }
            }

            public string ConnectionString
            {
                get { return connectionString; }
                set { connectionString = value; }
            }

            public OracleConnection Connection
            {
                get { return connection; }
                set { connection = value; }
            }

            private DBConnection()
            {
                string connectionStrings = "DATA SOURCE=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 10.201.9.85)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME=crmdev)));PASSWORD=INSITE_DEMO;PERSIST SECURITY INFO=True;USER ID=INSITE_DEMO; POOLING=true";
                Connection = new OracleConnection(connectionStrings);
                Connection.Open();
            }

            ~DBConnection()
            {
                Connection.Close();
                Connection = null;
            }

            public OracleConnection GetConnString()
            {
                OracleConnection connectionString = new OracleConnection("DATA SOURCE=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 10.201.9.85)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME=crmdev)));PASSWORD=INSITE_DEMO;PERSIST SECURITY INFO=True;USER ID=INSITE_DEMO; POOLING=true");
                return connectionString;

            }

            public OracleDataReader GetDataReader(string sqlQuery)
            {
                OracleCommand comm = new OracleCommand(sqlQuery, Connection);
                return comm.ExecuteReader();
            }
        }
    }