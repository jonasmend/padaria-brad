using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Padaria_Bread.Models.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padaria_Bread.Models.Mapeamento
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).ValueGeneratedOnAdd();
            builder.Property(p => p.nome).IsRequired();
            builder.Property(p => p.data_nascimento).HasColumnType("date").IsRequired();
            builder.Property(p => p.cpf).IsRequired();
            builder.Property(p => p.cep).IsRequired();
            builder.Property(p => p.rua).IsRequired();
            builder.Property(p => p.numero).HasColumnType("int").IsRequired();
            builder.Property(p => p.bairro).IsRequired();
            builder.Property(p => p.complemento).HasMaxLength(70);

            builder.ToTable("Cliente");
        }
    }
}
