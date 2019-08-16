using Minicurso.NetCore.MongoDB.Domain.Base;
using Minicurso.NetCore.MongoDB.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Domain
{
    public class ItemPedido : Entidade
    {
        public ItemPedido(IItem item, int quantidade)
        {
            Item = item ?? throw new Exception("Produto não pode ser nulo!");
            Quantidade = quantidade;
        }

        public IItem Item { get; private set; }
        public int Quantidade { get; set; }
        public decimal Valor
        {
            get
            {
                return Math.Round(Item.Valor * Quantidade, 2);
            }
        }


    }
}
