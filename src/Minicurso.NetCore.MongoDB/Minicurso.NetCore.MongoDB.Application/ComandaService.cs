using Minicurso.NetCore.MongoDB.Application.Interface;
using Minicurso.NetCore.MongoDB.Application.ViewModels;
using Minicurso.NetCore.MongoDB.Domain;
using Minicurso.NetCore.MongoDB.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Application
{
    public class ComandaService : IComandaService
    {
        private readonly IComandaRepository comandaRepository;

        public ComandaService(IComandaRepository comandaRepository)
        {
            this.comandaRepository = comandaRepository;
        }

        public Comanda AdicionarItem(Guid id, ItemPedidoModel viewModel)
        {
            var comanda = comandaRepository.Get(id);

            var produto = new Produto(viewModel.produto.Nome, viewModel.produto.Valor);

            var itemPedido = new ItemPedido(produto, viewModel.quantidade);

            comanda.AdicionarItem(itemPedido);

            comandaRepository.Update(comanda);

            return comanda;
        }

        public Comanda CriarComanda(CriarComandaModel viewModel)
        {
            var comandaExistente = comandaRepository.GetByFilter(com => com.Mesa == viewModel.Mesa && com.Atendente.Id == viewModel.atendente.Id);

            if (comandaExistente.Any())
                throw new Exception("Comanda já existente");

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
