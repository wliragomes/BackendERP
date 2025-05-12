using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Emails;

namespace Infra.EntitiesConfiguration.Emails
{
    public class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ToTable("TB_EMAIL");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_EMAIL")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.IdTipoEmail)
                .HasColumnName("CD_TIPO_EMAIL");

            builder.Property(p => p.EnderecoEmail)
                .HasColumnName("NM_EMAIL");

            builder.HasOne(c => c.TiposEmail)
                .WithMany(e => e.Emails)
                .HasForeignKey(c => c.IdTipoEmail);
        }
    }
}