using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class ContaAReceberConfiguration : IEntityTypeConfiguration<ContaAReceber>
    {
        public void Configure(EntityTypeBuilder<ContaAReceber> builder)
        {
            builder.ToTable("TB_CONTA_RECEBER");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CONTA_RECEBER")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Status)
               .HasColumnName("FL_STATUS");

            builder.Property(p => p.Rascunho)
               .HasColumnName("FL_RASCUNHO");

            builder.Property(p => p.IdCliente)
               .HasColumnName("CD_PESSOA");

            builder.Property(p => p.NDocumento)
               .HasColumnName("NR_DOCUMENTO");

            builder.Property(p => p.DataDocumento)
               .HasColumnName("DT_DOCUMENTO");

            builder.Property(p => p.DataVencimento)
               .HasColumnName("DT_VENCIMENTO");

            builder.Property(p => p.ValorDocumento)
               .HasColumnName("VL_DOCUMENTO");

            builder.Property(p => p.UnitarioPeriodoMensal)
               .HasColumnName("FL_UNITARIO_PERIODICO_MENSAL");

            builder.Property(p => p.QtdParcela)
               .HasColumnName("QT_PARCELA");

            builder.Property(p => p.QtdPeriodo)
               .HasColumnName("QT_PERIODO");

            builder.Property(p => p.IdCentroDeCusto)
               .HasColumnName("CD_CENTRO_CUSTO");

            builder.Property(p => p.IdDespesa)
               .HasColumnName("CD_TIPO_DESPESA");

            builder.Property(p => p.IdBanco)
               .HasColumnName("CD_BANCO");

            builder.Property(p => p.IdFatura)
               .HasColumnName("CD_FATURA");

            builder.Property(p => p.Historico)
               .HasColumnName("TX_HISTORICO");

            builder.HasOne(p => p.Pessoa)
                .WithOne(c => c.ContaAReceber) // Relação 1:1
                .HasForeignKey<ContaAReceber>(p => p.IdCliente); // Define a chave estrangeira

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
