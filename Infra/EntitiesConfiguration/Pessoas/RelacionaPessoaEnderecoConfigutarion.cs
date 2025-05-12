using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Pessoas;

namespace Infra.EntitiesConfiguration.Pessoas
{
    public class RelacionaPessoaEnderecoConfigutarion : IEntityTypeConfiguration<RelacionaPessoaEndereco>
    {
        public void Configure(EntityTypeBuilder<RelacionaPessoaEndereco> builder)
        {
            builder.ToTable("TB_RELACIONA_PESSOA_ENDERECO");

            // Configuração da chave composta
            builder.HasKey(rpe => new { rpe.IdPessoa, rpe.IdEndereco });

            builder.Property(p => p.IdPessoa)
               .HasColumnName("CD_PESSOA");

            builder.Property(p => p.IdEndereco)
                .HasColumnName("CD_ENDERECO");

            builder.HasOne(rpe => rpe.Pessoa)
                .WithMany(p => p.RelacionaPessoaEnderecos)
                .HasForeignKey(rpe => rpe.IdPessoa);

            builder.HasOne(rpe => rpe.Endereco)
                .WithMany(e => e.RelacionaPessoaEnderecos)
                .HasForeignKey(rpe => rpe.IdEndereco);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
