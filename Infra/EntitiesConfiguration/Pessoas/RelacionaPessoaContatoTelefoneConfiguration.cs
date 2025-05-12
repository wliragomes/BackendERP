using Domain.Entities.Pessoas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EntitiesConfiguration.Pessoas
{
    public class RelacionaPessoaContatoTelefoneConfiguration : IEntityTypeConfiguration<RelacionaPessoaContatoTelefone>
    {
        public void Configure(EntityTypeBuilder<RelacionaPessoaContatoTelefone> builder)
        {
            builder.ToTable("TB_RELACIONA_CONTATO_TELEFONE");

            // Configuração da chave composta
            builder.HasKey(rpe => new { rpe.IdContato, rpe.IdTelefone });

            builder.Property(p => p.IdContato)
                .HasColumnName("CD_CONTATO");

            builder.Property(p => p.IdTelefone)
                .HasColumnName("CD_TELEFONE");

            builder.HasOne(rpe => rpe.Contato)
                .WithMany(p => p.RelacionaPessoaContatoTelefones)
                .HasForeignKey(rpe => rpe.IdContato)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rpe => rpe.Telefone)
                .WithMany(e => e.RelacionaPessoaContatoTelefones)
                .HasForeignKey(rpe => rpe.IdTelefone)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
