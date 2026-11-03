using OrderFlow.Domain.Entities;
using OrderFlow.Domain.Interfaces;
using OrderFlow.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFlow.Infrastructure.Repositories
{
    public class PedidoRepository (DataContext _dataContext)
        : BaseRepository<Pedido, Guid> (_dataContext), IPedidoRepository
    {

    }
}
