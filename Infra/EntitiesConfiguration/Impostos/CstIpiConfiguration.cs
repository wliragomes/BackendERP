using Domain.Entities.Impostos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Impostos
{
    internal class CstIpiConfiguration : IEntityTypeConfiguration<CstIpi>
    {
        public void Configure(EntityTypeBuilder<CstIpi> builder)
        {
            builder.ToTable("TB_CST_IPI");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CST_IPI")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("DS_CST_IPI");

            builder.Property(p => p.CstIpiAmigavel)
               .HasColumnName("CD_CST_IPI_AMIGAVEL");

            builder.Property(p => p.CobraIpi)
               .HasColumnName("FL_COBRA_IPI");

            builder.Property(p => p.EntradaSaida)
              .HasColumnName("FL_ENTRADA_SAIDA");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
