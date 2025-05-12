using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Vendas
{
    public class RelacionaNormaAbntVendaConfiguration : IEntityTypeConfiguration<RelacionaNormaAbntVenda>
    {
        public void Configure(EntityTypeBuilder<RelacionaNormaAbntVenda> builder)
        {
            builder.ToTable("TB_RELACIONA_VENDA_NORMA_ABNT");

            builder.HasKey(p => new { p.IdVenda, p.IdNormaAbnt });

            builder.Property(p => p.IdVenda)
                .HasColumnName("CD_VENDA")
                .IsRequired();

            builder.Property(p => p.IdNormaAbnt)
                .HasColumnName("CD_ABNT")
                .IsRequired();

            builder.HasOne(e => e.Venda)
                .WithMany(p => p.RelacionaNormaAbntVenda)
                .HasForeignKey(e => e.IdVenda);

            builder.HasOne(rpe => rpe.NormaAbnt)
                .WithMany(e => e.RelacionaNormaAbntVenda)
                .HasForeignKey(rpe => rpe.IdNormaAbnt);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
