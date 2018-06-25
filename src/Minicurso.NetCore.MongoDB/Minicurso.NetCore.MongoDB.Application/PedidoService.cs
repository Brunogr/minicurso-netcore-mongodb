using Minicurso.NetCore.MongoDB.Application.Interface;
using Minicurso.NetCore.MongoDB.Application.ViewModels;
using Minicurso.NetCore.MongoDB.Domain;
using Minicurso.NetCore.MongoDB.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Minicurso.NetCore.MongoDB.Application
{
    public class PedidoService : IPedidoService
    {
        IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }


        public Pedido AdicionarItem(Guid id, ItemPedidoViewModel viewModel)
        {
            var pedido = _pedidoRepository.Get(id);

            var produto = new Produto(viewModel.produto.Nome, viewModel.produto.Valor);

            var item = new ItemPedido(produto, viewModel.quantidade);

            pedido.AdicionarItem(item);

            pedido = _pedidoRepository.Update(pedido);

            return pedido;
        }

        public Pedido CriarPedido(CriarPedidoViewModel viewModel)
        {
            var atendente = new Atendente(viewModel.atendente.Nome, viewModel.atendente.Cpf);
            var pedido = new Pedido(viewModel.Mesa, atendente);

            _pedidoRepository.Insert(pedido);

            return pedido;
        }

        public Pedido EfetuarPagamento(Guid id, decimal valor)
        {
            var pedido = _pedidoRepository.Get(id);

            pedido.EfetuarPagamento(valor);

            _pedidoRepository.Update(pedido);

            return pedido;
        }
    }
}
