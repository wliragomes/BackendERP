using Domain.Entities;
using Domain.Entities.VendasItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.VendasItem
{
    public class VendaItemConfiguration : IEntityTypeConfiguration<VendaItem>
    {
        public void Configure(EntityTypeBuilder<VendaItem> builder)
        {
            builder.ToTable("TB_VENDA_ITEM");
            builder.HasKey(rpe => new { rpe.IdVenda, rpe.SequenciaItem });

            builder.Property(vi => vi.IdVenda)
                .HasColumnName("CD_VENDA")
                .IsRequired();

            builder.Property(vi => vi.SequenciaItem)
                .HasColumnName("SQ_VENDA_ITEM");

            builder.Property(vi => vi.IdProduto)
                .HasColumnName("CD_PRODUTO");

            builder.Property(vi => vi.DescricaoProduto)
                .HasColumnName("DS_PRODUTO")
                .HasMaxLength(500);

            builder.Property(vi => vi.InformacoesAdicionais)
                .HasColumnName("TX_PRODUTO_ADICIONAL")
                .HasMaxLength(500);

            builder.Property(vi => vi.Jumbo)
                .HasColumnName("FL_JUMBO");

            builder.Property(vi => vi.DescricaoPedidoCliente)
                .HasColumnName("DS_X_PED")
                .HasMaxLength(30);

            builder.Property(vi => vi.NumeroItemPedidoCliente)
                .HasColumnName("DS_N_PED_ITEM")
                .HasMaxLength(30);

            builder.Property(vi => vi.NumeroFci)
                .HasColumnName("NR_FCI")
                .HasMaxLength(10);

            builder.Property(vi => vi.ValorFci)
                .HasColumnName("VL_FCI")
                .HasColumnType("decimal(18,2)");

            builder.Property(vi => vi.IdUnidadeMedida)
                .HasColumnName("CD_UNIDADE_MEDIDA");

            builder.Property(vi => vi.Quantidade)
                .HasColumnName("QT_PRODUTO")
                .HasColumnType("decimal(18,4)");

            builder.Property(vi => vi.ValorUnitario)
                .HasColumnName("VL_PRODUTO")
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.ValorTotal)
               .HasColumnName("VL_TOTAL_PRODUTO");

            builder.Property(v => v.IdCFOP)
                .HasColumnName("CD_CFOP");

            builder.Property(p => p.IdNCM)
               .HasColumnName("CD_NCM");

            builder.Property(vi => vi.IvaProduto)
                .HasColumnName("PR_IVA")
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.AliquotaICMS)
               .HasColumnName("PR_ICMS");

            builder.Property(p => p.BaseCalculoICMS)
              .HasColumnName("VL_BASE_CALCULO_ICMS");

            builder.Property(p => p.ValorICMS)
               .HasColumnName("VL_ICMS");

            builder.Property(p => p.AliquotaIPI)
               .HasColumnName("PR_IPI");

            builder.Property(p => p.ValorIPI)
               .HasColumnName("VL_IPI");

            builder.Property(p => p.BaseCalculoST)
               .HasColumnName("VL_BASE_CALCULO_ST");

            builder.Property(p => p.AliquotaST)
               .HasColumnName("VL_ALIQUOTA_ST");

            builder.Property(p => p.ValorST)
               .HasColumnName("VL_ST");

            //Relationships
            builder.HasOne(vi => vi.Venda)
                .WithMany(v => v.VendaItem)
                .HasForeignKey(vi => vi.IdVenda);

            builder.HasOne(vi => vi.Produto)
                .WithMany()
                .HasForeignKey(vi => vi.IdProduto);

            builder.HasOne(vi => vi.UnidadeMedida)
                .WithMany()
                .HasForeignKey(vi => vi.IdUnidadeMedida);

            //builder.HasOne(p => p.Produto)
            //    .WithOne(c => c.VendaItem)
            //    .HasForeignKey<VendaItem>(p => p.IdProduto);

            builder.HasOne(vi => vi.Produto)
                .WithMany(p => p.VendaItem)// se quiser navegar de Produto para os itens
                .HasForeignKey(vi => vi.IdProduto);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
