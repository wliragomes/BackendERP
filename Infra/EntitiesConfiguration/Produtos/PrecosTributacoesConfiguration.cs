using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Produtos;

namespace Infra.EntitiesConfiguration.Produtos
{
    public class PrecosTributacoesConfiguration : IEntityTypeConfiguration<PrecosTributacoes>
    {
        public void Configure(EntityTypeBuilder<PrecosTributacoes> builder)
        {
            builder.ToTable("TB_PRODUTO_PRECO_TRIBUTACAO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_PRODUTO_PRECO_TRIBUTACAO")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.IdProduto)
               .HasColumnName("CD_PRODUTO")
               .IsRequired();            

            builder.Property(p => p.IdNcm)
               .HasColumnName("CD_NCM")
               .IsRequired();
            
            builder.Property(p => p.IdOrigemMaterial)
               .HasColumnName("CD_ORIGEM_MATERIAL")
               .IsRequired();

            builder.Property(p => p.IdTipoPreco)
               .HasColumnName("CD_TIPO_PRECO")
               .IsRequired();

            builder.Property(p => p.IdClasseReajuste)
               .HasColumnName("CD_CLASSE_REAJUSTE")
               .IsRequired();

            builder.Property(p => p.PrecoCusto)
               .HasColumnName("VL_PRECO_CUSTO")
               .IsRequired();            

            builder.Property(p => p.PrecoVenda)
               .HasColumnName("VL_PRECO_VENDA")
               .IsRequired();           

            builder.Property(p => p.Inativo)
               .HasColumnName("FL_INATIVO");

            builder.HasOne(e => e.Produto)
                .WithMany()
                .HasForeignKey(e => e.IdProduto);

            builder.HasOne(e => e.Produto)
                   .WithMany(p => p.PrecosTributacoes)
                   .HasForeignKey(e => e.IdProduto);


            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}