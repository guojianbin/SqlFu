﻿using System.Data.Common;
using SqlFu;
using SqlFu.Providers.SqlServer;
using System.Data.SqlClient;
using CavemanTools.Logging;

namespace Tests.SqlServer
{
    public class Setup
    {
        public const string Connex = @"Data Source=.\SQLExpress;Initial Catalog=tempdb;Integrated Security=True;MultipleActiveResultSets=True;Asynchronous Processing=True";

        static Setup()
        {
            LogManager.OutputTo(s=>System.Diagnostics.Debug.WriteLine(s));
            SqlFuManager.Configure(c =>
            {
                c.AddProfile(new SqlServer2012Provider(SqlClientFactory.Instance.CreateConnection),Connex);
            });
        }

        public static DbConnection GetConnection() => SqlFuManager.GetDbFactory().Create();


    }
}