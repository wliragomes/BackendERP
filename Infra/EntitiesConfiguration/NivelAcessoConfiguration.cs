using Domain.Entities.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class NivelAcessoConfiguration : IEntityTypeConfiguration<NivelAcesso>
    {
        public void Configure(EntityTypeBuilder<NivelAcesso> builder)
        {
            builder.ToTable("TB_NIVEL_ACESSO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_NIVEL_ACESSO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Codigo)
               .HasColumnName("CD_CODIGO_NIVEL_ACESSO");

            builder.Property(p => p.Nome)
               .HasColumnName("NM_NOME_NIVEL_ACESSO");

            // Adiciona o filtro global para ignorar entidades marcadas como removidas
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
