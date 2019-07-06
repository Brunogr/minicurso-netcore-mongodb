using Minicurso.NetCore.MongoDB.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minicurso.NetCore.MongoDB.Domain
{
    public class Comanda : Entidade
    {
        protected Comanda()
        {

        }

        public Comanda(int mesa, Atendente atendente)
        {
            Mesa = mesa;
            Atendente = atendente;
            DataAbertura = DateTime.Now;
            Ativo = true;
            DataFechamento = null;
            Pedidos = new List<ItemPedido>();
        }

        public int Mesa { get; private set; }
        public Atendente Atendente { get; private set; }
        public DateTime DataAbertura { get; private set; }
        public DateTime? DataFechamento { get; private set; }
        public List<ItemPedido> Pedidos { get; private set; }
        public bool Ativo { get; private set; }
        public decimal ValorTotal
        {
            get
            {
                decimal total = 0;

                if (Pedidos != null)
                    total = Math.Round(Pedidos.Sum(p => p.Valor),2);

                return total;
            }
        }

        public decimal ValorPago { get; private set; }

        public void AdicionarItem(ItemPedido item)
        {
            if (!Ativo)
                throw new Exception("O pedido já foi fechado!");

            var pedido = Pedidos.FirstOrDefault(p => p.Produto.Nome == item.Produto.Nome);

            if (pedido != null)
                pedido.Quantidade += item.Quantidade;
            else
                Pedidos.Add(item);
        }

        public void RemoverItem(ItemPedido item)
        {
            if (!Ativo)
                throw new Exception("O pedido já foi fechado!");

            var pedido = Pedidos.FirstOrDefault(p => p.Produto.Nome == item.Produto.Nome);

            if (pedido != null)
                pedido.Quantidade -= item.Quantidade;
            else
                Pedidos.Remove(item);
        }

        public void EfetuarPagamento(decimal valor)
        {
            if (!Ativo)
                throw new Exception("Não é possível efetuar pagamento em comanda inativa");

            ValorPago += valor;

            if (ValorPago >= ValorTotal)
                Fechar();
        }

        public void Fechar()
        {
            if (!Ativo && ValorTotal >= ValorPago)
                throw new Exception("Não é possivel fechar a conta");

            Ativo = false;
            DataFechamento = DateTime.Now;
        }        
    }
}
