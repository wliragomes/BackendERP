using Domain.Entities.Produtos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EntitiesConfiguration.Produtos
{
    public class TipoProdutoConfiguration : IEntityTypeConfiguration<TipoProduto>
    {
        public void Configure(EntityTypeBuilder<TipoProduto> builder)
        {
            builder.ToTable("TB_TIPO_PRODUTO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_TIPO_PRODUTO")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.Nome)
               .HasColumnName("NM_TIPO_PRODUTO");

            // Adiciona o filtro global para ignorar entidades marcadas como removidas
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
