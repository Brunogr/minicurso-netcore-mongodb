using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Infra.Data.Configuration
{
    public class DataBaseConfiguration
    {
        public DataBaseConfiguration()
        {
        }

        public DataBaseConfiguration AddConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
            return this;
        }
        public DataBaseConfiguration AddDataBaseName(string dataBaseName)
        {
            DataBaseName = dataBaseName;
            return this;
        }

        internal string ConnectionString { get; private set; }
        internal string DataBaseName { get; private set; }
    }
}
