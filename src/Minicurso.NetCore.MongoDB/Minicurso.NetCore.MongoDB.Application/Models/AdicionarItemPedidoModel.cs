using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Application.ViewModels
{
    public class AdicionarItemPedidoViewModel
    {
        public AdicionarItemPedidoViewModel()
        {
            Itens = new List<ItemPedidoViewModel>();
        }

        public Guid PedidoId;
        public List<ItemPedidoViewModel> Itens;
    }
}
