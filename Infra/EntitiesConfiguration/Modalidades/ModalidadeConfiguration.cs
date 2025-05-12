using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class ModalidadeConfiguration : IEntityTypeConfiguration<Modalidade>
    {
        public void Configure(EntityTypeBuilder<Modalidade> builder)
        {
            builder.ToTable("TB_MODALIDADE");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_MODALIDADE")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.DescricaoModalidade)
               .HasColumnName("DS_MODALIDADE");

            builder.Property(p => p.ExigeNumero)
               .HasColumnName("FL_EXIGE_NUMERO");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
