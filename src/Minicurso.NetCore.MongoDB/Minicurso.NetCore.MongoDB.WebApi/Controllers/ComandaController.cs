using System;
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
        IComandaSerive _pedidoService;
        IComandaRepository _pedidoRepository;

        public ComandaController(IComandaSerive pedidoService, IComandaRepository pedidoRepository)
        {
            _pedidoService = pedidoService;
            _pedidoRepository = pedidoRepository;
        }

        /// <summary>
        /// Retorna todos os pedidos
        /// </summary>
        /// <returns>Lista de pedidos.</returns>
        [HttpGet]
        public List<Comanda> Get()
        {
            return _pedidoRepository.GetAll();
        }

        /// <summary>
        /// Retorna todos os pedidos ativos.
        /// </summary>
        /// <returns>Lista de pedidos ativos.</returns>
        [HttpGet("Mesa/{numeroMesa}")]
        public List<Comanda> GetAtivos(int numeroMesa)
        {
            return _pedidoRepository.GetByFilter(p => p.Mesa == numeroMesa && p.Ativo);
        }

        /// <summary>
        /// Retorna todos os pedidos fechados.
        /// </summary>
        /// <returns>Lista de pedidos fechados.</returns>
        [HttpGet("Mesa/{numeroMesa}/Fechado")]
        public List<Comanda> GetFechados(int numeroMesa)
        {
            return _pedidoRepository.GetByFilter(p => p.Mesa == numeroMesa && !p.Ativo);
        }

        /// <summary>
        /// Buscar um pedido pelo ID.
        /// </summary>
        /// <param name="id">Id do pedido.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Comanda Get(Guid id)
        {
            return _pedidoRepository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public Comanda Post([FromBody]CriarComandaModel value)
        {
            return _pedidoService.CriarComanda(value);
        }

        /// <summary>
        /// Método para adicionar um item ao pedido.
        /// </summary>
        /// <param name="id">Id do pedido.</param>
        /// <param name="item">Item a ser adicionado.</param>
        /// <returns></returns>
        [HttpPut("{id}/Item")]
        public Comanda Put(Guid id, [FromBody]ItemPedidoModel item)
        {
            return _pedidoService.AdicionarItem(id, item);
        }

        [HttpPut("{id}/Pagar/{valor}")]
        public Comanda Put(Guid id, decimal valor)
        {
            return _pedidoService.EfetuarPagamento(id, valor);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            return _pedidoRepository.Delete(id);
        }
    }
}
