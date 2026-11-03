using Microsoft.EntityFrameworkCore;
using OrderFlow.Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFlow.Infrastructure.Contexts
{
    public class DataContext : DbContext
    {
        // método construtor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new ItemPedidoMap());
        }
    }
}
