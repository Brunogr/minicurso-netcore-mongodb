using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Minicurso.NetCore.MongoDB.Infra.Data.Configuration
{
    public class DbConnection : IDbConnection
    {
        readonly IMongoDatabase mongoDatabase;
        public DbConnection(DatabaseConfiguration configuration)
        {
            var client = new MongoClient(configuration.ConnectionString);
            mongoDatabase = client.GetDatabase(configuration.DatabaseName);
        }

        public IMongoDatabase MongoDatabase => mongoDatabase;
    }
}
