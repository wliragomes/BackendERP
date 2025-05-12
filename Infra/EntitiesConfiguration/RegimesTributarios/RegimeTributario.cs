using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class RegimeTributarioConfiguration : IEntityTypeConfiguration<RegimeTributario>
    {
        public void Configure(EntityTypeBuilder<RegimeTributario> builder)
        {
            builder.ToTable("TB_REGIME_TRIBUTARIO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_REGIME_TRIBUTARIO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("NM_REGIME_TRIBUTARIO"); 

            builder.Property(p => p.ValorPis)
               .HasColumnName("VL_PIS"); 

            builder.Property(p => p.ValorCofins)
               .HasColumnName("VL_COFINS");            

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
