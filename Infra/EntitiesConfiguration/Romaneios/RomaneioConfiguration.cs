using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class RomaneioConfiguration : IEntityTypeConfiguration<Romaneio>
    {
        public void Configure(EntityTypeBuilder<Romaneio> builder)
        {
            builder.ToTable("TB_ROMANEIO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_ROMANEIO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.SqRomaneioCodigo)
               .HasColumnName("SQ_ROMANEIO_COD");

            builder.Property(p => p.SqRomaneioAno)
               .HasColumnName("SQ_ROMANEIO_ANO");

            builder.Property(p => p.QtdFrete)
               .HasColumnName("QT_FRETE");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
