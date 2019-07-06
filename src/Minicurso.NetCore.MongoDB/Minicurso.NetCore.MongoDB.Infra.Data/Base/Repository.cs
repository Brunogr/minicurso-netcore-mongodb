using Minicurso.NetCore.MongoDB.Domain.Base;
using Minicurso.NetCore.MongoDB.Infra.Data.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Minicurso.NetCore.MongoDB.Infra.Data.Base
{
    public abstract class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : Entidade
    {

        IMongoCollection<TEntidade> _collection;
        public Repository(IDbConnection connection)
        {
            _collection = connection.MongoDatabase.GetCollection<TEntidade>(nameof(TEntidade));
        }

        public bool Delete(Guid id)
        {
            FilterDefinition<TEntidade> filters = Builders<TEntidade>.Filter.Where(f => f.Id == id);
            return _collection.DeleteOne(filters).IsAcknowledged;
        }

        public TEntidade Get(Guid id)
        {
            return _collection.Find(p => p.Id == id).FirstOrDefault();
        }

        public List<TEntidade> GetAll()
        {
            return _collection.Find(new BsonDocument()).ToList();
        }

        public List<TEntidade> GetByFilter(Expression<Func<TEntidade, bool>> filter)
        {
            FilterDefinition<TEntidade> filters = Builders<TEntidade>.Filter.Where(filter);
            return _collection.Find(filters).ToList();
        }

        public TEntidade Insert(TEntidade pedido)
        {
            _collection.InsertOne(pedido);

            return pedido;
        }

        public TEntidade Update(TEntidade entidade)
        {
            FilterDefinition<TEntidade> filters = Builders<TEntidade>.Filter.Where(f => f.Id == entidade.Id);

            UpdateDefinition<TEntidade> update = UpdateDefinition(entidade);

            _collection.UpdateOne(filters, update);

            return entidade;
        }

        protected internal abstract UpdateDefinition<TEntidade> UpdateDefinition(TEntidade entidade);
    }
}
