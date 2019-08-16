using Minicurso.NetCore.MongoDB.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Domain
{
    public class ItemCozinha : Entidade
    {
        public ItemCozinha(Produto produto, Guid comandaId)
        {
            Produto = produto;
            ComandaId = comandaId;
            Produto.Status = EStatusPedido.FilaEspera;
        }

        public Produto Produto { get; set; }
        public DateTime? DataInicioPreparo { get; set; }
        public DateTime? DataFimPreparo { get; set; }
        public string TempoPreparo
        {
            get
            {
                if (DataInicioPreparo != null && DataFimPreparo != null)
                    return (DataFimPreparo.Value - DataInicioPreparo.Value).ToString();

                return string.Empty;
            }
        }
        public Guid ComandaId { get; set; }
        public void IniciarPreparo()
        {
            DataInicioPreparo = DateTime.Now;
            Produto.Status = EStatusPedido.EmPreparo;
        }

        public void FinalizarPreparo()
        {
            DataFimPreparo = DateTime.Now;
            Produto.Status = EStatusPedido.Finalizado;
        }
    }
}
