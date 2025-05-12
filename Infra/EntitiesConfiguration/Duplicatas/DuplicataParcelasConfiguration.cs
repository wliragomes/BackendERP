using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.EntitiesConfiguration
{
    internal class DuplicataParcelaConfiguration : IEntityTypeConfiguration<DuplicataParcela>
    {
        public void Configure(EntityTypeBuilder<DuplicataParcela> builder)
        {
            builder.ToTable("TB_DUPLICATA_PARCELA");
            builder.HasKey(p => p.IdDuplicata);

            builder.Property(p => p.IdDuplicata)
                .HasColumnName("CD_DUPLICATA")
                .IsRequired()
                .ValueGeneratedNever(); // Importante: não gerar valor automático

            builder.Property(p => p.Parcela)
                .HasColumnName("SQ_PARCELA")
                .IsRequired();

            builder.Property(p => p.ValorDuplicata)
                .HasColumnName("VL_DUPLICATA")
                .IsRequired();

            builder.Property(p => p.ValorDuplicataExtenso)
                .HasColumnName("VL_DUPLICATA_EXTENSO");

            builder.Property(p => p.DataVencimento)
                .HasColumnName("DT_VENCIMENTO")
                .IsRequired();

            builder.HasOne(p => p.Duplicata)
                .WithOne()
                .HasForeignKey<DuplicataParcela>(p => p.IdDuplicata);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}