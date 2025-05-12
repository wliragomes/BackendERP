using Domain.Entities.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Produtos
{
    public class ComposicaoConfiguration : IEntityTypeConfiguration<Composicao>
    {
        public void Configure(EntityTypeBuilder<Composicao> builder)
        {
            builder.ToTable("TB_PRODUTO_COMPOSICAO");

            // Definindo a chave primária composta
            builder.HasKey(p => new { p.IdProduto, p.IdComposicao });
            builder.HasIndex(p => p.IdProduto);

            builder.Property(p => p.IdComposicao)
                .HasColumnName("CD_COMPOSICAO")
                .IsRequired();

            builder.Property(p => p.IdProduto)
                .HasColumnName("CD_PRODUTO")
                .IsRequired();

            builder.Property(p => p.SequenciaComposicao)
                .HasColumnName("NR_SEQUENCIA_COMPOSICAO");

            builder.Property(p => p.PerfilH)
                .HasColumnName("NR_PERFIL_H");

            builder.Property(p => p.PerfilL)
                .HasColumnName("NR_PERFIL_W");

            builder.Property(p => p.Etiqueta)
                .HasColumnName("FL_ETIQUETA")
                .IsRequired();

            builder.HasOne(e => e.Produto)
                .WithMany(p => p.Composicao)
                .HasForeignKey(e => e.IdProduto);

            builder.HasQueryFilter(p => !p.Removed);

        }
    }
}
