using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Telefones;

namespace Infra.EntitiesConfiguration.Telefones
{
    public class TipoTelefoneConfiguration : IEntityTypeConfiguration<TipoTelefone>
    {
        public void Configure(EntityTypeBuilder<TipoTelefone> builder)
        {
            builder.ToTable("TB_TIPO_TELEFONE");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_TIPO_TELEFONE")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.Descricao)
               .HasColumnName("NM_TIPO_TELEFONE")
               .IsRequired();
        }
    }
}
