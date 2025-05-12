using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Pessoas;

namespace Infra.EntitiesConfiguration.Pessoas
{
    public class DadosCobrancaConfiguration : IEntityTypeConfiguration<DadosCobranca>
    {
        public void Configure(EntityTypeBuilder<DadosCobranca> builder)
        {
            builder.ToTable("TB_DADOS_COBRANCA");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_DADOS_COBRANCA")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.IdPessoa)
               .HasColumnName("CD_PESSOA");

            builder.Property(p => p.Responsavel)
                .HasColumnName("NM_RESPONSAVEL");

            builder.HasOne(dc => dc.Pessoa)
               .WithMany(p => p.DadosCobrancas)
               .HasForeignKey(dc => dc.IdPessoa)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
