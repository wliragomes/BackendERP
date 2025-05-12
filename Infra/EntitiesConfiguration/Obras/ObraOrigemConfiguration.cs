using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class ObraOrigemConfiguration : IEntityTypeConfiguration<ObraOrigem>
    {
        public void Configure(EntityTypeBuilder<ObraOrigem> builder)
        {
            builder.ToTable("TB_OBRA_ORIGEM");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_OBRA_ORIGEM")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("NM_OBRA_ORIGEM");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
