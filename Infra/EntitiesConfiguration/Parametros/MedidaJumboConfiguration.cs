using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class MedidaJumboConfiguration : IEntityTypeConfiguration<MedidaJumbo>
    {
        public void Configure(EntityTypeBuilder<MedidaJumbo> builder)
        {
            builder.ToTable("TB_PARAMETRO_MEDIDA_JUMBO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_JUMBO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Ordem)
                .HasColumnName("CD_ORDEM")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Habilitar)
               .HasColumnName("FL_HABILITAR");

            builder.Property(p => p.Altura)
               .HasColumnName("VL_ALTURA");

            builder.Property(p => p.Largura)
               .HasColumnName("VL_LARGURA");


            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
