using Minicurso.NetCore.MongoDB.Application.ViewModels;
using Minicurso.NetCore.MongoDB.Domain;
using Minicurso.NetCore.MongoDB.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Application.Interface
{
    public interface IComandaService
    {
        Comanda CriarComanda(CriarComandaModel viewModel);
        Comanda AdicionarItem(Guid id, ItemPedidoModel itemPedidoModel, ETipoItem tipoItem);
        Comanda EfetuarPagamento(Guid id, decimal valor);
    }
}
