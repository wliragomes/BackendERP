using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class AcabamentoConfiguration : IEntityTypeConfiguration<Acabamento>
    {
        public void Configure(EntityTypeBuilder<Acabamento> builder)
        {
            builder.ToTable("TB_ACABAMENTO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_ACABAMENTO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_ACABAMENTO");

            builder.Property(p => p.Tolerancia)
               .HasColumnName("FL_TOLERANCIA");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
