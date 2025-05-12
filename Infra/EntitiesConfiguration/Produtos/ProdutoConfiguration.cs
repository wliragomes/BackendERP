using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Produtos;
using Domain.Entities;

namespace Infra.EntitiesConfiguration.Produtos
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("TB_PRODUTO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_PRODUTO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.CodigoAmigavel)
                .HasColumnName("CD_AMIGAVEL");

            builder.Property(p => p.Nome)
                .HasColumnName("NM_PRODUTO");            

            builder.Property(p => p.Espessura)
                .HasColumnName("NR_ESPESSURA");

            builder.Property(p => p.PesoBruto)
                .HasColumnName("NR_PESO_BRUTO")
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.PesoLiquido)
                .HasColumnName("NR_PESO_LIQUIDO")
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.IdSetorProduto)
                .HasColumnName("CD_SETOR_PRODUTO");

            builder.Property(p => p.CodigoBarras)
                .HasColumnName("NR_CODIGO_BARRAS");
          
            builder.Property(p => p.EstoqueMinimo)
                .HasColumnName("VL_ESTOQUE_MINIMO")
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.IdMateriaPrima)
                .HasColumnName("CD_MATERIA_PRIMA_MP");

            builder.Property(p => p.EstoqueMaximo)
                .HasColumnName("VL_ESTOQUE_MAXIMO")
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.IdCodigoImportacao)
                .HasColumnName("CD_CODIGO_IMPORTACAO");

            builder.Property(p => p.CorteCerto)
                .HasColumnName("CD_CORTE_CERTO");

            builder.Property(p => p.IdUnidadeMedida)
                .HasColumnName("CD_UNIDADE_MEDIDA");

            builder.Property(p => p.IdTipoProduto)
                .HasColumnName("CD_TIPO_PRODUTO");         

            builder.Property(p => p.IdGrupo)
                .HasColumnName("CD_GRUPO");

            builder.Property(p => p.IdSubgrupo)
                .HasColumnName("CD_SUBGRUPO");

            builder.Property(p => p.IdFamilia)
                .HasColumnName("CD_FAMILIA");

            builder.Property(p => p.IdSetor)
                .HasColumnName("CD_SETOR");

            builder.Property(p => p.IdRua)
                .HasColumnName("CD_RUA");

            builder.Property(p => p.IdPrateleira)
                .HasColumnName("CD_PRATELEIRA");

            builder.Property(p => p.Posicao)
                .HasColumnName("NR_POSICAO");

            builder.Property(p => p.InformacoesComplementares)
                .HasColumnName("TX_INFORMACOES_COMPLEMENTARES");

            builder.Property(p => p.EdgeDeleton)
                .HasColumnName("FL_EDGE_DELETION");

            builder.Property(p => p.Bloqueado)
                .HasColumnName("FL_BLOQUEADO");

            builder.Property(p => p.DataBloqueio)
                .HasColumnName("DT_DATA_BLOQUEIO")
                .HasColumnType("date");

            builder.HasOne(p => p.UnidadeMedida)
                .WithMany()
                .HasForeignKey(p => p.IdUnidadeMedida);

            builder.HasOne(p => p.SetorProduto)
                .WithMany()
                .HasForeignKey(p => p.IdSetorProduto);

            builder.HasOne(p => p.TipoProduto)
                .WithMany()
                .HasForeignKey(p => p.IdTipoProduto);

            builder.HasOne(p => p.Grupo)
                .WithMany()
                .HasForeignKey(p => p.IdGrupo);

            builder.HasOne(p => p.Subgrupo)
                .WithMany()
                .HasForeignKey(p => p.IdSubgrupo);

            builder.HasOne(p => p.Familia)
                .WithMany()
                .HasForeignKey(p => p.IdFamilia);

            builder.HasOne(p => p.Setor)
                .WithMany()
                .HasForeignKey(p => p.IdSetor);

            builder.HasOne(p => p.Rua)
                .WithMany()
                .HasForeignKey(p => p.IdRua);

            builder.HasOne(p => p.Prateleira)
                .WithMany()
                .HasForeignKey(p => p.IdPrateleira);

            builder.HasOne(p => p.CodigoImportacao)
                .WithMany()
                .HasForeignKey(p => p.IdCodigoImportacao);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
