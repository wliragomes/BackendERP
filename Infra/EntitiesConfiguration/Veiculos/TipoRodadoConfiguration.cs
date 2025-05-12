using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class TipoRodadoConfiguration : IEntityTypeConfiguration<TipoRodado>
    {
        public void Configure(EntityTypeBuilder<TipoRodado> builder)
        {
            builder.ToTable("TB_TIPO_RODADO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_TIPO_RODADO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_TIPO_RODADO");
                       
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
