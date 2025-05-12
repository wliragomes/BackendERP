using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class ContaAPagarPagoConfiguration : IEntityTypeConfiguration<ContaAPagarPago>
    {
        public void Configure(EntityTypeBuilder<ContaAPagarPago> builder)
        {
            builder.ToTable("TB_CONTA_PAGAR_PAGO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CONTA_PAGAR_PAGO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IdContaAPagar)
               .HasColumnName("CD_CONTA_PAGAR");

            builder.Property(p => p.NItem)
               .HasColumnName("NR_ITEM");

            builder.Property(p => p.Baixa)
               .HasColumnName("DT_BAIXA");

            builder.Property(p => p.IdBanco)
               .HasColumnName("CD_BANCO");

            builder.Property(p => p.Agencia)
               .HasColumnName("NR_AGENCIA");

            builder.Property(p => p.AgenciaDigito)
               .HasColumnName("NR_AGENCIA_DIGITO");

            builder.Property(p => p.Conta)
               .HasColumnName("NR_CONTA");

            builder.Property(p => p.ContaDigito)
               .HasColumnName("NR_CONTA_DIGITO");

            builder.Property(p => p.ValorPago)
               .HasColumnName("VL_PAGO");

            builder.Property(p => p.DataOperacao)
               .HasColumnName("DT_OPERACAO");

            builder.Property(p => p.Historico)
               .HasColumnName("TX_HISTORICO");

            builder.Property(p => p.NDocumentoPago)
               .HasColumnName("NR_DOCUMENTO_PAGO");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
