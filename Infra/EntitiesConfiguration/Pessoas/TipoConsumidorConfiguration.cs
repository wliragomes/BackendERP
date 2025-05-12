using Domain.Entities.Pessoas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class TipoConsumidorConfiguration : IEntityTypeConfiguration<TipoConsumidor>
    {
        public void Configure(EntityTypeBuilder<TipoConsumidor> builder)
        {
            builder.ToTable("TB_TIPO_CONSUMIDOR");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_TIPO_CONSUMIDOR")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("NM_TIPO_CONSUMIDOR");

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_TIPO_CONSUMIDOR");

            builder.Property(p => p.SomaItens)
               .HasColumnName("FL_SOMA_ITENS");

            builder.Property(p => p.SomaDespesasBaseIcms)
               .HasColumnName("FL_SOMA_DESPESAS_BASE_ICMS");

            builder.Property(p => p.SomaIpiBaseIcms)
               .HasColumnName("FL_SOMA_IPI_BASE_ICMS");

            builder.Property(p => p.SomaDespesasBaseSt)
               .HasColumnName("FL_SOMA_DESPESAS_BASE_ST");

            builder.Property(p => p.SomaIpiBaseSt)
               .HasColumnName("FL_SOMA_IPI_BASE_ST");            

            builder.Property(p => p.SomaStBaseIcms)
               .HasColumnName("FL_SOMA_ST_BASE_ICMS");            

            builder.Property(p => p.Difal)
               .HasColumnName("FL_DIFAL");         

            builder.Property(p => p.SubstituicaoIcms)
               .HasColumnName("FL_SUBSTITUICAO_ICMS");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
