using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Domain.Interface
{
    public interface IItem
    {
        string Nome { get; }
        decimal Valor { get; }
    }
}
