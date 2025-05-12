using Domain.Entities.Empresas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class RelacionaEmpresaFaturaParametroConfiguration : IEntityTypeConfiguration<RelacionaEmpresaFaturaParametro>
    {
        public void Configure(EntityTypeBuilder<RelacionaEmpresaFaturaParametro> builder)
        {
            builder.ToTable("TB_RELACIONA_EMPRESA_FATURA_PARAMETRO");

            builder.HasKey(p => new { p.IdEmpresa, p.IdFaturaParametro });

            builder.Property(p => p.IdEmpresa)
                .HasColumnName("CD_EMPRESA")
                .IsRequired();

            builder.Property(p => p.IdFaturaParametro)
                .HasColumnName("CD_FATURA_PARAMETRO")
                .IsRequired();   

            builder.HasOne(rpe => rpe.Empresa)
                .WithMany(p => p.RelacionaEmpresaFaturaParametro)
                .HasForeignKey(rpe => rpe.IdEmpresa);

            builder.HasOne(rpe => rpe.FaturaParametro)
                .WithMany(e => e.RelacionaEmpresaFaturaParametro)
                .HasForeignKey(rpe => rpe.IdFaturaParametro);
        }
    }
}

