using Domain.Entities.Pessoas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EntitiesConfiguration.Pessoas
{
    public class SegmentoEstrategicoConfiguration : IEntityTypeConfiguration<SegmentoEstrategico>
    {
        public void Configure(EntityTypeBuilder<SegmentoEstrategico> builder)
        {
            builder.ToTable("TB_SEGMENTO_ESTRATEGICO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_SEGMENTO_ESTRATEGICO")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_SEGMENTO_ESTRATEGICO")
               .IsRequired();

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
