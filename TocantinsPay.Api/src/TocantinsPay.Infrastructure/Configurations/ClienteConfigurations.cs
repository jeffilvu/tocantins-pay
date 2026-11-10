using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TocantinsPay.Core.Entities;

namespace TocantinsPay.Infrastructure.Configurations
{
    public class ClienteConfigurations : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entity)
        {
            entity.HasKey(e => e.Id).HasName("cliente_pkey");

            entity.ToTable("cliente");

            entity.HasIndex(e => e.Cpf, "cliente_cpf_key").IsUnique();

            entity.HasIndex(e => e.Email, "cliente_email_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Cpf)
                .HasMaxLength(14)
                .HasColumnName("cpf");
            entity.Property(e => e.DataNascimento).HasColumnName("data_nascimento");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.NomeCompleto)
                .HasMaxLength(150)
                .HasColumnName("nome_completo");
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .HasColumnName("senha");
            entity.Property(e => e.Situacao).HasColumnName("situacao");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .HasColumnName("telefone");
        }
    }
}
