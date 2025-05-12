using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Vendas;

namespace Infra.EntitiesConfiguration.Vendas
{
    public class TipoFechamentoConfiguration : IEntityTypeConfiguration<TipoFechamento>
    {
        public void Configure(EntityTypeBuilder<TipoFechamento> builder)
        {
            builder.ToTable("TB_TIPO_FECHAMENTO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_TIPO_FECHAMENTO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("NM_TIPO_FECHAMENTO");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
