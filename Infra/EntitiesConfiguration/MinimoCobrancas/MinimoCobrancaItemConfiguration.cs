using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class MinimoCobrancaItemConfiguration : IEntityTypeConfiguration<MinimoCobrancaItem>
    {
        public void Configure(EntityTypeBuilder<MinimoCobrancaItem> builder)
        {
            builder.ToTable("TB_MINIMO_COBRANCA_ITEM");

            builder.HasKey(p => new { p.IdMinimoCobranca, p.IdSetorProduto, p.DescricaoSetorProduto });

            builder.Property(p => p.IdMinimoCobranca)
                .HasColumnName("CD_MINIMO_COBRANCA")
                .IsRequired();

            builder.Property(p => p.IdSetorProduto)
                .HasColumnName("CD_SETOR_PRODUTO")
                .IsRequired();

            builder.Property(p => p.DescricaoSetorProduto)
                .HasColumnName("DSC_SETOR")
                .IsRequired();

            builder.HasOne(p => p.MinimoCobranca)
                .WithMany(c => c.MinimoCobrancaItem) 
                .HasForeignKey(p => p.IdMinimoCobranca);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
