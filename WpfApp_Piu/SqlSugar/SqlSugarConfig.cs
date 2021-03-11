using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp_Piu.SqlSugar
{
    public class SqlSugarConfig  
    {
        private readonly string _connStr;
        public SqlSugarConfig()
        {
            _connStr = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + @"config/Data.db;";
        }
        public static  SqlSugarClient DbClient { get; set; }
       

        public SqlSugarClient GenerateDbClient()
        {
            var connConfig = new ConnectionConfig
            {
                ConnectionString = _connStr,
                DbType = DbType.Sqlite,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true
            };
            var client = new SqlSugarClient(connConfig);
            return client;
        }
    }
}
