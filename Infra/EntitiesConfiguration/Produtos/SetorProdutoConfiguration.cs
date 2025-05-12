using Domain.Entities.Produtos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EntitiesConfiguration.Produtos
{
    public class SetorProdutoConfiguration : IEntityTypeConfiguration<SetorProduto>
    {
        public void Configure(EntityTypeBuilder<SetorProduto> builder)
        {
            builder.ToTable("TB_SETOR_PRODUTO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_SETOR_PRODUTO")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.CodigoSetor)
               .HasColumnName("NR_CODIGO_SETOR");

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_SETOR_PRODUTO");

            builder.Property(p => p.Componente)
               .HasColumnName("FL_COMPONENTE");

            builder.Property(p => p.Cmax)
               .HasColumnName("NR_CMAX");

            builder.Property(p => p.Cmin)
               .HasColumnName("NR_CMIN");

            builder.Property(p => p.Lmax)
               .HasColumnName("NR_LMAX");

            builder.Property(p => p.Lmin)
               .HasColumnName("NR_LMIN");

            builder.Property(p => p.Perfil)
               .HasColumnName("FL_PERFIL");

            builder.Property(p => p.CobrancaMinima)
               .HasColumnName("NR_COBRANCA_MINIMA");

            builder.Property(p => p.SetorFabricacao)
               .HasColumnName("FL_SETOR_FABRICACAO");

            builder.Property(p => p.Pvb)
               .HasColumnName("FL_PVB");

            builder.Property(p => p.Argonio)
               .HasColumnName("FL_ARGONIO");

            builder.Property(p => p.MostrarCadastro)
               .HasColumnName("FL_MOSTRAR_CADASTRO");

            // Adiciona o filtro global para ignorar entidades marcadas como removidas
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
