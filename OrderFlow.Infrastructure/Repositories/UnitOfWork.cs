using OrderFlow.Domain.Interfaces;
using OrderFlow.Infrastructure.Contexts;
using OrderFlow.Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFlow.Infrastructure.Repositories
{
    public class UnitOfWork (DataContext _dataContext) : IUnitOfWork
    {
        public IPedidoRepository PedidoRepository => new PedidoRepository(_dataContext);

        public IItemPedidoRepository ItemPedidoRepository => new ItemPedidoRepository(_dataContext);

        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
