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
        public Item item;
        public bool prepararCozinha;
        public bool porcentagem;

        public class Item
        {
            public string nome;
            public decimal valor;
        }
    }
}
