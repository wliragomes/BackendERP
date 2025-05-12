using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EntitiesConfiguration
{
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("TB_PAIS");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_PAIS")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("NM_PAIS");

            builder.Property(p => p.IdFusoHorario)
               .HasColumnName("CD_FUSO_HORARIO");

            builder.Property(p => p.IdDdi)
               .HasColumnName("CD_CODIGO_DDI");

            builder.Property(p => p.IdMoedaPrincipal)
               .HasColumnName("CD_MOEDA_PRINCIPAL");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
