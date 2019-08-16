using Minicurso.NetCore.MongoDB.Application.Interface;
using Minicurso.NetCore.MongoDB.Application.ViewModels;
using Minicurso.NetCore.MongoDB.Domain;
using Minicurso.NetCore.MongoDB.Domain.Enum;
using Minicurso.NetCore.MongoDB.Domain.Interface;
using Minicurso.NetCore.MongoDB.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Application
{
    public class ComandaService : IComandaService
    {
        private readonly IComandaRepository _comandaRepository;

        public ComandaService(IComandaRepository comandaRepository)
        {
            _comandaRepository = comandaRepository;
        }

        public Comanda AdicionarItem(Guid id, ItemPedidoModel itemPedidoModel, ETipoItem tipoItem)
        {
            var comanda = _comandaRepository.Get(id);
            IItem item;
            switch (tipoItem)
            {
                case ETipoItem.Produto:
                default:
                    item = new Produto(itemPedidoModel.item.nome, itemPedidoModel.item.valor, itemPedidoModel.prepararCozinha);
                    break;
                case ETipoItem.Desconto:
                    item = new Desconto(itemPedidoModel.item.nome, itemPedidoModel.item.valor, itemPedidoModel.porcentagem);
                    break;
                case ETipoItem.Taxa:
                    item = new Taxa(itemPedidoModel.item.nome, itemPedidoModel.item.valor, itemPedidoModel.porcentagem);
                    break;
            }

            var itemPedido = new ItemPedido(item, itemPedidoModel.quantidade);

            comanda.AdicionarItem(itemPedido);

            return AtualizarComanda(comanda);
        }

        private Comanda AtualizarComanda(Comanda comanda)
        {
            _comandaRepository.Update(comanda);
            return comanda;
        }

        public Comanda CriarComanda(CriarComandaModel viewModel)
        {
            var comandaExistente = _comandaRepository.GetByFilter(c => c.Mesa == viewModel.Mesa && c.Atendente.Id == viewModel.atendente.Id);

            if (comandaExistente.Any())
                throw new Exception("Comanda existente!");

            var atendente = new Atendente(viewModel.atendente.Nome, viewModel.atendente.Cpf);
            var comanda = new Comanda(viewModel.Mesa, atendente);

            _comandaRepository.Insert(comanda);

            return comanda;
        }

        public Comanda EfetuarPagamento(Guid id, decimal valor)
        {
            var comanda = _comandaRepository.Get(id);

            comanda.EfetuarPagamento(valor);

            _comandaRepository.Update(comanda);

            return comanda;
        }
        
    }
}
