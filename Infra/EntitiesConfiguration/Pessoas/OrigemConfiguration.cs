using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.EntitiesConfiguration.Pessoas
{
    public class OrigemConfiguration : IEntityTypeConfiguration<Origem>
    {
        public void Configure(EntityTypeBuilder<Origem> builder)
        {
            builder.ToTable("TB_ORIGEM");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_ORIGEM")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_ORIGEM")
               .IsRequired();

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
