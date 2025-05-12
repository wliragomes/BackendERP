using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class ChapaConfiguration : IEntityTypeConfiguration<Chapa>
    {
        public void Configure(EntityTypeBuilder<Chapa> builder)
        {
            builder.ToTable("TB_CHAPA");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CHAPA")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_CHAPA");

            builder.Property(p => p.Altura)
               .HasColumnName("NR_ALTURA");

            builder.Property(p => p.Largura)
               .HasColumnName("NR_LARGURA");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
