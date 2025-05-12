using Domain.Entities.Produtos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EntitiesConfiguration.Produtos
{
    public class ClasseReajusteConfiguration : IEntityTypeConfiguration<ClasseReajuste>
    {
        public void Configure(EntityTypeBuilder<ClasseReajuste> builder)
        {
            builder.ToTable("TB_CLASSE_REAJUSTE");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CLASSE_REAJUSTE")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.Nome)
               .HasColumnName("NM_CLASSE_REAJUSTE")
               .IsRequired();

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_CLASSE_REAJUSTE")
               .IsRequired();

            // Adiciona o filtro global para ignorar entidades marcadas como removidas
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
