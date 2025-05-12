using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Financeiros
{
    internal class CentroCustoContaAReceberConfiguration : IEntityTypeConfiguration<Domain.Entities.Financeiros.CentroCustoContaAReceber>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Financeiros.CentroCustoContaAReceber> builder)
        {
            builder.ToTable("VW_CENTRO_CUSTO_CONTA_RECEBER");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                   .HasColumnName("CD_CENTRO_CUSTO")
                   .IsRequired();

            builder.Property(p => p.SequenciaPlanoDeContas)
                   .HasColumnName("SEQUENCIA_PLANO_CONTAS");

            builder.Property(p => p.Descricao)
                   .HasColumnName("DS_CENTRO_CUSTO");
        }
    }
}
