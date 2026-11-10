using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TocantinsPay.Core.Entities;

namespace TocantinsPay.Infrastructure.Configurations
{
    public class CarteiraConfigurations : IEntityTypeConfiguration<Carteira>
    {
        public void Configure(EntityTypeBuilder<Carteira> entity)
        {
            entity.HasKey(e => e.Id).HasName("carteira_pkey");

            entity.ToTable("carteira");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Agencia)
                .HasMaxLength(10)
                .HasColumnName("agencia");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Conta)
                .HasMaxLength(50)
                .HasColumnName("conta");
            entity.Property(e => e.Saldo)
                .HasPrecision(15, 2)
                .HasColumnName("saldo");
        }
    }
}
