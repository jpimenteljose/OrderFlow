using OrderFlow.Domain.Entities;
using OrderFlow.Domain.Interfaces;
using OrderFlow.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFlow.Infrastructure.Repositories
{
    public class ItemPedidoRepository (DataContext _dataContext)
        : BaseRepository<ItemPedido, Guid> (_dataContext), IItemPedidoRepository
    {
    }
}

