using learn.core.domain;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace learn.infra
{
    
    public class Dbcontext : IDBContext
    {
        private DbConnection connection;
        private IConfiguration configuration;
        public Dbcontext(DbConnection connection, IConfiguration configuration)
        {
            this.connection = connection;
            this.configuration = configuration;
        }
        public DbConnection dBConnection
        {
            get
            {
                if (connection == null)
                {

                    connection = new OracleConnection(configuration["ConnectionStrings:DBConnectionString"]);

                    connection.Open();
                }
                else if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                return connection;
            }
        }
    }
}
