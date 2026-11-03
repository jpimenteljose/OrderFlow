using OrderFlow.Application.DTOs;
using OrderFlow.Application.Interfaces;
using OrderFlow.Domain.Entities;
using OrderFlow.Domain.Interfaces;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;

namespace OrderFlow.Application.Services
{
    public class PedidoService (IUnitOfWork _unitOfWork) : IPedidoService
    {
        public async Task<PedidoResponse> CriarAsync(PedidoRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            if (string.IsNullOrWhiteSpace(request.Cliente))
                throw new ArgumentException("Informe o nome do cliente.");

            if (request.Itens == null || request.Itens.Count == 0)
                throw new ArgumentException("O pedido deve possuir pelo menos um item.");

            if (request.Itens.Any(item => item is null))
                throw new ArgumentException("Os itens do pedido não podem ser nulos.");

            // 1. criar a entidade pedido
            var pedido = new Pedido(request.Cliente.Trim());

            // 2. adicionar os itens do pedido
            foreach(var item in request.Itens)
            {
                pedido.AdicionarItem(
                    item.Produto,
                    item.Quantidade,
                    item.PrecoUnitario
                    );
            }

            // 3. aplicar o desconto
            pedido.AplicarDesconto(request.PercentualDesconto);

            // 4. gravar pedido e itens no banco
            await _unitOfWork.PedidoRepository.AddAsync(pedido);

            // 5. confirmar a transação
            await _unitOfWork.SaveChangesAsync();

            // 6. retornar DTO com os cálculos
            return new PedidoResponse
            {
                Id = pedido.Id,
                Cliente = pedido.Cliente,
                DataCriacao = pedido.DataCriacao,
                Status = pedido.Status,

                Subtotal = pedido.Subtotal,
                PercentualDesconto = pedido.PercentualDesconto,
                ValorDesconto = pedido.ValorDesconto,
                ValorTotal = pedido.ValorTotal,

                Itens = pedido.Itens.Select(item =>
                     new ItemPedidoResponse
                     {
                         Id = item.Id,
                         Produto = item.Produto,
                         Quantidade = item.Quantidade,
                         PrecoUnitario = item.PrecoUnitario,
                         Subtotal = item.Subtotal
                     }).ToList()
            };
        }
    }
}
