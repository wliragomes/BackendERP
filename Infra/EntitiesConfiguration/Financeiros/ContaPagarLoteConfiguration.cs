using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class ContaPagarLoteConfiguration : IEntityTypeConfiguration<ContaPagarLote>
    {
        public void Configure(EntityTypeBuilder<ContaPagarLote> builder)
        {
            builder.ToTable("TB_CONTA_PAGAR_LOTE");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CONTA_PAGAR_LOTE")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}