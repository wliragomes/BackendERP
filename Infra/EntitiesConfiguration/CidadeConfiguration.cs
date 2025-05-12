using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.EntitiesConfiguration
{
    public class CidadeConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("TB_CIDADE");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CIDADE")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.IdEstado)
               .HasColumnName("CD_ESTADO")
               .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NM_CIDADE")
                .IsRequired();

            builder.Property(p => p.PrISS)
              .HasColumnName("PR_ISS")
              .IsRequired();

            builder.Property(p => p.ValorMultiplicador)
              .HasColumnName("VL_MULTIPLICADOR")
              .IsRequired();

            builder.Property(p => p.CodIBGE)
             .HasColumnName("CD_IBGE")
             .IsRequired();

            builder.HasOne(c => c.Estado)
                .WithMany(e => e.Cidades)
                .HasForeignKey(c => c.IdEstado);

            // Adiciona o filtro global para ignorar entidades marcadas como removidas
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
