using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Vendas;

namespace Infra.EntitiesConfiguration.Vendas
{
    public class ImpressaoEspecialConfiguration : IEntityTypeConfiguration<ImpressaoEspecial>
    {
        public void Configure(EntityTypeBuilder<ImpressaoEspecial> builder)
        {
            builder.ToTable("TB_VENDA_IMPRESSAO_ESPECIAL");
            builder.HasKey(p => p.IdVenda);
            builder.HasIndex(p => p.IdVenda).IsUnique();

            builder.Property(p => p.IdVenda)
                .HasColumnName("CD_VENDA")
                .IsRequired();

            builder.Property(p => p.Texto)
               .HasColumnName("TX_IMPRESSAO_ESPECIAL");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}