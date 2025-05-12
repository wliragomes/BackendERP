using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class ContaAReceberPagoConfiguration : IEntityTypeConfiguration<ContaAReceberPago>
    {
        public void Configure(EntityTypeBuilder<ContaAReceberPago> builder)
        {
            builder.ToTable("TB_CONTA_RECEBER_PAGO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CONTA_RECEBER_PAGO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IdContaAReceber)
               .HasColumnName("CD_CONTA_RECEBER");

            builder.Property(p => p.NItem)
               .HasColumnName("NR_ITEM");

            builder.Property(p => p.DataBaixa)
               .HasColumnName("DT_BAIXA");

            builder.Property(p => p.ValorDocumentoPago)
               .HasColumnName("VL_PAGO");

            builder.Property(p => p.Historico)
               .HasColumnName("TX_HISTORICO");

            builder.Property(p => p.NDocumento)
               .HasColumnName("NR_DOCUMENTO_PAGO");            

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
