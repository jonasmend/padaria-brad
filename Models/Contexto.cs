using Microsoft.EntityFrameworkCore;
using Padaria_Bread.Models.Dominio;
using Padaria_Bread.Models.Mapeamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padaria_Bread.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Cliente> Pacientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClienteMap());
            builder.ApplyConfiguration(new ProdutoMap());
            builder.ApplyConfiguration(new VendaMap());
        }

        public DbSet<Padaria_Bread.Models.Consultas.TotalCompras> TotalCompras { get; set; }
    }
}
