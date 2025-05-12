using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class ContaBancariaConfiguration : IEntityTypeConfiguration<ContaBancaria>
    {
        public void Configure(EntityTypeBuilder<ContaBancaria> builder)
        {
            builder.ToTable("TB_CONTA_BANCARIA");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CONTA_BANCARIA")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_CONTA_BANCARIA");

            builder.Property(p => p.IdBanco)
               .HasColumnName("CD_BANCO");

            builder.Property(p => p.Agencia)
               .HasColumnName("NR_AGENCIA");

            builder.Property(p => p.DigitoAgencia)
               .HasColumnName("NR_AGENCIA_DIGITO");

            builder.Property(p => p.Conta)
               .HasColumnName("NR_CONTA");

            builder.Property(p => p.DigitoConta)
               .HasColumnName("NR_CONTA_DIGITO");

            builder.Property(p => p.LimiteEspecial)
               .HasColumnName("FL_LIMITE_ESPECIAL");

            builder.Property(p => p.ValorLimiteEspecial)
               .HasColumnName("VL_LIMITE_ESPECIAL");

            builder.Property(p => p.ContaGarantida)
               .HasColumnName("FL_CONTA_GARANTIDA");

            builder.Property(p => p.ValorContaGarantida)
               .HasColumnName("VL_CONTA_GARANTIDA");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
