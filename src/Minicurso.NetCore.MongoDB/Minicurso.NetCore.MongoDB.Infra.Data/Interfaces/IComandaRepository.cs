using Minicurso.NetCore.MongoDB.Domain;
using Minicurso.NetCore.MongoDB.Infra.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Infra.Data.Interfaces
{
    public interface IComandaRepository : IRepository<Comanda>
    {
    }
}
