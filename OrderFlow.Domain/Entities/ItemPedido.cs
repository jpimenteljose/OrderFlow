using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFlow.Domain.Entities
{
    public class ItemPedido
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public Guid PedidoId { get; private set; }
        
        public string Produto { get; private set; } = string.Empty;

        public int Quantidade { get; private set; } = 0;

        public decimal PrecoUnitario { get; private set; } = 0m;

        public decimal Subtotal => Quantidade * PrecoUnitario;

        public ItemPedido(Guid pedidoId, string produto, int quantidade, decimal precoUnitario)
        {
            if (string.IsNullOrWhiteSpace(produto))
                throw new ArgumentException("O produto deve ser informado.");

            if (quantidade < 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");

            if (precoUnitario <= 0)
                throw new ArgumentException("O preço unitário deve ser maior que zero.");

            PedidoId = pedidoId;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }
    }
}
