﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Padaria_Bread.Models;

namespace Padaria_Bread.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Padaria_Bread.Models.Dominio.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("complemento")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("data_nascimento")
                        .HasColumnType("date");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numero")
                        .HasColumnType("int");

                    b.Property<string>("rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Padaria_Bread.Models.Dominio.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("estoque")
                        .HasColumnType("int");

                    b.Property<decimal>("preco")
                        .HasColumnType("decimal(38,17)");

                    b.HasKey("id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Padaria_Bread.Models.Dominio.Venda", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_cliente")
                        .HasColumnType("int");

                    b.Property<int>("id_produto")
                        .HasColumnType("int");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("valorProduto")
                        .HasColumnType("decimal(38,17)");

                    b.Property<decimal>("valorVenda")
                        .HasColumnType("decimal(38,17)");

                    b.HasKey("id");

                    b.HasIndex("id_cliente");

                    b.HasIndex("id_produto");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("Padaria_Bread.Models.Dominio.Venda", b =>
                {
                    b.HasOne("Padaria_Bread.Models.Dominio.Cliente", "cliente")
                        .WithMany("vendas")
                        .HasForeignKey("id_cliente")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Padaria_Bread.Models.Dominio.Produto", "produto")
                        .WithMany("vendas")
                        .HasForeignKey("id_produto")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("cliente");

                    b.Navigation("produto");
                });

            modelBuilder.Entity("Padaria_Bread.Models.Dominio.Cliente", b =>
                {
                    b.Navigation("vendas");
                });

            modelBuilder.Entity("Padaria_Bread.Models.Dominio.Produto", b =>
                {
                    b.Navigation("vendas");
                });
#pragma warning restore 612, 618
        }
    }
}
