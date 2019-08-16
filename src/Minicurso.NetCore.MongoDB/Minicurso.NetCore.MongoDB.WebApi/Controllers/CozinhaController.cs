using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minicurso.NetCore.MongoDB.Application.Interface;
using Minicurso.NetCore.MongoDB.Application.ViewModels;
using Minicurso.NetCore.MongoDB.Domain;
using Minicurso.NetCore.MongoDB.Infra.Data.Interfaces;

namespace Minicurso.NetCore.MongoDB.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class CozinhaController : Controller
    {
        public ICozinhaService _cozinhaService;
        public ICozinhaRepository _cozinhaRepository;

        public CozinhaController(ICozinhaService cozinhaService, ICozinhaRepository cozinhaRepository)
        {
            _cozinhaService = cozinhaService;
            _cozinhaRepository = cozinhaRepository;
        }

        [HttpGet]
        public List<ItemCozinha> Get()
        {
            return _cozinhaRepository.GetAll();
        }

        //[HttpGet]
        //public ItemCozinha Get(Guid id)
        //{
        //    return _cozinhaRepository.Get(id);
        //}

        [HttpPost("atualizarCozinha")]
        public List<ItemCozinha> Post()
        {
            return _cozinhaService.AtualizarCozinha();
        }

        [HttpPut("{id}/IniciarPreparo")]
        public ItemCozinha PutIniciarPreparo(Guid id)
        {
            return _cozinhaService.IniciarPreparo(id);
        }

        [HttpPut("{id}/FinalizarPreparo")]
        public ItemCozinha PutFinalizarPreparo(Guid id)
        {
            return _cozinhaService.FinalizarPreparo(id);
        }

    }
}