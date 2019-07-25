using Minicurso.NetCore.MongoDB.Application.ViewModels;
using Minicurso.NetCore.MongoDB.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Application.Interface
{
    public interface IComandaService
    {
        Comanda CriarComanda(CriarComandaModel viewModel);

        Comanda AdicionarProduto(Guid id, ItemPedidoModel viewModel);
        Comanda AdicionarDesconto(Guid id, ItemPedidoModel viewModel);
        Comanda AdicionarTaxa(Guid id, ItemPedidoModel viewModel);
        Comanda EfetuarPagamento(Guid id, decimal valor);
        Comanda IniciarPreparoCozinha(Guid id, Guid cozinhaId);
        Comanda FinalizarPreparoCozinha(Guid id, Guid cozinhaId);
        List<ItemCozinha> GetCozinha();
    }
}
