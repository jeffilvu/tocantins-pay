using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TocantinsPay.Core.Entities;

namespace TocantinsPay.Infrastructure
{
    public class TocantinsPayContext(DbContextOptions options) : DbContext(options)
    {
        public virtual DbSet<Carteira> Carteiras { get; set; }

        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<Cofrinho> Cofrinhos { get; set; }

        public virtual DbSet<Endereco> Enderecos { get; set; }

        public virtual DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
