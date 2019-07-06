using Minicurso.NetCore.MongoDB.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Infra.Data.Interfaces
{
    public interface IComandaRepository
    {
        Comanda Get(Guid id);
        Comanda Insert(Comanda pedido);
        List<Comanda> GetAll();
        List<Comanda> GetByFilter(Expression<Func<Comanda, bool>> filter);
        Comanda Update(Comanda pedido);
        bool Delete(Guid id);
    }
}
