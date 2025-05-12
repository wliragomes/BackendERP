using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Usuarios;

namespace Infra.EntitiesConfiguration.Usuarios
{
    public class RelacionaUsuarioFuncionalidadeConfiguration : IEntityTypeConfiguration<RelacionaUsuarioFuncionalidadeNivelAcesso>
    {
        public void Configure(EntityTypeBuilder<RelacionaUsuarioFuncionalidadeNivelAcesso> builder)
        {
            builder.ToTable("TB_RELACIONA_USUARIO_FUNCIONALIDADE_NIVEL_ACESSO");

            // Configuração da chave composta
            builder.HasKey(rpe => new { rpe.IdUsuario, rpe.IdFuncionalidade, rpe.IdNivelAcesso });

            builder.Property(p => p.IdUsuario)
               .HasColumnName("CD_USUARIO");

            builder.Property(p => p.IdFuncionalidade)
                .HasColumnName("CD_FUNCIONALIDADE");

            builder.Property(p => p.IdNivelAcesso)
                .HasColumnName("CD_NIVEL_ACESSO");

            builder.HasOne(rpe => rpe.Usuario)
                .WithMany(p => p.RelacionaUsuarioFuncionalidadeNivelAcesso)
                .HasForeignKey(rpe => rpe.IdUsuario);

            builder.HasOne(rpe => rpe.Funcionalidade)
                .WithMany(p => p.RelacionaUsuarioFuncionalidadeNivelAcesso)
                .HasForeignKey(rpe => rpe.IdFuncionalidade);

            builder.HasOne(rpe => rpe.NivelAcesso)
                .WithMany(p => p.RelacionaUsuarioFuncionalidadeNivelAcesso)
                .HasForeignKey(rpe => rpe.IdNivelAcesso);
        }
    }
}