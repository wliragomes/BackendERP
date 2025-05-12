using Domain.Entities.DashBoards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.DashBoards
{
    internal class DashBoardConfiguration : IEntityTypeConfiguration<DashBoard>
    {
        public void Configure(EntityTypeBuilder<DashBoard> builder)
        {
            builder.ToTable("VW_DASHBOARD");

            builder.HasNoKey();

            builder.Property(p => p.QuantidadePedido)
               .HasColumnName("QTD_PEDIDO");

            builder.Property(p => p.QuantidadePedidoUltimaSemana)
               .HasColumnName("QTD_PEDIDO_ULTIMA_SEMANA");

            builder.Property(p => p.QuantidadeFaturamento)
               .HasColumnName("QTD_FATURAMENTO");

            builder.Property(p => p.QuantidadeFaturamentoUltimaSemana)
               .HasColumnName("QTD_FATURAMENTO_ULTIMA_SEMANA");

            builder.Property(p => p.QuantidadeNotasEmitidas)
               .HasColumnName("QTD_NOTAS_EMITIDAS");

            builder.Property(p => p.QuantidadeNotasEmitidasHoje)
               .HasColumnName("QTD_NOTAS_EMITIDAS_HOJE");

            builder.Property(p => p.QuantidadeToneladasAFabricar)
               .HasColumnName("QTD_TONELADAS_A_FABRICAR");

            builder.Property(p => p.QuantidadeToneladasAFabricarHoje)
               .HasColumnName("QTD_TONELADAS_A_FABRICAR_HOJE");

            builder.Property(p => p.QuantidadeCorte)
               .HasColumnName("QTD_CORTE");

            builder.Property(p => p.PorcentagemCorte)
               .HasColumnName("PORCENTAGEM_CORTE");

            builder.Property(p => p.QuantidadeTempera)
               .HasColumnName("QTD_TEMPERA");

            builder.Property(p => p.PorcentagemTempera)
               .HasColumnName("PORCENTAGEM_TEMPERA");

            builder.Property(p => p.QuantidadeLapidacao)
               .HasColumnName("QTD_LAPIDACAO");

            builder.Property(p => p.PorcentagemLapidacao)
               .HasColumnName("PORCENTAGEM_LAPIDACAO");

            builder.Property(p => p.QuantidadeLaminacao)
               .HasColumnName("QTD_LAMINACAO");

            builder.Property(p => p.PorcentagemLaminacao)
               .HasColumnName("PORCENTAGEM_LAMINACAO");

            builder.Property(p => p.QuantidadeInsulado)
               .HasColumnName("QTD_INSULADO");

            builder.Property(p => p.PorcentagemInsulado)
               .HasColumnName("PORCENTAGEM_INSULADO");

            builder.Property(p => p.QuantidadeExpedicao)
               .HasColumnName("QTD_EXPEDICAO");

            builder.Property(p => p.PorcentagemExpedicao)
               .HasColumnName("PORCENTAGEM_EXPEDICAO");
        }
    }
}
