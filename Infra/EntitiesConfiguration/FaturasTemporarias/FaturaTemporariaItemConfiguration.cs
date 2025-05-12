using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class FaturaTemporariaItemConfiguration : IEntityTypeConfiguration<FaturaTemporariaItem>
    {
        public void Configure(EntityTypeBuilder<FaturaTemporariaItem> builder)
        {
            builder.ToTable("TB_TMP_FATURA_ITEM");

            builder.HasKey(p => new { p.IdFaturaTemporaria, p.SqItem });

            // Propriedades
            builder.Property(p => p.IdFaturaTemporaria)
                .HasColumnName("CD_CODIGO")
                .IsRequired();

            builder.Property(p => p.SqItem)
                .HasColumnName("SQ_ITEM")
                .IsRequired();

            builder.Property(p => p.IdProduto)
                .HasColumnName("CD_PRODUTO");

            builder.Property(p => p.QtdProduto)
                .HasColumnName("QT_PRODUTO");

            builder.Property(p => p.ValorUnitarioProduto)
                .HasColumnName("VL_UNITARIO_PRODUTO");

            builder.Property(p => p.ValorTotalProduto)
                .HasColumnName("VL_TOTAL_PRODUTO");

            builder.Property(p => p.IdCfop)
                .HasColumnName("CD_CFOP");

            builder.Property(p => p.ValorFrete)
                .HasColumnName("VL_FRETE");

            builder.Property(p => p.ValorSeguro)
                .HasColumnName("VL_SEGURO");

            builder.Property(p => p.ValorOutrasDespesas)
                .HasColumnName("VL_OUTRAS_DESPESAS");

            builder.Property(p => p.PrIcms)
                .HasColumnName("PR_ICMS");

            builder.Property(p => p.ValorIcms)
                .HasColumnName("VL_ICMS");

            builder.Property(p => p.PrIpi)
                .HasColumnName("PR_IPI");

            builder.Property(p => p.ValorIpi)
                .HasColumnName("VL_IPI");

            builder.Property(p => p.PrPis)
                .HasColumnName("PR_PIS");

            builder.Property(p => p.ValorPis)
                .HasColumnName("VL_PIS");

            builder.Property(p => p.PrCofinss)
                .HasColumnName("PR_COFINS");

            builder.Property(p => p.ValorCofins)
                .HasColumnName("VL_COFINS");

            builder.Property(p => p.PrIva)
                .HasColumnName("PR_IVA");

            builder.Property(p => p.BaseCalculoSt)
                .HasColumnName("VL_BASE_CALCULO_ST");

            builder.Property(p => p.ValorSt)
                .HasColumnName("VL_ST");

            builder.Property(p => p.ValorNetPrice)
                .HasColumnName("VL_NET_PRICE");

            builder.Property(p => p.ValorGrossPrice)
                .HasColumnName("VL_GROSS_PRICE");

            builder.HasOne(p => p.FaturaTemporaria)
                .WithMany(c => c.FaturaTemporariaItem)
                .HasForeignKey(p => p.IdFaturaTemporaria);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
