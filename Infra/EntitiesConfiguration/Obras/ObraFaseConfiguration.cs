using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class ObraFaseConfiguration : IEntityTypeConfiguration<ObraFase>
    {
        public void Configure(EntityTypeBuilder<ObraFase> builder)
        {
            builder.ToTable("TB_OBRA_FASE");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_OBRA_FASE")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("NM_OBRA_FASE");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
