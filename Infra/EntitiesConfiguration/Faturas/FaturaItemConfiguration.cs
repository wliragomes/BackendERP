using Domain.Entities.Faturas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Faturas
{
    public class FaturaItemConfiguration : IEntityTypeConfiguration<FaturaItem>
    {
        public void Configure(EntityTypeBuilder<FaturaItem> builder)
        {
            builder.ToTable("TB_FATURA_ITEM");

            // Chave primária
            builder.HasKey(f => new { f.IdFatura, f.SequenciaItem }); //IdFatura, SequenciaItem

            // Propriedades
            builder.Property(f => f.IdFatura)
                .HasColumnName("CD_FATURA");

            builder.Property(p => p.SequenciaItem)
               .HasColumnName("SQ_ITEM");

            builder.Property(p => p.DescricaoPedidoCliente)
               .HasColumnName("DS_X_PED");

            builder.Property(p => p.NumeroItemPedidoCliente)
               .HasColumnName("DS_N_PED_ITEM");

            builder.Property(p => p.IdProduto)
               .HasColumnName("CD_PRODUTO");

            builder.Property(p => p.DescricaoProduto)
               .HasColumnName("DS_PROPDUTO");

            builder.Property(p => p.IdUnidadeMedida)
               .HasColumnName("CD_UNIDADE_MEDIDA");

            builder.Property(p => p.InformacoesAdicionais)
               .HasColumnName("DS_INFORMACOES_ADICIONAIS");

            builder.Property(p => p.NumeroFCI)
               .HasColumnName("NR_FCI");

            builder.Property(p => p.ValorFCI)
               .HasColumnName("VL_FCI");

            builder.Property(p => p.Quantidade)
               .HasColumnName("QT_PRODUTO");

            builder.Property(p => p.ValorUnitario)
               .HasColumnName("VL_UNITARIO");

            builder.Property(p => p.PercentualDesconto)
               .HasColumnName("VL_PERCENTUAL_DESCONTO");

            builder.Property(p => p.ValorDesconto)
               .HasColumnName("VL_DESCONTO");

            builder.Property(p => p.ValorTotal)
               .HasColumnName("VL_TOTAL");

            builder.Property(p => p.IdCFOP)
               .HasColumnName("CD_CFOP");

            builder.Property(p => p.IdNCM)
               .HasColumnName("CD_NCM");

            builder.Property(p => p.AliquotaICMS)
               .HasColumnName("VL_ALIQUOTA_ICMS");

            builder.Property(p => p.BaseCalculoICMS)
               .HasColumnName("VL_BASE_CALCULO_ICMS");

            builder.Property(p => p.ValorICMS)
               .HasColumnName("VL_ICMS");

            builder.Property(p => p.AliquotaIPI)
               .HasColumnName("VL_ALIQUOTA_IPI");

            builder.Property(p => p.ValorIPI)
               .HasColumnName("VL_IPI");

            builder.Property(p => p.AliquotaST)
               .HasColumnName("VL_ALIQUOTA_ST");

            builder.Property(p => p.BaseCalculoST)
               .HasColumnName("VL_BASE_CALCULO_ST");

            builder.Property(p => p.ValorST)
               .HasColumnName("VL_ST");

            builder.Property(p => p.BaseCalculoPisCofins)
               .HasColumnName("VL_BASE_CALCULO_PIS_COFINS");

            builder.Property(p => p.AliquotaPis)
               .HasColumnName("VL_ALIQUOTA_PIS");

            builder.Property(p => p.ValorPis)
               .HasColumnName("VL_PIS");

            builder.Property(p => p.AliquotaCofins)
               .HasColumnName("VL_ALIQUOTA_COFINS");

            builder.Property(p => p.ValorCofins)
               .HasColumnName("VL_COFINS");

            builder.HasOne(f => f.Fatura)
                .WithMany(f => f.FaturaItem)
                .HasForeignKey(f => f.IdFatura)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(vi => vi.Produto)
                .WithMany()
                .HasForeignKey(vi => vi.IdProduto);

            builder.HasQueryFilter(e => !e.Removed);
        }
    }
}
