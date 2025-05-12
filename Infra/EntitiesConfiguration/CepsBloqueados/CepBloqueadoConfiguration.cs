using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class CepBloqueadoConfiguration : IEntityTypeConfiguration<CepBloqueado>
    {
        public void Configure(EntityTypeBuilder<CepBloqueado> builder)
        {
            builder.ToTable("TB_CEP_BLOQUEADO_ENTREGA");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CEP_BLOQUEADO_ENTREGA")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.NumeroCep)
               .HasColumnName("NR_CEP");

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_ENDERECO");

            builder.Property(p => p.NumeroDe)
               .HasColumnName("NR_DE");

            builder.Property(p => p.NumeroAte)
               .HasColumnName("NR_ATE");

            builder.Property(p => p.Par)
               .HasColumnName("FL_PAR");

            builder.Property(p => p.Impar)
               .HasColumnName("FL_IMPAR");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
