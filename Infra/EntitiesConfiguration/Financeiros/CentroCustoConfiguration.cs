using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Financeiros
{
    internal class CentroCustoConfiguration : IEntityTypeConfiguration<Domain.Entities.Financeiros.CentroCusto>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Financeiros.CentroCusto> builder)
        {
            builder.ToTable("VW_CENTRO_CUSTO_CONTA_PAGAR");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                   .HasColumnName("CD_PLANO_CONTAS")
                   .IsRequired();

            builder.Property(p => p.SequenciaPlanoDeContas)
                   .HasColumnName("SEQUENCIA_PLANO_CONTAS");

            builder.Property(p => p.Descricao)
                   .HasColumnName("DS_CENTRO_CUSTO");            
        }
    }
}
