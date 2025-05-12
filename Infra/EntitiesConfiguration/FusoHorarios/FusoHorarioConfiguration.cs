using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class FusoHorarioConfiguration : IEntityTypeConfiguration<FusoHorario>
    {
        public void Configure(EntityTypeBuilder<FusoHorario> builder)
        {
            builder.ToTable("TB_FUSO_HORARIO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_FUSO_HORARIO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.NumeroFusoHorario)
               .HasColumnName("NR_FUSO_HORARIO");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
