using Minicurso.NetCore.MongoDB.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Infra.Data.Interfaces
{
    public interface IPedidoRepository
    {
        Pedido Get(Guid id);
        Pedido Insert(Pedido pedido);
        List<Pedido> GetAll();
        List<Pedido> GetByFilter(Expression<Func<Pedido, bool>> filter);
        Pedido Update(Pedido pedido);
        bool Delete(Guid id);
    }
}
