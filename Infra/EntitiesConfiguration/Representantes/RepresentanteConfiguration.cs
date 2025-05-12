using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class RepresentanteConfiguration : IEntityTypeConfiguration<Representante>
    {
        public void Configure(EntityTypeBuilder<Representante> builder)
        {
            builder.ToTable("TB_REPRESENTANTE");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_REPRESENTANTE")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IdPessoa)
                .HasColumnName("CD_PESSOA")
                .IsRequired();

            builder.Property(p => p.Externo)
                .HasColumnName("FL_EXTERNO");

            builder.Property(p => p.Comissao)
                .HasColumnName("VL_COMISSAO");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
