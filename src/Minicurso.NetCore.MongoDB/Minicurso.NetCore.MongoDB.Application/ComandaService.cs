using Minicurso.NetCore.MongoDB.Application.Interface;
using Minicurso.NetCore.MongoDB.Application.ViewModels;
using Minicurso.NetCore.MongoDB.Domain;
using Minicurso.NetCore.MongoDB.Domain.Interface;
using Minicurso.NetCore.MongoDB.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Application
{
    public class ComandaService : IComandaSerive
    {
        private readonly IComandaRepository comandaRepository;

        public ComandaService(IComandaRepository comandaRepository)
        {
            this.comandaRepository = comandaRepository;
        }

        public Comanda AdicionarProduto(Guid id, ItemPedidoModel viewModel)
        {
            var comanda = comandaRepository.Get(id);
            var produto = new Produto(viewModel.item.Nome, viewModel.item.Valor);
            ItemPedido item = new ItemPedido(produto, viewModel.quantidade);

            comanda.AdicionarItem(item);

            return SalvarComanda(comanda);
        }

        public Comanda AdicionarDesconto(Guid id, ItemPedidoModel viewModel)
        {
            var comanda = comandaRepository.Get(id);
            var desconto = new Desconto(viewModel.item.Nome, viewModel.item.Valor);
            ItemPedido item = new ItemPedido(desconto, viewModel.quantidade);

            comanda.AdicionarItem(item);

            return SalvarComanda(comanda);
        }
        public Comanda AdicionarTaxa(Guid id, ItemPedidoModel viewModel)
        {
            var comanda = comandaRepository.Get(id);
            var taxa = new Taxa(viewModel.item.Nome, viewModel.item.Valor);
            ItemPedido item = new ItemPedido(taxa, viewModel.quantidade);

            comanda.AdicionarItem(item);
            return SalvarComanda(comanda);
        }

        private Comanda SalvarComanda(Comanda comanda)
        {
            comandaRepository.Update(comanda);
            return comanda;
        }

        public Comanda CriarComanda(CriarComandaModel viewModel)
        {
            var comandaExistente = comandaRepository.GetByFilter(c => c.Mesa == viewModel.Mesa && c.Atendente.Id == viewModel.atendente.Id);

            if (comandaExistente.Any())
                throw new Exception("Comanda existente!");

            var atendente = new Atendente(viewModel.atendente.Nome, viewModel.atendente.Cpf);
            var comanda = new Comanda(viewModel.Mesa, atendente);

            comandaRepository.Insert(comanda);

            return comanda;
        }

        public Comanda EfetuarPagamento(Guid id, decimal valor)
        {
            var comanda = comandaRepository.Get(id);

            comanda.EfetuarPagamento(valor);

            comandaRepository.Update(comanda);

            return comanda;
        }
    }
}
