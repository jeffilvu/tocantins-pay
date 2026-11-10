using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TocantinsPay.Core.Entities;

namespace TocantinsPay.Infrastructure.Configurations
{
    public class CofrinhoConfigurations : IEntityTypeConfiguration<Cofrinho>
    {
        public void Configure(EntityTypeBuilder<Cofrinho> entity)
        {
            entity.HasKey(e => e.Id).HasName("cofrinho_pkey");

            entity.ToTable("cofrinho");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CarteiraId).HasColumnName("carteira_id");
            entity.Property(e => e.Meta)
                .HasPrecision(15, 2)
                .HasColumnName("meta");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Saldo)
                .HasPrecision(15, 2)
                .HasColumnName("saldo");
        }
    }
}
