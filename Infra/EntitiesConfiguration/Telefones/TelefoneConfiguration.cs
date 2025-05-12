using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Telefones;

namespace Infra.EntitiesConfiguration.Telefones
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("TB_TELEFONE");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_TELEFONE")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.IdTipoTelefone)
                .HasColumnName("CD_TIPO_TELEFONE");

            builder.Property(p => p.Numero)
                .HasColumnName("NR_NUMERO");

            builder.HasOne(c => c.TiposTelefone)
                .WithMany(e => e.Telefones)
                .HasForeignKey(c => c.IdTipoTelefone);
        }
    }
}