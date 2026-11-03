using OrderFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFlow.Application.DTOs
{
    public class PedidoResponse
    {
        public Guid Id { get; set; }

        public string Cliente { get; set; } = string.Empty;

        public DateTime DataCriacao { get; set; }
        
        public StatusPedido Status {  get; set; }

        public decimal Subtotal { get; set; }

        public decimal PercentualDesconto { get; set; }

        public decimal ValorDesconto { get; set; }

        public decimal ValorTotal { get; set; }

        public List<ItemPedidoResponse> Itens { get; set; } = new();
    }

    public class ItemPedidoResponse
    {
        public Guid Id { get; set;}

        public string Produto { get; set; } = string.Empty;

        public int Quantidade { get; set; }

        public decimal PrecoUnitario { get; set; }

        public decimal Subtotal { get; set; }

    }
}
