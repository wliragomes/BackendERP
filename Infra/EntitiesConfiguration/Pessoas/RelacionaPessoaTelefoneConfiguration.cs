using Domain.Entities.Pessoas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EntitiesConfiguration.Pessoas
{
    public class RelacionaPessoaTelefoneConfiguration : IEntityTypeConfiguration<RelacionaPessoaTelefone>
    {
        public void Configure(EntityTypeBuilder<RelacionaPessoaTelefone> builder)
        {
            builder.ToTable("TB_RELACIONA_PESSOA_TELEFONE");

            // Configuração da chave composta
            builder.HasKey(rpe => new { rpe.IdPessoa, rpe.IdTelefone });

            builder.Property(p => p.IdPessoa)
               .HasColumnName("CD_PESSOA");

            builder.Property(p => p.IdTelefone)
                .HasColumnName("CD_TELEFONE");

            builder.HasOne(rpe => rpe.Pessoa)
                .WithMany(p => p.RelacionaPessoaTelefones)
                .HasForeignKey(rpe => rpe.IdPessoa);

            builder.HasOne(rpe => rpe.Telefone)
                .WithMany(e => e.RelacionaPessoaTelefones)
                .HasForeignKey(rpe => rpe.IdTelefone);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
