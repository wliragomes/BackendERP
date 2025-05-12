using Domain.Entities.Faturas;
using Domain.Entities.Vendas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class VendaRecebimentoTipoConfiguration : IEntityTypeConfiguration<VendaRecebimentoTipo>
{
    public void Configure(EntityTypeBuilder<VendaRecebimentoTipo> builder)
    {
        builder.ToTable("TB_VENDA_RECEBIMENTO_TIPO");

        builder.HasKey(v => v.Id);
        builder.HasIndex(v => v.Id).IsUnique();

        builder.Property(v => v.Id)
            .HasColumnName("CD_VENDA_RECEBIMENTO_TIPO")
            .IsRequired();

        builder.Property(p => p.QuantidadeParcela)
          .HasColumnName("QT_PARCELA");

        builder.Property(p => p.PagamentoAntecipado)
          .HasColumnName("FL_PAGAMENTO_ANTECIPADO");

        builder.Property(p => p.ParcelaPartir)
          .HasColumnName("FL_PARCELA_PARTIR");

        builder.Property(p => p.Periodo)
          .HasColumnName("FL_PERIODO");

        builder.Property(p => p.QuantidadeDias)
          .HasColumnName("QT_DIAS");

        // Relacionamento 1:1 com RelacionaFaturaVendaRecebimentoTipo
        builder.HasOne(v => v.RelacionaFaturaVendaRecebimentoTipo)
            .WithOne(r => r.VendaRecebimentoTipo)
            .HasForeignKey<RelacionaFaturaVendaRecebimentoTipo>(r => r.IdVendaRecebimentoTipo)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(p => !p.Removed);
    }
}