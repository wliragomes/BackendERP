using Domain.Entities.Impostos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Impostos
{
    internal class CstIcmsOrigemMaterialConfiguration : IEntityTypeConfiguration<CstIcmsOrigemMaterial>
    {
        public void Configure(EntityTypeBuilder<CstIcmsOrigemMaterial> builder)
        {
            builder.ToTable("TB_CST_ICMS_ORIGEM_MATERIAL");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CST_ICMS_ORIGEM_MATERIAL")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("DS_CST_ICMS_ORIGEM_MATERIAL");

            builder.Property(p => p.CST_ICMS_Amigavel_Origem_Material)
               .HasColumnName("CD_CST_ICMS_AMIGAVEL_ORIGEM_MATERIAL");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}