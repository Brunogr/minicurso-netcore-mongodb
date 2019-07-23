using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Domain
{
    public class ItemCozinha
    {
        public ItemCozinha(ItemPedido itemPedido, Guid comandaId)
        {
            ItemPedido = itemPedido;
            ComandaId = comandaId;
            ItemPedido.Status = ItemPedido.EStatusPedido.FilaEspera;
        }

        public ItemPedido ItemPedido { get; set; }
        public DateTime? DataInicioPreparo { get; set; }
        public DateTime? DataFimPreparo { get; set; }
        public Guid ComandaId { get; set; }
        public void IniciarPreparo()
        {
            DataInicioPreparo = DateTime.Now;
            ItemPedido.Status = ItemPedido.EStatusPedido.EmPreparo;
        }

        public void FinalizarPreparo()
        {
            DataFimPreparo = DateTime.Now;
            ItemPedido.Status = ItemPedido.EStatusPedido.Finalizado;
        }
    }
}
