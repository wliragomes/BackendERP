using Domain.Entities.Impostos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Impostos
{
    internal class CofinsConfiguration : IEntityTypeConfiguration<Cofins>
    {
        public void Configure(EntityTypeBuilder<Cofins> builder)
        {
            builder.ToTable("TB_CST_COFINS");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CST_COFINS")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("DS_CST_COFINS");

            builder.Property(p => p.CofinsAmigavel)
               .HasColumnName("CD_CST_COFINS_AMIGAVEL");

            builder.Property(p => p.DescontaCofins)
               .HasColumnName("FL_DESCONTA_COFINS");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
