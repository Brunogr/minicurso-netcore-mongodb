using Minicurso.NetCore.MongoDB.Domain;
using Minicurso.NetCore.MongoDB.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Application.ViewModels
{
    public class ItemPedidoModel
    {
        public int quantidade;
        public Produto item;
        public bool prepararCozinha;
        public Tipo tipo;
        public enum Tipo
        {
            Produto = 1,
            Desconto = 2,
            Taxa = 3
        }
    }
}
