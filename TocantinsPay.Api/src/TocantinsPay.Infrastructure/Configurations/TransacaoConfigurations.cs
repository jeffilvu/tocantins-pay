using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TocantinsPay.Core.Entities;

namespace TocantinsPay.Infrastructure.Configurations
{
    public class TransacaoConfigurations : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> entity)
        {
            entity.HasKey(e => e.Id).HasName("transacao_pkey");

            entity.ToTable("transacao");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CarteiraId).HasColumnName("carteira_id");
            entity.Property(e => e.CofrinhoId).HasColumnName("cofrinho_id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Descricao)
                .HasMaxLength(150)
                .HasColumnName("descricao");
            entity.Property(e => e.SaldoResultante)
                .HasPrecision(15, 2)
                .HasColumnName("saldo_resultante");
            entity.Property(e => e.Tipo).HasColumnName("tipo");
            entity.Property(e => e.Valor)
                .HasPrecision(15, 2)
                .HasColumnName("valor");
        }
    }
}
