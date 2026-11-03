using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFlow.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IPedidoRepository PedidoRepository { get; }

        IItemPedidoRepository ItemPedidoRepository { get; }

        Task SaveChangesAsync();
    }
}
