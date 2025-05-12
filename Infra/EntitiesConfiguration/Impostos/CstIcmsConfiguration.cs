using Domain.Entities.Impostos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Impostos
{
    internal class CstIcmsConfiguration : IEntityTypeConfiguration<CST_ICMS>
    {
        public void Configure(EntityTypeBuilder<CST_ICMS> builder)
        {
            builder.ToTable("TB_CST_ICMS");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CST_ICMS")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("DS_CST_ICMS");

            builder.Property(p => p.CstIcmsAmigavel)
               .HasColumnName("CD_CST_ICMS_AMIGAVEL");

            builder.Property(p => p.DescontaIcms)
               .HasColumnName("FL_DESCONTA_ICMS");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
