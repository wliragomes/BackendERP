using Domain.Entities.Produtos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EntitiesConfiguration.Produtos
{
    public class DesgastePolimentoConfiguration : IEntityTypeConfiguration<DesgastePolimento>
    {
        public void Configure(EntityTypeBuilder<DesgastePolimento> builder)
        {
            builder.ToTable("TB_PRODUTO_DESGASTE_POLIMENTO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_PRODUTO_DESGASTE_POLIMENTO")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.EspessuraVidroMinimo)
               .HasColumnName("QT_ESPESSURA_VIDRO_MINIMO")
               .IsRequired();

            builder.Property(p => p.EspessuraVidroMaximo)
               .HasColumnName("QT_ESPESSURA_VIDRO_MAXIMO")
               .IsRequired();

            builder.Property(p => p.QuantidadeDesgasteLado)
               .HasColumnName("QT_DESGASTE_LADO")
               .IsRequired();

            builder.Property(p => p.QuantidadeDesgasteTotal)
               .HasColumnName("QT_DESGASTE_TOTAL")
               .IsRequired();

            // Adiciona o filtro global para ignorar entidades marcadas como removidas
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
