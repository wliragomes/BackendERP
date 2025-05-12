using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class MotivoCancelamentoConfiguration : IEntityTypeConfiguration<MotivoCancelamento>
    {
        public void Configure(EntityTypeBuilder<MotivoCancelamento> builder)
        {
            builder.ToTable("TB_MOTIVO_CANCELAMENTO_PEDIDO_ORCAMENTO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_MOTIVO_CANCELAMENTO_PEDIDO_ORCAMENTO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("NM_MOTIVO_CANCELAMENTO_PEDIDO_ORCAMENTO");

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_MOTIVO_CANCELAMENTO_PEDIDO_ORCAMENTO");

            builder.Property(p => p.Pedido)
               .HasColumnName("BT_PEDIDO");

            builder.Property(p => p.Orcamento)
               .HasColumnName("BT_ORCAMENTO");

            builder.Property(p => p.PedidoInativo)
               .HasColumnName("BT_INATIVO_PEDIDO");

            builder.Property(p => p.OrcamentoInativo)
               .HasColumnName("BT_INATIVO_ORCAMENTO");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
