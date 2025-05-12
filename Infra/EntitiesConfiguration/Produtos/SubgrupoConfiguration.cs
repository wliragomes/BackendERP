using Domain.Entities.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Produtos
{
    public class SubgrupoConfiguration : IEntityTypeConfiguration<Subgrupo>
    {
        public void Configure(EntityTypeBuilder<Subgrupo> builder)
        {
            builder.ToTable("TB_SUBGRUPO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_SUBGRUPO")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.Nome)
               .HasColumnName("NM_SUBGRUPO")
               .IsRequired();

            // Adiciona o filtro global para ignorar entidades marcadas como removidas
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
