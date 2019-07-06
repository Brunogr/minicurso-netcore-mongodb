using Minicurso.NetCore.MongoDB.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Infra.Data.Base
{
    public interface IRepository<TEntidade> where TEntidade : Entidade
    {
        TEntidade Get(Guid id);
        TEntidade Insert(TEntidade pedido);
        List<TEntidade> GetAll();
        List<TEntidade> GetByFilter(Expression<Func<TEntidade, bool>> filter);
        TEntidade Update(TEntidade pedido);
        bool Delete(Guid id);
    }
}
