using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class OperacaoConfiguration : IEntityTypeConfiguration<Operacao>
    {
        public void Configure(EntityTypeBuilder<Operacao> builder)
        {
            builder.ToTable("TB_OPERACAO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_OPERACAO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("NM_OPERACAO");

            builder.Property(p => p.DescontaFinanceiro)
               .HasColumnName("FL_DESCONTA_FINANCEIRO");

            builder.Property(p => p.LancaComissao)
               .HasColumnName("FL_LANCA_COMISSAO");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
