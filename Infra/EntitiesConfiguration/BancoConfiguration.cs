using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class BancoConfiguration : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder.ToTable("TB_BANCO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_BANCO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("NM_BANCO");

            builder.Property(p => p.NaoSomar)
               .HasColumnName("FL_NAO_SOMAR");

            builder.Property(p => p.NumeroBanco)
               .HasColumnName("NR_BANCO");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
