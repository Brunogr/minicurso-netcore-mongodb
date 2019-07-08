using Minicurso.NetCore.MongoDB.Domain;
using Minicurso.NetCore.MongoDB.Infra.Data.Base;
using Minicurso.NetCore.MongoDB.Infra.Data.Configuration;
using Minicurso.NetCore.MongoDB.Infra.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Minicurso.NetCore.MongoDB.Infra.Data
{
    public class ComandaRepository : Repository<Comanda>, IComandaRepository
    {
        public ComandaRepository(IDbConnection connection) : base(connection)
        {
        }

        protected internal override UpdateDefinition<Comanda> UpdateDefinition(Comanda entidade)
        {
            return Builders<Comanda>.Update
                .Set(u => u.Pedidos, entidade.Pedidos)
                .Set(u => u.Ativo, entidade.Ativo)
                .Set(u => u.Mesa, entidade.Mesa)
                .Set(u => u.ValorPago, entidade.ValorPago);
        }
    }
}
