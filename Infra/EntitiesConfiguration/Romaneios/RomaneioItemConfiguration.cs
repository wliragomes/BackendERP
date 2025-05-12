using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class RomaneioItemConfiguration : IEntityTypeConfiguration<RomaneioItem>
    {
        public void Configure(EntityTypeBuilder<RomaneioItem> builder)
        {
            builder.ToTable("TB_ROMANEIO_ITEM");

            builder.HasKey(p => new { p.IdRomaneio, p.IdOrdemFabricacaoItem });

            // Propriedades
            builder.Property(p => p.IdRomaneio)
                .HasColumnName("CD_ROMANEIO")
                .IsRequired();

            builder.Property(p => p.IdOrdemFabricacaoItem)
                .HasColumnName("CD_ORDEM_FABRICACAO_ITEM");

            builder.Property(p => p.SqRomaneioItem)
                .HasColumnName("SQ_ROMANEIO_ITEM")
                .IsRequired();

            builder.Property(p => p.QtItem)
                .HasColumnName("QT_ITEM");

            //Relationships
            builder.HasOne(vi => vi.Romaneio)
                .WithMany(v => v.RomaneioItem)
                .HasForeignKey(vi => vi.IdRomaneio);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
