using Domain.Entities.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Usuarios
{
    internal class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("TB_USUARIO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_USUARIO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.UserName)
               .HasColumnName("NM_USUARIO");

            builder.Property(p => p.Senha)
               .HasColumnName("CD_SENHA");

            builder.Property(p => p.IdPessoa)
                .HasColumnName("CD_PESSOA")
                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnName("Status");

            builder.Property(x => x.UnblockCode)
                .HasColumnName("CD_CODIGO_DESBLOQUEIO");

            builder.Property(x => x.UnBlockCodeExpire)
                .HasColumnName("DT_EXPIRACAO_CODIGO_DESBLOQUEIO");

            builder.Property(p => p.LastLoginDetailsMobile)
                .HasColumnName("DT_ULTIMO_LOGIN_CELULAR");

            builder.Property(p => p.LastLoginDetailsApis)
                .HasColumnName("DT_ULTIMO_LOGIN_API");

            builder.Property(p => p.Tentativas)
               .HasColumnName("NR_TENTATIVAS")
               .HasDefaultValue(0);

            builder.Property(p => p.Blocked)
                .HasColumnName("NR_BLOQUEADO")
                .HasDefaultValue((short)0);

            builder.Property(p => p.LastLoginDetailsWeb)
                .HasColumnName("DT_ULTIMO_LOGIN_WEB");

            builder.Property(p => p.LastPasswordCreation)
                .HasColumnName("DT_ULTIMA_SENHA_CRIADA");

            builder.Property(p => p.SpecialPermission)
                .HasColumnName("FL_PERMISSAO_ESPECIAL");

            builder.Property(p => p.EmailRecovery)
                .HasColumnName("DS_EMAIL_RECUPERACAO")
                .HasMaxLength(100);

            builder.Property(p => p.PhoneRecovery)
                .HasColumnName("DS_TELEFONE_RECUPERACAO")
                .HasMaxLength(100);

            builder.HasOne(u => u.Pessoa)
                .WithOne(p => p.Usuarios)
                .HasForeignKey<Users>(u => u.IdPessoa)  // Mapeia para a coluna CD_PESSOA no banco
                .HasConstraintName("FK_Usuario_Pessoa")  // Nome da constraint, se necessário
                .IsRequired(false);  // Uma pessoa pode ou não ter um usuário



            // Adiciona o filtro global para ignorar entidades marcadas como removidas
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
