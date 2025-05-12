using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Pessoas;

namespace Infra.EntitiesConfiguration.Pessoas
{
    public class AnaliseCreditoConfiguration : IEntityTypeConfiguration<AnaliseCredito>
    {
        public void Configure(EntityTypeBuilder<AnaliseCredito> builder)
        {
            builder.ToTable("TB_ANALISE_CREDITO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_ANALISE_CREDITO")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.IdPessoa)
               .HasColumnName("CD_PESSOA");

            builder.Property(p => p.DataConsulta)
                .HasColumnName("DT_DATA_CONSULTA");

            builder.Property(p => p.OrgaoConsulta)
              .HasColumnName("DS_ORGAO_CONSULTA");

            builder.Property(p => p.IdResponsavelConsulta)
              .HasColumnName("CD_RESPONSAVEL_CONSULTA");

            builder.Property(p => p.Observacao)
             .HasColumnName("TX_OBSERVACAO");

            builder.HasOne(dc => dc.Pessoa)
               .WithMany(p => p.AnaliseCreditos)
               .HasForeignKey(dc => dc.IdPessoa)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.ResponsavelConsulta)
                .WithMany()
                .HasForeignKey(e => e.IdResponsavelConsulta);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
