using Minicurso.NetCore.MongoDB.Application.ViewModels;
using Minicurso.NetCore.MongoDB.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Application.Interface
{
    public interface IComandaSerive
    {
        Comanda CriarComanda(CriarComandaModel viewModel);

        Comanda AdicionarItem(Guid id, ItemPedidoModel viewModel);

        Comanda EfetuarPagamento(Guid id, decimal valor);
    }
}
