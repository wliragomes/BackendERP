using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Vendas
{
    public class TipoFreteConfiguration : IEntityTypeConfiguration<TipoFrete>
    {
        public void Configure(EntityTypeBuilder<TipoFrete> builder)
        {
            builder.ToTable("TB_TIPO_FRETE");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_TIPO_FRETE")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.NFrete)
               .HasColumnName("NR_TIPO_FRETE")
               .IsRequired();

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_TIPO_FRETE")
               .IsRequired();

            builder.Property(p => p.DescricaoResumida)
              .HasColumnName("DS_TIPO_FRETE_RESUMIDO")
              .IsRequired();

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
