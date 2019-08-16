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
    public class CozinhaService : ICozinhaService
    {
        private readonly ICozinhaRepository _cozinhaRepository;
        private readonly IComandaRepository _comandaRepository;
        public CozinhaService(ICozinhaRepository cozinhaRepository, IComandaRepository comandaRepository)
        {
            _cozinhaRepository = cozinhaRepository;
            _comandaRepository = comandaRepository;
        }

        public ItemCozinha IniciarPreparo(Guid id)
        {
            var itemCozinha = _cozinhaRepository.Get(id);

            itemCozinha.DataInicioPreparo = DateTime.Now;
            itemCozinha.Produto.Status = EStatusPedido.EmPreparo;
            return _cozinhaRepository.Update(itemCozinha);
        }

        public ItemCozinha FinalizarPreparo(Guid id)
        {
            var itemCozinha = _cozinhaRepository.Get(id);

            itemCozinha.DataFimPreparo = DateTime.Now;
            itemCozinha.Produto.Status = EStatusPedido.Finalizado;
            return _cozinhaRepository.Update(itemCozinha);
        }

        public List<ItemCozinha> AtualizarCozinha()
        {
            var comandasAtivas = _comandaRepository.GetByFilter(a => a.Ativo);

            List<IItem> produtos = new List<IItem>();
            List<ItemCozinha> itensCozinha = new List<ItemCozinha>();

            foreach (var comanda in comandasAtivas)
            {
                produtos.AddRange(comanda.Pedidos.Select(a => a.Item).Where(a => a is Produto));

                produtos = produtos.Where(a => ((Produto)a).PrepararCozinha).ToList();
                ItemCozinha itemCozinha;
                foreach (var produto in produtos)
                {
                    itemCozinha = new ItemCozinha((Produto)produto, comanda.Id);
                    itensCozinha.Add(itemCozinha);
                    _cozinhaRepository.Insert(itemCozinha);
                }
            }
            return itensCozinha;
        }
    }
}
