using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class FaturaTemporariaConfiguration : IEntityTypeConfiguration<FaturaTemporaria>
    {
        public void Configure(EntityTypeBuilder<FaturaTemporaria> builder)
        {
            builder.ToTable("TB_TMP_FATURA");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CODIGO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IdEmpresa)
               .HasColumnName("CD_EMPRESA");

            builder.Property(p => p.IdPessoa)
               .HasColumnName("CD_PESSOA");

            //builder.Property(p => p.IdTipoConsumidor)
            //   .HasColumnName("CD_TIPO_CONSUMIDOR");

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

            builder.Property(p => p.ValorIpi)
               .HasColumnName("VL_IPI");

            builder.Property(p => p.ValorPis)
               .HasColumnName("VL_PIS");

            builder.Property(p => p.ValorCofins)
               .HasColumnName("VL_COFINS");

            builder.Property(p => p.BaseCalculoSt)
               .HasColumnName("VL_BASE_CALCULO_ST");

            builder.Property(p => p.ValorSt)
               .HasColumnName("VL_ST");

            builder.Property(p => p.ValorTotalProduto)
               .HasColumnName("VL_TOTAL_PRODUTO");

            builder.Property(p => p.ValorTotalNota)
               .HasColumnName("VL_TOTAL_NOTA");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
