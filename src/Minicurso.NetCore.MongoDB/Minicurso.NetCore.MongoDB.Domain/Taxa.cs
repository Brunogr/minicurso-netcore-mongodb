using Minicurso.NetCore.MongoDB.Domain.Base;
using Minicurso.NetCore.MongoDB.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Domain
{
    public class Taxa : Entidade, IItem
    {
        public Taxa(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
    }
}
