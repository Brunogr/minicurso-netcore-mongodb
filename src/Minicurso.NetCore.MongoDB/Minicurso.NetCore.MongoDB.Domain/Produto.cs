using Minicurso.NetCore.MongoDB.Domain.Base;
using Minicurso.NetCore.MongoDB.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Domain
{
    public class Produto : Entidade, IItem
    {
        public Produto(string nome, decimal valor, bool prepararCozinha)
        {
            Nome = nome;
            Valor = valor;
            PrepararCozinha = prepararCozinha;

            if (prepararCozinha)
                Status = EStatusPedido.FilaEspera;
        }

        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public bool PrepararCozinha { get; set; }
        public EStatusPedido Status { get; set; }
    }

    public enum EStatusPedido
    {
        Finalizado = 0,
        FilaEspera = 1,
        EmPreparo = 2
    }
}
