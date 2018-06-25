using Minicurso.NetCore.MongoDB.Domain;
using Minicurso.NetCore.MongoDB.Infra.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Minicurso.NetCore.MongoDB.Infra.Data
{
    public class PedidoRepository : IPedidoRepository
    {
        MongoClient _client;
        IMongoDatabase _database;
        IMongoCollection<Pedido> _collection;
        public PedidoRepository()
        {
            _client = new MongoClient("mongodb+srv://admin:admin@cluster0-f7uk1.mongodb.net/test?retryWrites=true");
            _database = _client.GetDatabase("Minicurso");
            _collection = _database.GetCollection<Pedido>("Pedido");
        }

        public bool Delete(Guid id)
        {
            FilterDefinition<Pedido> filters = Builders<Pedido>.Filter.Where(f => f.Id == id);
            return _collection.DeleteOne(filters).IsAcknowledged;
        }

        public Pedido Get(Guid id)
        {
            return _collection.Find(p => p.Id == id).FirstOrDefault();
        }

        public List<Pedido> GetAll()
        {
            return _collection.Find(new BsonDocument()).ToList();
        }

        public List<Pedido> GetByFilter(Expression<Func<Pedido, bool>> filter)
        {
            FilterDefinition<Pedido> filters = Builders<Pedido>.Filter.Where(filter);
            return _collection.Find(filters).ToList();
        }

        public Pedido Insert(Pedido pedido)
        {
            _collection.InsertOne(pedido);

            return pedido;
        }

        public Pedido Update(Pedido pedido)
        {
            FilterDefinition<Pedido> filters = Builders<Pedido>.Filter.Where(f => f.Id == pedido.Id);
            UpdateDefinition<Pedido> update = Builders<Pedido>.Update
                .Set(u => u.Pedidos, pedido.Pedidos)
                .Set(u => u.Ativo, pedido.Ativo)
                .Set(u => u.Mesa, pedido.Mesa)
                .Set(u => u.ValorPago, pedido.ValorPago);

            _collection.UpdateOne(filters, update);

            return pedido;
        }
    }
}
