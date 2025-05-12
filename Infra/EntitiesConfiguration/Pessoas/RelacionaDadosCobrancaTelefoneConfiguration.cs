using Domain.Entities.Pessoas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EntitiesConfiguration.Pessoas
{
    public class RelacionaDadosCobrancaTelefoneConfiguration : IEntityTypeConfiguration<RelacionaDadosCobrancaTelefone>
    {
        public void Configure(EntityTypeBuilder<RelacionaDadosCobrancaTelefone> builder)
        {
            builder.ToTable("TB_RELACIONA_DADOS_COBRANCA_TELEFONE");

            // Configuração da chave composta
            builder.HasKey(rpe => new { rpe.IdDadosCobranca, rpe.IdTelefone });

            builder.Property(p => p.IdDadosCobranca)
               .HasColumnName("CD_DADOS_COBRANCA");

            builder.Property(p => p.IdTelefone)
                .HasColumnName("CD_TELEFONE");

            builder.HasOne(rpe => rpe.DadosCobranca)
                .WithMany(p => p.RelacionaDadosCobrancaTelefones)
                .HasForeignKey(rpe => rpe.IdDadosCobranca);

            builder.HasOne(rpe => rpe.Telefone)
                .WithMany(e => e.RelacionaDadosCobrancaTelefones)
                .HasForeignKey(rpe => rpe.IdTelefone);


            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}