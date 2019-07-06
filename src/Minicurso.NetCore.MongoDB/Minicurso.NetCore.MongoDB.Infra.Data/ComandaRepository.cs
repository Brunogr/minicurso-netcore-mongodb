using Minicurso.NetCore.MongoDB.Domain;
using Minicurso.NetCore.MongoDB.Infra.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Minicurso.NetCore.MongoDB.Infra.Data
{
    public class ComandaRepository : IComandaRepository
    {
        MongoClient _client;
        IMongoDatabase _database;
        IMongoCollection<Comanda> _collection;
        public ComandaRepository()
        {
            _client = new MongoClient("mongodb+srv://admin:admin@cluster0-f7uk1.mongodb.net/test?retryWrites=true");
            _database = _client.GetDatabase("Minicurso");
            _collection = _database.GetCollection<Comanda>(nameof(Comanda));
        }

        public bool Delete(Guid id)
        {
            FilterDefinition<Comanda> filters = Builders<Comanda>.Filter.Where(f => f.Id == id);
            return _collection.DeleteOne(filters).IsAcknowledged;
        }

        public Comanda Get(Guid id)
        {
            return _collection.Find(p => p.Id == id).FirstOrDefault();
        }

        public List<Comanda> GetAll()
        {
            return _collection.Find(new BsonDocument()).ToList();
        }

        public List<Comanda> GetByFilter(Expression<Func<Comanda, bool>> filter)
        {
            FilterDefinition<Comanda> filters = Builders<Comanda>.Filter.Where(filter);
            return _collection.Find(filters).ToList();
        }

        public Comanda Insert(Comanda pedido)
        {
            _collection.InsertOne(pedido);

            return pedido;
        }

        public Comanda Update(Comanda pedido)
        {
            FilterDefinition<Comanda> filters = Builders<Comanda>.Filter.Where(f => f.Id == pedido.Id);
            UpdateDefinition<Comanda> update = Builders<Comanda>.Update
                .Set(u => u.Pedidos, pedido.Pedidos)
                .Set(u => u.Ativo, pedido.Ativo)
                .Set(u => u.Mesa, pedido.Mesa)
                .Set(u => u.ValorPago, pedido.ValorPago);

            _collection.UpdateOne(filters, update);

            return pedido;
        }
    }
}
