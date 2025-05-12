using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class MotivoReposicaoConfiguration : IEntityTypeConfiguration<MotivoReposicao>
    {
        public void Configure(EntityTypeBuilder<MotivoReposicao> builder)
        {
            builder.ToTable("TB_MOTIVO_REPOSICAO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_MOTIVO_REPOSICAO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Descricao)
               .HasColumnName("NM_MOTIVO_REPOSICAO");


            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
