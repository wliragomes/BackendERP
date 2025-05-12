using Domain.Entities.Pessoas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EntitiesConfiguration.Pessoas
{
    public class SegmentoClienteConfiguration : IEntityTypeConfiguration<SegmentoCliente>
    {
        public void Configure(EntityTypeBuilder<SegmentoCliente> builder)
        {
            builder.ToTable("TB_SEGMENTO_CLIENTE");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_SEGMENTO_CLIENTE")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_SEGMENTO_CLIENTE")
               .IsRequired();

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}