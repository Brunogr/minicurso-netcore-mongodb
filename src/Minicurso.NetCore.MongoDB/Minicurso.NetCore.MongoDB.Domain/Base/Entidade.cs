using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Domain.Base
{
    public abstract class Entidade
    {
        public Entidade()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
