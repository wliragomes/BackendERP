using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Enderecos;

namespace Infra.EntitiesConfiguration.Enderecos
{
    public class TipoEnderecoConfiguration : IEntityTypeConfiguration<TipoEndereco>
    {
        public void Configure(EntityTypeBuilder<TipoEndereco> builder)
        {
            builder.ToTable("TB_TIPO_ENDERECO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_TIPO_ENDERECO")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_TIPO_ENDERECO")
               .IsRequired();
        }
    }
}
