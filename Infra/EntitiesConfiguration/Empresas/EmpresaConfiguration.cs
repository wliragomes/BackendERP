using Domain.Entities;
using Domain.Entities.Vendas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("TB_EMPRESA");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_EMPRESA")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.CpfCnpj)
               .HasColumnName("CD_CNPJ_CPF");

            builder.Property(p => p.InscricaoEstadual)
               .HasColumnName("CD_INSCRICAO_ESTADUAL");

            builder.Property(p => p.InscricaoSuframa)
               .HasColumnName("CD_INSCRICAO_SUFRAMA");

            builder.Property(p => p.RazaoSocial)
               .HasColumnName("NM_RAZAO_SOCIAL");

            builder.Property(p => p.NomeFantasia)
               .HasColumnName("NM_FANTASIA");

            builder.Property(p => p.IdRegimeTributario)
               .HasColumnName("CD_REGIME_TRIBUTARIO");

            builder.Property(p => p.IdEndereco)
               .HasColumnName("CD_ENDERECO");

            builder.Property(p => p.IdEmail)
               .HasColumnName("CD_EMAIL");

            builder.Property(p => p.IdTelefone)
               .HasColumnName("CD_TELEFONE");

            builder.HasOne(p => p.Endereco)
                .WithOne(c => c.Empresa)
                .HasForeignKey<Empresa>(p => p.IdEndereco);

            builder.HasOne(p => p.Email)
                .WithOne(c => c.Empresa)
                .HasForeignKey<Empresa>(p => p.IdEmail);

            builder.HasOne(p => p.Telefone)
                .WithOne(c => c.Empresa)
                .HasForeignKey<Empresa>(p => p.IdTelefone);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
