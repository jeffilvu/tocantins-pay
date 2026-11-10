using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TocantinsPay.Core.Entities;

namespace TocantinsPay.Infrastructure.Configurations
{
    public class EnderecoConfigurations : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> entity)
        {
            entity.HasKey(e => e.Id).HasName("endereco_pkey");

            entity.ToTable("endereco");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(100)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(9)
                .IsFixedLength()
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .HasColumnName("cidade");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Logradouro)
                .HasMaxLength(200)
                .HasColumnName("logradouro");
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("uf");
        }
    }
}
