using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("TB_PROJETO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_PROJETO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("NM_PROJETO");

            builder.Property(p => p.Apitar)
               .HasColumnName("FL_APITAR");

            builder.Property(p => p.Tarja)
               .HasColumnName("FL_TARJA");

            builder.Property(p => p.Agrupar)
               .HasColumnName("FL_AGRUPAR");

            builder.Property(p => p.FProjeto)
               .HasColumnName("FL_PROJETO");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
