using Domain.Entities.Pessoas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EntitiesConfiguration.Pessoas
{
    public class RelacionaPessoaEmailConfiguration : IEntityTypeConfiguration<RelacionaPessoaEmail>
    {
        public void Configure(EntityTypeBuilder<RelacionaPessoaEmail> builder)
        {
            builder.ToTable("TB_RELACIONA_PESSOA_EMAIL");

            // Configuração da chave composta
            builder.HasKey(rpe => new { rpe.IdPessoa, rpe.IdEmail });

            builder.Property(p => p.IdPessoa)
               .HasColumnName("CD_PESSOA");

            builder.Property(p => p.IdEmail)
                .HasColumnName("CD_EMAIL");

            builder.HasOne(rpe => rpe.Pessoa)
                .WithMany(p => p.RelacionaPessoaEmails)
                .HasForeignKey(rpe => rpe.IdPessoa);

            builder.HasOne(rpe => rpe.Email)
                .WithMany(e => e.RelacionaPessoaEmails)
                .HasForeignKey(rpe => rpe.IdEmail);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
