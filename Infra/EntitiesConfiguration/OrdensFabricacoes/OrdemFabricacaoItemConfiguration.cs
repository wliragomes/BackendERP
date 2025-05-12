using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class OrdemFabricacaoItemConfiguration : IEntityTypeConfiguration<OrdemFabricacaoItem>
    {
        public void Configure(EntityTypeBuilder<OrdemFabricacaoItem> builder)
        {
            builder.ToTable("TB_ORDEM_FABRICACAO_ITEM");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_ORDEM_FABRICACAO_ITEM")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IdOrdemFabricacao)
                .HasColumnName("CD_ORDEM_FABRICACAO");

            builder.Property(p => p.SqItem)
                .HasColumnName("SQ_ITEM");

            builder.Property(p => p.SqVendaItem)
                .HasColumnName("SQ_VENDA_ITEM");

            builder.Property(p => p.IdProduto)
                .HasColumnName("CD_PRODUTO");

            builder.Property(p => p.NomeProduto)
                .HasColumnName("NM_PRODUTO");

            builder.Property(p => p.DescricaoProduto)
                .HasColumnName("DS_PRODUTO");

            builder.Property(p => p.Espessura)
                .HasColumnName("VL_ESPESSURA");

            builder.Property(p => p.Altura)
                .HasColumnName("NR_ALTURA");

            builder.Property(p => p.Largura)
                .HasColumnName("NR_LARGURA");

            builder.Property(p => p.Quantidade)
                .HasColumnName("QT_PECA");

            builder.Property(p => p.Aramado)
                .HasColumnName("FL_ARAMADO");

            builder.Property(p => p.Modelado)
                .HasColumnName("FL_MODELADO");

            builder.Property(p => p.ValorM2)
                .HasColumnName("VL_M2");

            builder.Property(p => p.ValorM)
                .HasColumnName("VL_M_LINEAR");

            builder.Property(p => p.ValorPeso)
                .HasColumnName("VL_PESO");

            builder.Property(p => p.ValorM2Real)
                .HasColumnName("VL_M2_REAL");

            builder.Property(p => p.ValorMReal)
                .HasColumnName("VL_M_LINEAR_REAL");

            builder.Property(p => p.ValorPesoReal)
                .HasColumnName("VL_PESO_REAL");

            builder.Property(p => p.ValorAreaMinima)
                .HasColumnName("VL_AREA_MINIMA");

            builder.Property(p => p.IdSetorProduto)
                .HasColumnName("CD_SETOR_PRODUTO");

            builder.Property(p => p.IdProjeto)
                .HasColumnName("CD_PROJETO");

            builder.Property(p => p.AlturaLapidacao)
                .HasColumnName("VL_LAPIDACAO_ALTURA");

            builder.Property(p => p.LarguraLapidacao)
                .HasColumnName("VL_LAPIDACAO_LARGURA");

            builder.Property(p => p.Manual)
                .HasColumnName("FL_MANUAL");

            builder.Property(p => p.Cortado)
                .HasColumnName("FL_CORTADO");

            builder.Property(p => p.Filete1)
                .HasColumnName("FL_FILETE_01");

            builder.Property(p => p.Filete2)
                .HasColumnName("FL_FILETE_02");

            builder.Property(p => p.Filete3)
                .HasColumnName("FL_FILETE_03");

            builder.Property(p => p.Filete4)
                .HasColumnName("FL_FILETE_04");

            builder.Property(p => p.Industrial1)
                .HasColumnName("FL_INDUSTRIAL_01");

            builder.Property(p => p.Industrial2)
                .HasColumnName("FL_INDUSTRIAL_02");

            builder.Property(p => p.Industrial3)
                .HasColumnName("FL_INDUSTRIAL_03");

            builder.Property(p => p.Industrial4)
                .HasColumnName("FL_INDUSTRIAL_04");

            builder.Property(p => p.Polida1)
                .HasColumnName("FL_POLIDA_01");

            builder.Property(p => p.Polida2)
                .HasColumnName("FL_POLIDA_02");

            builder.Property(p => p.Polida3)
                .HasColumnName("FL_POLIDA_03");

            builder.Property(p => p.Polida4)
                .HasColumnName("FL_POLIDA_04");

            builder.Property(p => p.QuebraCanto)
                .HasColumnName("FL_QUEBRA_CANTO");

            builder.Property(p => p.Revenda)
                .HasColumnName("FL_REVENDA");

            builder.Property(p => p.Instalacao)
                .HasColumnName("FL_INSTACACAO");

            builder.Property(p => p.ManterEdgeDeletion)
                .HasColumnName("FL_EDGE_DELETION");

            builder.Property(p => p.CancelarEdgeDeletion)
                .HasColumnName("FL_EDGE_DELETION_CANCELADO");

            builder.HasOne(p => p.OrdemFabricacao)
                .WithMany(c => c.OrdemFabricacaoItem)
                .HasForeignKey(p => p.IdOrdemFabricacao);

            builder.HasOne(p => p.Produto)
                .WithOne(c => c.OrdemFabricacaoItem)
                .HasForeignKey<OrdemFabricacaoItem>(p => p.IdProduto);

            builder.HasOne(p => p.Projeto)
                .WithOne(c => c.OrdemFabricacaoItem)
                .HasForeignKey<OrdemFabricacaoItem>(p => p.IdProjeto);            

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
