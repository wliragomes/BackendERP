using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class FaturaParametroConfiguration : IEntityTypeConfiguration<FaturaParametro>
    {
        public void Configure(EntityTypeBuilder<FaturaParametro> builder)
        {
            builder.ToTable("TB_FATURA_PARAMETRO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_FATURA_PARAMETRO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Modelo)
               .HasColumnName("IN_MODELO");

            builder.Property(p => p.Serie)
               .HasColumnName("IN_SERIE");

            builder.Property(p => p.PrimeiroNumero)
               .HasColumnName("NR_PRIMEIRO_NUMERO");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
