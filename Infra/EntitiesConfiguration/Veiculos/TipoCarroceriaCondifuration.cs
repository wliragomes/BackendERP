using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class TipoCarroceriaConfiguration : IEntityTypeConfiguration<TipoCarroceria>
    {
        public void Configure(EntityTypeBuilder<TipoCarroceria> builder)
        {
            builder.ToTable("TB_TIPO_CARROCERIA");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_TIPO_CARROCERIA")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_TIPO_CARROCERIA");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
