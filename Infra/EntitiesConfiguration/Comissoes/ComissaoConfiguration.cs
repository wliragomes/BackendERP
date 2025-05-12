using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class ComissaoConfiguration : IEntityTypeConfiguration<Comissao>
    {
        public void Configure(EntityTypeBuilder<Comissao> builder)
        {
            builder.ToTable("TB_COMISSAO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_COMISSAO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IdVendaRecebimentoTipo)
               .HasColumnName("CD_VENDA_RECEBIMENTO_TIPO");

            builder.Property(p => p.IdContaAReceber)
               .HasColumnName("CD_CONTA_RECEBER");

            builder.Property(p => p.IdFatura)
               .HasColumnName("CD_FATURA");

            builder.Property(p => p.IdVendedor)
               .HasColumnName("CD_VENDEDOR");

            builder.Property(p => p.Comissaoo)
               .HasColumnName("PR_COMISSAO");

            builder.Property(p => p.ValorComissao)
               .HasColumnName("VL_COMISSAO");

            builder.Property(p => p.ValorPago)
               .HasColumnName("VL_PAGO");

            builder.Property(p => p.DataEmissao)
               .HasColumnName("DT_EMISSAO");

            builder.Property(p => p.DataVencimento)
               .HasColumnName("DT_VENCIMENTO");

            builder.Property(p => p.DataPagamento)
               .HasColumnName("DT_PAGAMENTO");

            builder.Property(p => p.IdStatus)
               .HasColumnName("CD_STATUS");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
