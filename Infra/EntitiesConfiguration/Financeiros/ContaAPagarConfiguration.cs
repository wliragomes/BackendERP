using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class ContaAPagarConfiguration : IEntityTypeConfiguration<ContaAPagar>
    {
        public void Configure(EntityTypeBuilder<ContaAPagar> builder)
        {
            builder.ToTable("TB_CONTA_PAGAR");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CONTA_PAGAR")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Status)
               .HasColumnName("FL_STATUS");

            builder.Property(p => p.Rascunho)
               .HasColumnName("FL_RASCUNHO");

            builder.Property(p => p.IdFornecedor)
               .HasColumnName("CD_PESSOA");

            builder.Property(p => p.IdModalidade)
               .HasColumnName("CD_MODALIDADE");

            builder.Property(p => p.NDocumento)
               .HasColumnName("NR_DOCUMENTO");

            builder.Property(p => p.DataDocumento)
               .HasColumnName("DT_DOCUMENTO");

            builder.Property(p => p.ValorDocumento)
               .HasColumnName("VL_DOCUMENTO");

            builder.Property(p => p.ValorSaldo)
               .HasColumnName("VL_SALDO");

            builder.Property(p => p.AntecipaDataPagamento)
               .HasColumnName("FL_ANTECIPA_DATA_PAGAMENTO");

            builder.Property(p => p.Resumo)
               .HasColumnName("FL_RESUMO");

            builder.Property(p => p.UnitarioPeriodoMensal)
               .HasColumnName("FL_UNITARIO_PERIODICO_MENSAL");

            builder.Property(p => p.LancadaDefinida)
               .HasColumnName("FL_LANCADA_DEFINIDA_CONTINUA_ESPECIAIS");

            builder.Property(p => p.QtdParcela)
               .HasColumnName("QT_PARCELA");

            builder.Property(p => p.QtdPeriodo)
               .HasColumnName("QT_PERIODO");

            builder.Property(p => p.Reajuste)
               .HasColumnName("PR_REAJUSTE");

            builder.Property(p => p.DataVencimento)
               .HasColumnName("DT_VENCIMENTO");

            builder.Property(p => p.IdBanco)
               .HasColumnName("CD_BANCO");

            builder.Property(p => p.Historico)
               .HasColumnName("TX_HISTORICO");

            builder.HasOne(p => p.Pessoa)
                .WithOne(c => c.ContaAPagar) // Relação 1:1
                .HasForeignKey<ContaAPagar>(p => p.IdFornecedor); // Define a chave estrangeira

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
