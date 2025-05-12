using Domain.Entities.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Produtos
{
    public class RelacionaProdutoFornecedorConfiguration : IEntityTypeConfiguration<RelacionaProdutoFornecedor>
    {
        public void Configure(EntityTypeBuilder<RelacionaProdutoFornecedor> builder)
        {
            builder.ToTable("TB_RELACIONA_PRODUTO_FORNECEDOR");

            // Mapeie Id como chave primária
            builder.HasKey(p => new { p.IdFornecedor, p.IdProduto });

            builder.Property(p => p.IdFornecedor)
                .HasColumnName("CD_PESSOA")
                .IsRequired();

            builder.Property(p => p.IdProduto)
                .HasColumnName("CD_PRODUTO")
                .IsRequired();

            builder.Property(p => p.CodigoProdutoFornecedor)
                .HasColumnName("NR_CODIGO_PRODUTO_FORNECEDOR");

            // Configuração do relacionamento com Produto
            builder.HasOne(e => e.Produto)
                .WithMany(p => p.RelacionaProdutoFornecedor)
                .HasForeignKey(e => e.IdProduto)
                .OnDelete(DeleteBehavior.Cascade); // Define o comportamento de exclusão

            // Configuração do relacionamento com Fornecedor
            builder.HasOne(e => e.Pessoa)
                .WithMany(p => p.RelacionaProdutoFornecedor)
                .HasForeignKey(e => e.IdFornecedor)
                .OnDelete(DeleteBehavior.Cascade); // Define o comportamento de exclusão

            // Filtro para não incluir registros marcados como removidos
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}