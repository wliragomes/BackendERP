using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class MoedaConfiguration : IEntityTypeConfiguration<Moeda>
    {
        public void Configure(EntityTypeBuilder<Moeda> builder)
        {
            builder.ToTable("TB_MOEDA");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_MOEDA")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("NM_MOEDA");

            builder.Property(p => p.Negociavel)
               .HasColumnName("FL_NEGOCIAVEL_BC");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
