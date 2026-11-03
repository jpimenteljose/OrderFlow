using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFlow.Infrastructure.Mappings
{
    public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("ITEMPEDIDO");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();

            builder.Property(i => i.PedidoId)
                .HasColumnName("PEDIDOID")
                .IsRequired();

            builder.Property(i => i.Produto)
                .HasColumnName("PRODUTO")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(i => i.Quantidade)
            .HasColumnName("QUANTIDADE")
            .IsRequired();

            builder.Property(i => i.PrecoUnitario)
            .HasColumnName("PRECOUNITARIO")
            .HasColumnType("decimal(10,2)")
            .IsRequired();

            // propriedades que retornam cálculo
            builder.Ignore(i => i.Subtotal);
        }
    }
}
