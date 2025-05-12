using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class ParametroMedidaConfiguration : IEntityTypeConfiguration<MedidaParametro>
    {
        public void Configure(EntityTypeBuilder<MedidaParametro> builder)
        {
            builder.ToTable("TB_PARAMETRO_MEDIDA");

            // Declara que a entidade não possui chave primária
            builder.HasNoKey();

            builder.Property(p => p.ToneladaFrete)
               .HasColumnName("VL_TONELADA_FRETE");

            builder.Property(p => p.PesoVidro)
               .HasColumnName("VL_PESO_MILIMETRO_VIDRO");
        }
    }
}
