using Minicurso.NetCore.MongoDB.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Domain
{
    public class ItemPedido : Entidade
    {
        public ItemPedido(Produto produto, int quantidade)
        {
            if (produto == null)
                throw new Exception("Produto não pode ser nulo");

            Produto = produto;
            Quantidade = quantidade;
        }

        public Produto Produto { get; private set; }
        public int Quantidade { get; set; }
        public decimal Valor {
            get
            {
                return Math.Round(Produto.Valor * Quantidade, 2);
            }
        }
    }
}
