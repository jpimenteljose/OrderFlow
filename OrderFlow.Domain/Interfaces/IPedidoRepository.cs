using OrderFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFlow.Domain.Interfaces
{
    public interface IPedidoRepository : IBaseRepository<Pedido, Guid>
    {
    }
}
