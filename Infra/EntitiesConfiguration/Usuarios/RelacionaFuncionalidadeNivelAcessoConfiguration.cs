using Domain.Entities.Usuarios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EntitiesConfiguration.Usuarios
{
    public class RelacionaFuncionalidadeNivelAcessoConfiguration : IEntityTypeConfiguration<RelacionaFuncionalidadeNivelAcesso>
    {
        public void Configure(EntityTypeBuilder<RelacionaFuncionalidadeNivelAcesso> builder)
        {
            builder.ToTable("TB_RELACIONA_FUNCIONALIDADE_NIVEL_ACESSO");

            // Configuração da chave composta
            builder.HasKey(rpe => new { rpe.IdFuncionalidade, rpe.IdNivelAcesso });

            builder.Property(p => p.IdFuncionalidade)
                .HasColumnName("CD_FUNCIONALIDADE");

            builder.Property(p => p.IdNivelAcesso)
                .HasColumnName("CD_NIVEL_ACESSO");

            builder.HasOne(rpe => rpe.Funcionalidade)
                .WithMany(p => p.RelacionaFuncionalidadeNivelAcesso)
                .HasForeignKey(rpe => rpe.IdFuncionalidade);

            builder.HasOne(rpe => rpe.NivelAcesso)
                .WithMany(p => p.RelacionaFuncionalidadeNivelAcesso)
                .HasForeignKey(rpe => rpe.IdNivelAcesso);
        }
    }
}