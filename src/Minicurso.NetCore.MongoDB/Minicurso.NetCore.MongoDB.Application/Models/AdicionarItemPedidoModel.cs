using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Application.ViewModels
{
    public class AdicionarItemPedidoModel
    {
        public AdicionarItemPedidoModel()
        {
            Itens = new List<ItemPedidoModel>();
        }

        public Guid PedidoId;
        public List<ItemPedidoModel> Itens;
    }
}
