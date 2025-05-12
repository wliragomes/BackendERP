using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class MinimoCobrancaConfiguration : IEntityTypeConfiguration<MinimoCobranca>
    {
        public void Configure(EntityTypeBuilder<MinimoCobranca> builder)
        {
            builder.ToTable("TB_MINIMO_COBRANCA");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_MINIMO_COBRANCA")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_MINIMO_COBRANCA");

            builder.Property(p => p.ValorMinimoCobranca)
               .HasColumnName("VL_MINIMO_COBRANCA");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
