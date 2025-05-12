using Domain.Entities.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class FuncionalidadeConfiguration : IEntityTypeConfiguration<Funcionalidade>
    {
        public void Configure(EntityTypeBuilder<Funcionalidade> builder)
        {
            builder.ToTable("TB_FUNCIONALIDADE");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_FUNCIONALIDADE")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Codigo)               
               .HasColumnName("CD_CODIGO_FUNCIONALIDADE");

            builder.Property(p => p.Nome)           
               .HasColumnName("NM_NOME_FUNCIONALIDADE");

            // Adiciona o filtro global para ignorar entidades marcadas como removidas
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
