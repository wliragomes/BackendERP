using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class ObraProjetoConfiguration : IEntityTypeConfiguration<ObraProjeto>
    {
        public void Configure(EntityTypeBuilder<ObraProjeto> builder)
        {
            builder.ToTable("TB_OBRA_TIPO_PROJETO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_OBRA_TIPO_PROJETO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("NM_OBRA_TIPO_PROJETO");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
