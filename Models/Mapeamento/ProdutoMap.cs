using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Padaria_Bread.Models.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padaria_Bread.Models.Mapeamento
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).ValueGeneratedOnAdd();
            builder.Property(p => p.descricao).IsRequired();
            builder.Property(p => p.estoque).HasColumnType("int").IsRequired();
            builder.Property(p => p.preco).HasColumnType("decimal").IsRequired();

            builder.ToTable("Produto");
        }
    }
}
