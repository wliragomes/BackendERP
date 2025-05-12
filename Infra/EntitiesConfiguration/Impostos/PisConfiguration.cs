using Domain.Entities.Impostos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Impostos
{
    internal class PisConfiguration : IEntityTypeConfiguration<Pis>
    {
        public void Configure(EntityTypeBuilder<Pis> builder)
        {
            builder.ToTable("TB_CST_PIS");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CST_PIS")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("DS_CST_PIS");

            builder.Property(p => p.PisAmigavel)
               .HasColumnName("CD_CST_PIS_AMIGAVEL");

            builder.Property(p => p.DescontaPis)
               .HasColumnName("FL_DESCONTA_PIS");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
