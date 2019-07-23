using Minicurso.NetCore.MongoDB.Domain.Base;
using Minicurso.NetCore.MongoDB.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Domain
{
    public class ItemPedido : Entidade
    {
        public ItemPedido(IItem item, int quantidade, bool prepararCozinha)
        {
            Item = item ?? throw new Exception("Produto não pode ser nulo!");
            Quantidade = quantidade;
            PrepararCozinha = prepararCozinha;
        }

        public bool PrepararCozinha { get; set; }
        public EStatusPedido Status { get; set; }
        public IItem Item { get; private set; }
        public int Quantidade { get; set; }
        public decimal Valor
        {
            get
            {
                if (Item is Desconto)
                    return Math.Round((Item.Valor * (-1)) * Quantidade, 2);

                return Math.Round(Item.Valor * Quantidade, 2);
            }
        }

        public enum EStatusPedido
        {
            Finalizado = 0,
            FilaEspera = 1,
            EmPreparo = 2
        }
    }
}
