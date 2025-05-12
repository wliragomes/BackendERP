using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class NormaAbntConfiguration : IEntityTypeConfiguration<NormaAbnt>
    {
        public void Configure(EntityTypeBuilder<NormaAbnt> builder)
        {
            builder.ToTable("TB_NORMAS_ABNT");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_ABNT")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Numero)
                .HasColumnName("NM_NBR");

            builder.Property(p => p.Descricao)
                .HasColumnName("DS_NBR");

            builder.Property(p => p.Pedido)
                .HasColumnName("TX_PEDIDO");

            builder.Property(p => p.Validade)
                .HasColumnName("DT_VALIDADE");

            builder.Property(p => p.Vencida)
                .HasColumnName("FL_VENCIDA");

            // Adiciona o filtro global para ignorar entidades marcadas como removidas
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}