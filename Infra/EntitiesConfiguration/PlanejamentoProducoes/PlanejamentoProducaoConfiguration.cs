using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class PlanejamentoProducaoConfiguration : IEntityTypeConfiguration<PlanejamentoProducao>
    {
        public void Configure(EntityTypeBuilder<PlanejamentoProducao> builder)
        {
            builder.ToTable("TB_PLANEJAMENTO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_PLANEJAMENTO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IdOrdemFabricacao)
               .HasColumnName("CD_ORDEM_FABRICACAO");

            builder.Property(p => p.IdOrdemFabricacaoItem)
               .HasColumnName("CD_ORDEM_FABRICACAO_ITEM");

            builder.Property(p => p.IdComposicao)
               .HasColumnName("CD_COMPOSICAO");

            builder.Property(p => p.SequenciaComposicacao)
               .HasColumnName("NR_SEQUENCIA_COMPOSICAO");

            builder.Property(p => p.AlturaLapidacao)
               .HasColumnName("NR_ALTURA");

            builder.Property(p => p.Altura)
               .HasColumnName("NR_ALTURA");

            builder.Property(p => p.Largura)
               .HasColumnName("NR_LARGURA");            

            builder.Property(p => p.NPeca)
               .HasColumnName("NR_PECA");           

            builder.Property(p => p.QtdTotalPeca)
               .HasColumnName("QT_TOTAL_PECA");   

            builder.Property(p => p.CodigoBarra)
               .HasColumnName("NR_COD_BARRA"); 

            builder.Property(p => p.AnoBarra)
               .HasColumnName("NR_ANO_BARRA"); 

            builder.Property(p => p.CodigoBarraCompleto)
               .HasColumnName("NR_COD_BARRA_COMPLETO"); 

            builder.Property(p => p.ValorM2)
               .HasColumnName("VL_M2");

            builder.Property(p => p.ValorMLinear)
               .HasColumnName("VL_M_LINEAR");

            builder.Property(p => p.ValorPeso)
               .HasColumnName("VL_PESO");

            builder.Property(p => p.ValorM2Real)
               .HasColumnName("VL_M2_REAL");

            builder.Property(p => p.ValorMLinearReal)
               .HasColumnName("VL_M_LINEAR_REAL");

            builder.Property(p => p.ValorPesoReal)
               .HasColumnName("VL_PESO_REAL");

            builder.Property(p => p.ValorAreaMinima)
               .HasColumnName("VL_AREA_MINIMA");

            builder.Property(p => p.IdSetorProduto)
               .HasColumnName("CD_SETOR_PRODUTO");

            builder.Property(p => p.AlturaLapidacao)
               .HasColumnName("VL_LAPIDACAO_ALTURA");

            builder.Property(p => p.LarguraLapidacao)
               .HasColumnName("VL_LAPIDACAO_LARGURA");

            builder.Property(p => p.DataReposicao)
               .HasColumnName("DT_REPOSICAO");

            builder.Property(p => p.IdPlanejamentoComposto)
               .HasColumnName("CD_PLANEJAMENTO_REPOSTO");

            builder.Property(p => p.Reposicao)
               .HasColumnName("FL_REPOSICAO");

            builder.Property(p => p.Reposto)
               .HasColumnName("FL_REPOSTO");

            builder.HasOne(p => p.OrdemFabricacao)
                .WithOne(c => c.PlanejamentoProducao)
                .HasForeignKey<PlanejamentoProducao>(p => p.IdOrdemFabricacao);            

            builder.HasOne(p => p.SetorProduto)
                .WithOne(c => c.PlanejamentoProducao)
                .HasForeignKey<PlanejamentoProducao>(p => p.IdSetorProduto);

            builder.HasOne(p => p.OrdemFabricacaoItem)
                .WithOne(c => c.PlanejamentoProducao)
                .HasForeignKey<PlanejamentoProducao>(p => p.IdOrdemFabricacaoItem);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
