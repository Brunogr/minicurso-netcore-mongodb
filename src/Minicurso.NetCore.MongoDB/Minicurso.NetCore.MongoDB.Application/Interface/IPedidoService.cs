using Minicurso.NetCore.MongoDB.Application.ViewModels;
using Minicurso.NetCore.MongoDB.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Application.Interface
{
    public interface IPedidoService
    {
        Pedido CriarPedido(CriarPedidoModel viewModel);

        Pedido AdicionarItem(Guid id, ItemPedidoModel viewModel);

        Pedido EfetuarPagamento(Guid id, decimal valor);
    }
}
