using OrderFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFlow.Application.DTOs
{
    public class PedidoRequest
    {
        public string Cliente { get; set; } = string.Empty;
        public decimal PercentualDesconto { get; set; }
        public List<ItemPedidoRequest> Itens { get; set; } = new();
    }

    public class ItemPedidoRequest
    {
        public string Produto {  get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
