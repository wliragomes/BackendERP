using Domain.Entities.Vendas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class VendaRecebimentoParcelaConfiguration : IEntityTypeConfiguration<VendaRecebimentoParcela>
{
    public void Configure(EntityTypeBuilder<VendaRecebimentoParcela> builder)
    {
        builder.ToTable("TB_VENDA_RECEBIMENTO_PARCELA");

        // Chave primária
        builder.HasKey(f => new { f.IdVendaRecebimentoTipo, f.SequenciaParcela });

        builder.Property(f => f.IdVendaRecebimentoTipo)
                 .HasColumnName("CD_VENDA_RECEBIMENTO_TIPO");

        builder.Property(p => p.SequenciaParcela)
              .HasColumnName("SQ_PARCELA");

        builder.Property(p => p.NumeroDiasVencimento)
              .HasColumnName("NR_DIAS_VENCIMENTO");

        builder.Property(p => p.DataVencimento)
              .HasColumnName("DT_VENCIMENTO");

        builder.Property(p => p.ValorParcela)
              .HasColumnName("VL_PARCELA");

        builder.HasOne(f => f.VendaRecebimentoTipo)
               .WithMany(f => f.VendaRecebimentoParcela)
               .HasForeignKey(f => f.IdVendaRecebimentoTipo)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(p => !p.Removed);
    }
}
