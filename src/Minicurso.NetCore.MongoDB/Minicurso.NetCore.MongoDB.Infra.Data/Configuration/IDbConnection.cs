using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Infra.Data.Configuration
{
    public interface IDbConnection
    {
        IMongoDatabase MongoDatabase { get; }
    }
}
