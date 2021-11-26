using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Padaria_Bread.Models.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padaria_Bread.Models.Mapeamento
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).ValueGeneratedOnAdd();
            builder.Property(p => p.id_cliente).IsRequired();
            builder
                .HasOne(p => p.cliente)
                .WithMany(p => p.vendas)
                .HasForeignKey(p => p.id_cliente)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(p => p.id_produto).IsRequired();
            builder
                .HasOne(p => p.produto)
                .WithMany(p => p.vendas)
                .HasForeignKey(p => p.id_produto)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(p => p.quantidade).HasColumnType("int").IsRequired();
            builder.Property(p => p.valorProduto).HasColumnType("decimal").IsRequired();
            builder.Property(p => p.valorVenda).HasColumnType("decimal").IsRequired();

            builder.ToTable("Venda");
        }
    }
}