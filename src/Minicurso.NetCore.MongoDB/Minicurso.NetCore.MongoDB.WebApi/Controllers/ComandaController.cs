﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minicurso.NetCore.MongoDB.Application;
using Minicurso.NetCore.MongoDB.Application.Interface;
using Minicurso.NetCore.MongoDB.Application.ViewModels;
using Minicurso.NetCore.MongoDB.Domain;
using Minicurso.NetCore.MongoDB.Infra.Data.Interfaces;

namespace Minicurso.NetCore.MongoDB.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class ComandaController : Controller
    {
        IComandaService _comandaService;
        IComandaRepository _comandaRepository;

        public ComandaController(IComandaService comandaService, IComandaRepository comandaRepository)
        {
            _comandaService = comandaService;
            _comandaRepository = comandaRepository;
        }

        /// <summary>
        /// Retorna todos os pedidos
        /// </summary>
        /// <returns>Lista de pedidos.</returns>
        [HttpGet]
        public List<Comanda> Get()
        {
            return _comandaRepository.GetAll();
        }

        /// <summary>
        /// Retorna todos os pedidos ativos.
        /// </summary>
        /// <returns>Lista de pedidos ativos.</returns>
        [HttpGet("Mesa/{numeroMesa}")]
        public List<Comanda> GetAtivos(int numeroMesa)
        {
            return _comandaRepository.GetByFilter(p => p.Mesa == numeroMesa && p.Ativo);
        }


        /// <summary>
        /// Retorna todos os pedidos fechados.
        /// </summary>
        /// <returns>Lista de pedidos fechados.</returns>
        [HttpGet("Mesa/{numeroMesa}/Fechado")]
        public List<Comanda> GetFechados(int numeroMesa)
        {
            return _comandaRepository.GetByFilter(p => p.Mesa == numeroMesa && !p.Ativo);
        }

        /// <summary>
        /// Buscar um pedido pelo ID.
        /// </summary>
        /// <param name="id">Id do pedido.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Comanda Get(Guid id)
        {
            return _comandaRepository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public Comanda Post([FromBody]CriarComandaModel value)
        {
            return _comandaService.CriarComanda(value);
        }

        /// <summary>
        /// Método para adicionar produto na comanda
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemPedido"></param>
        /// <returns></returns>
        [HttpPut("{id}/Produto")]
        public Comanda PutProduto(Guid id, [FromBody]ItemPedidoModel itemPedido)
        {
            return _comandaService.AdicionarItem(id, itemPedido, Domain.Enum.ETipoItem.Produto);
        }

        /// <summary>
        /// Método para adicionar desconto na comanda.
        /// </summary>
        /// <param name="id">Id do pedido.</param>
        /// <param name="itemPedido">Item a ser adicionado.</param>
        /// <returns></returns>
        [HttpPut("{id}/Desconto")]
        public Comanda PutDesconto(Guid id, [FromBody]ItemPedidoModel itemPedido)
        {
            return _comandaService.AdicionarItem(id, itemPedido, Domain.Enum.ETipoItem.Desconto) ;

        }

        /// <summary>
        /// Método para adicionar taxa na comanda
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemPedido"></param>
        /// <returns></returns>
        [HttpPut("{id}/Taxa")]
        public Comanda PutTaxa(Guid id, [FromBody]ItemPedidoModel itemPedido)
        {
            return _comandaService.AdicionarItem(id, itemPedido, Domain.Enum.ETipoItem.Taxa);
        }

        [HttpPut("{id}/Pagar/{valor}")]
        public Comanda Put(Guid id, decimal valor)
        {
            return _comandaService.EfetuarPagamento(id, valor);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            return _comandaRepository.Delete(id);
        }
    }
}
