using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EntitiesConfiguration
{
    internal class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("TB_Estado");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_Estado")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.IdPais)
               .HasColumnName("CD_PAIS")
               .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NM_ESTADO");

            builder.Property(p => p.Sigla)
                .HasColumnName("SG_ESTADO");

            builder.Property(p => p.CodIBGE)
                .HasColumnName("CD_IBGE");

            builder.Property(p => p.AliquotaIcmsInterestadual)
                .HasColumnName("PR_ICMS_ALIQUOTA_INTERESTADUAL");

            builder.Property(p => p.AliquotaIcmsInterna)
                .HasColumnName("PR_ICMS_ALIQUOTA_INTERNA");

            builder.Property(p => p.AliquotaIcmsDiferenca)
                .HasColumnName("PR_ICMS_ALIQUOTA_DIFERENCA");

            builder.Property(p => p.AliquotaFundoPobreza)
                .HasColumnName("PR_FUNDO_POBREZA");

            builder.HasOne(c => c.Pais)
                .WithMany(e => e.Estados)
                .HasForeignKey(c => c.IdPais);

            // Adiciona o filtro global para ignorar entidades marcadas como removidas
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
