using Minicurso.NetCore.MongoDB.Domain;
using Minicurso.NetCore.MongoDB.Infra.Data.Base;
using Minicurso.NetCore.MongoDB.Infra.Data.Configuration;
using Minicurso.NetCore.MongoDB.Infra.Data.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Infra.Data
{
    public class CozinhaRepository : Repository<ItemCozinha>, ICozinhaRepository
    {
        public CozinhaRepository(IDbConnection connection) : base(connection)
        {
        }

        protected internal override UpdateDefinition<ItemCozinha> UpdateDefinition(ItemCozinha entidade)
        {
            return Builders<ItemCozinha>.Update
                .Set(u => u.ComandaId, entidade.ComandaId)
                .Set(u => u.DataFimPreparo, entidade.DataFimPreparo)
                .Set(u => u.DataInicioPreparo, entidade.DataInicioPreparo)
                .Set(u => u.Id, entidade.Id);
        }
    }
}
