using Domain.Entities.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Produtos
{
    public class NcmConfiguration : IEntityTypeConfiguration<Ncm>
    {
        public void Configure(EntityTypeBuilder<Ncm> builder)
        {
            builder.ToTable("TB_NCM");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_NCM")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.NrNcm01)
               .HasColumnName("NR_NCM_01");

            builder.Property(p => p.NrNcm02)
               .HasColumnName("NR_NCM_02");

            builder.Property(p => p.NrNcm03)
               .HasColumnName("NR_NCM_03");

            builder.Property(p => p.NrNcmCompleta)
               .HasColumnName("NR_NCM_COMPLETA");

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_NCM");

            builder.Property(p => p.Aliquota)
               .HasColumnName("VL_ALIQUOTA");

            builder.Property(p => p.InsiteSt)
               .HasColumnName("FL_INSITE_ST");

            builder.Property(p => p.AliquotaSt)
               .HasColumnName("VL_ALIQUOTA_ST");

            // Adiciona o filtro global para ignorar entidades marcadas como removidas
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
