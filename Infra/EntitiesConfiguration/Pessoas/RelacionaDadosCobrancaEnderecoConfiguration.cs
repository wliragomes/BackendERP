using Domain.Entities.Pessoas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EntitiesConfiguration.Pessoas
{
    public class RelacionaDadosCobrancaEnderecoConfiguration : IEntityTypeConfiguration<RelacionaDadosCobrancaEndereco>
    {
        public void Configure(EntityTypeBuilder<RelacionaDadosCobrancaEndereco> builder)
        {
            builder.ToTable("TB_RELACIONA_DADOS_COBRANCA_ENDERECO");

            // Configuração da chave composta
            builder.HasKey(rpe => new { rpe.IdDadosCobranca, rpe.IdEndereco });

            builder.Property(p => p.IdDadosCobranca)
               .HasColumnName("CD_DADOS_COBRANCA");

            builder.Property(p => p.IdEndereco)
                .HasColumnName("CD_ENDERECO");

            builder.HasOne(rpe => rpe.DadosCobranca)
                .WithMany(p => p.RelacionaDadosCobrancaEnderecos)
                .HasForeignKey(rpe => rpe.IdDadosCobranca);

            builder.HasOne(rpe => rpe.Endereco)
                .WithMany(e => e.RelacionaDadosCobrancaEnderecos)
                .HasForeignKey(rpe => rpe.IdEndereco);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}