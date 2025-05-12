using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class PlanoDeContasConfiguration : IEntityTypeConfiguration<PlanoDeContas>
    {
        public void Configure(EntityTypeBuilder<PlanoDeContas> builder)
        {
            builder.ToTable("TB_PLANO_CONTAS");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_PLANO_CONTAS")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.PlanoDeContasCompleto)
               .HasColumnName("CD_PLANO_CONTAS_COMPLETO");

            builder.Property(p => p.ContaPrincipal)
               .HasColumnName("CD_CONTA_PRINCIPAL");

            builder.Property(p => p.SubGrupo)
               .HasColumnName("CD_SUBGRUPO");

            builder.Property(p => p.Analitico)
               .HasColumnName("CD_ANALITICO");

            builder.Property(p => p.AnaliticoDetalhado)
               .HasColumnName("CD_ANALITICO_DETALHADO");

            builder.Property(p => p.Especifico)
               .HasColumnName("CD_ESPECIFICO");

            builder.Property(p => p.PositivoNegativo)
               .HasColumnName("FL_POSITIVO_NEGATIVO");

            builder.Property(p => p.Conta)
               .HasColumnName("DS_CONTA");

            builder.Property(p => p.Natureza)
               .HasColumnName("FL_NATUREZA");

            builder.Property(p => p.Nivel)
               .HasColumnName("FL_NIVEL");            

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
