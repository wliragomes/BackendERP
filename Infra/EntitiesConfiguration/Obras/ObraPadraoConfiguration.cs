using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class ObraPadraoConfiguration : IEntityTypeConfiguration<ObraPadrao>
    {
        public void Configure(EntityTypeBuilder<ObraPadrao> builder)
        {
            builder.ToTable("TB_OBRA_PADRAO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_OBRA_PADRAO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("NM_OBRA_PADRAO");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
