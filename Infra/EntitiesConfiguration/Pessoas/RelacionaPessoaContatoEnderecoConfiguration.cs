using Domain.Entities.Pessoas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Pessoas
{
    public class RelacionaPessoaContatoEnderecoConfiguration : IEntityTypeConfiguration<RelacionaPessoaContatoEndereco>
    {
        public void Configure(EntityTypeBuilder<RelacionaPessoaContatoEndereco> builder)
        {
            builder.ToTable("TB_RELACIONA_CONTATO_ENDERECO");

            // Configuração da chave composta
            builder.HasKey(rpe => new { rpe.IdContato, rpe.IdEndereco });

            builder.Property(p => p.IdContato)
                .HasColumnName("CD_CONTATO");

            builder.Property(p => p.IdEndereco)
                .HasColumnName("CD_ENDERECO");

            builder.HasOne(rpe => rpe.Contato)
                .WithMany(p => p.RelacionaPessoaContatoEnderecos)
                .HasForeignKey(rpe => rpe.IdContato)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rpe => rpe.Endereco)
                .WithMany(e => e.RelacionaPessoaContatoEnderecos)
                .HasForeignKey(rpe => rpe.IdEndereco)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
