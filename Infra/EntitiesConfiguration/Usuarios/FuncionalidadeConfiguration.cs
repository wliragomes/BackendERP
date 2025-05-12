using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Usuarios;

namespace Infra.EntitiesConfiguration.Usuarios
{
    public class FuncionalidadeConfiguration : IEntityTypeConfiguration<Funcionalidade>
    {
        public void Configure(EntityTypeBuilder<Funcionalidade> builder)
        {
            builder.ToTable("TB_FUNCIONALIDADE");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_FUNCIONALIDADE")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.Codigo)
               .HasColumnName("CD_CODIGO_FUNCIONALIDADE");

            builder.Property(p => p.Nome)
                .HasColumnName("NM_NOME_FUNCIONALIDADE");
        }
    }
}
