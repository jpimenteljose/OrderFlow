using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFlow.Infrastructure.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("PEDIDO");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();

            builder.Property(p => p.Cliente)
                .HasColumnName("CLIENTE")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.DataCriacao)
                .HasColumnName("DATACRIACAO")
                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnName("STATUS")
                .IsRequired();

            builder.Property(p => p.PercentualDesconto)
                .HasColumnName("PERCENTUALDESCONTO")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            // relacionamento UM para MUITOS
            builder.HasMany(p => p.Itens) // pedido TEM MUITOS itens       
                .WithOne() // cada item TEM UM pedido
                .HasForeignKey(i => i.PedidoId); // chave estrangeira

            // propriedades que geram cálculo
            builder.Ignore(p => p.Subtotal);
            builder.Ignore(p => p.ValorDesconto);
            builder.Ignore(p => p.ValorTotal);

            // propriedade de navegação (Pedido -> Itens)
            builder.Navigation(p => p.Itens)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }   
}
