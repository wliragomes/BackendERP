using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class CodigoDDIConfiguration : IEntityTypeConfiguration<CodigoDDI>
    {
        public void Configure(EntityTypeBuilder<CodigoDDI> builder)
        {
            builder.ToTable("TB_CODIGO_DDI");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CODIGO_DDI")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Codigo)
               .HasColumnName("NR_CODIGO_DDI");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
