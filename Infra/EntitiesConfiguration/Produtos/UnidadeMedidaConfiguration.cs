using Domain.Entities.Produtos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EntitiesConfiguration.Produtos
{
    public class UnidadeMedidaConfiguration : IEntityTypeConfiguration<UnidadeMedida>
    {
        public void Configure(EntityTypeBuilder<UnidadeMedida> builder)
        {
            builder.ToTable("TB_UNIDADE_MEDIDA");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_UNIDADE_MEDIDA")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.Nome)
               .HasColumnName("NM_UNIDADE_MEDIDA");

            builder.Property(p => p.Sigla)
               .HasColumnName("SG_UNIDADE_MEDIDA");

            builder.Property(p => p.CasasDecimais)
               .HasColumnName("NR_CASAS_DECIMAIS");

            // Adiciona o filtro global para ignorar entidades marcadas como removidas
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
