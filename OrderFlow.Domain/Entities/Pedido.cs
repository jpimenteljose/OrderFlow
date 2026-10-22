using OrderFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFlow.Domain.Entities
{
    public class Pedido
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Cliente { get; private set; } = string.Empty;

        public DateTime DataCriacao { get; private set; } = DateTime.Now;

        public StatusPedido Status {  get; private set; }

        public decimal PercentualDesconto { get; private set; } = 0;

        private readonly List<ItemPedido> _itens = new();

        public IReadOnlyCollection<ItemPedido> Itens => _itens.AsReadOnly();

        public decimal Subtotal => _itens.Sum(item => item.Subtotal);

        public decimal ValorDesconto => Subtotal * PercentualDesconto / 100;

        public decimal ValorTotal => Subtotal - ValorDesconto;

        public Pedido(string cliente)
        {
            Cliente= cliente;
            Status = StatusPedido.Criado;
        }

        public void AdicionarItem(string produto, int quantidade, decimal precoUnitario)
        {
            if (Status != StatusPedido.Criado)
                throw new InvalidOperationException("Somente produtos criados podem receber itens.");

            var item = new ItemPedido(Id, produto, quantidade, precoUnitario);

            _itens.Add(item);
        }

        public void AplicarDesconto(decimal percentual)
        {
            if (Status != StatusPedido.Criado)
                throw new InvalidOperationException("Não é possível alterar este pedido.");

            if (percentual < 0 || percentual > 20)
                throw new InvalidOperationException("O desconto deve estar entre 0% e 20%.");
        }

        public void Confirmar()
        {
            if (Status != StatusPedido.Criado)
                throw new InvalidOperationException("Somente produtos criados podem ser confirmados.");

            if (! _itens.Any())
                throw new InvalidOperationException("Não é possível confirmar um pedido sem ítens.");

            Status = StatusPedido.Confirmado;
        }

        public void Cancelar()
        {
            if (Status != StatusPedido.Cancelado)
                throw new InvalidOperationException("O pedido já está cancelado.");

            Status = StatusPedido.Cancelado;

        }
    }
}
