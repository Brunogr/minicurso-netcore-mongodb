using Minicurso.NetCore.MongoDB.Application.ViewModels;
using Minicurso.NetCore.MongoDB.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Application.Interface
{
    public interface ICozinhaService
    {
        ItemCozinha IniciarPreparo(Guid id);
        ItemCozinha FinalizarPreparo(Guid id);
        List<ItemCozinha> AtualizarCozinha();
    }
}
