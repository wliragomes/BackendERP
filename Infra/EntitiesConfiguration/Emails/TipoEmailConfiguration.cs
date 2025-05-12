using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Emails;

namespace Infra.EntitiesConfiguration.Emails
{
    public class TipoEmailConfiguration : IEntityTypeConfiguration<TipoEmail>
    {
        public void Configure(EntityTypeBuilder<TipoEmail> builder)
        {
            builder.ToTable("TB_TIPO_EMAIL");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_TIPO_EMAIL")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.Descricao)
               .HasColumnName("NM_TIPO_EMAIL")
               .IsRequired();
        }
    }
}
