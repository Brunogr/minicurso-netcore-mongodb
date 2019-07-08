using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Infra.Data.Configuration
{
    public class DatabaseConfiguration
    {
        public DatabaseConfiguration()
        {
        }

        public DatabaseConfiguration AddConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
            return this;
        }

        public DatabaseConfiguration AddDatabaseName(string databaseName)
        {
            DatabaseName = databaseName;
            return this;
        }
        internal string ConnectionString { get; private set; }
        internal string DatabaseName { get; private set; }
    }
}
