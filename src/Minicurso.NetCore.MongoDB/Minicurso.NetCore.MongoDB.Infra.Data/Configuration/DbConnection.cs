using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Minicurso.NetCore.MongoDB.Infra.Data.Configuration
{
    public class DbConnection : IDbConnection
    {
        MongoClient mongoClient;
        IMongoDatabase dataBase;
        public DbConnection(DataBaseConfiguration dataBaseConfiguration)
        {
            mongoClient = new MongoClient(dataBaseConfiguration.ConnectionString);
            dataBase = mongoClient.GetDatabase(dataBaseConfiguration.DataBaseName);
        }

        public IMongoDatabase MongoDatabase => dataBase;
    }
}
