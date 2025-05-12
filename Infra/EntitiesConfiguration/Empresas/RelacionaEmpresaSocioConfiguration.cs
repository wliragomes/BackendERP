using Domain.Entities.Empresas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class RelacionaEmpresaSocioConfiguration : IEntityTypeConfiguration<RelacionaEmpresaSocio>
    {
        public void Configure(EntityTypeBuilder<RelacionaEmpresaSocio> builder)
        {           
            builder.ToTable("TB_RELACIONA_EMPRESA_SOCIO");

            builder.HasKey(p => new { p.IdEmpresa, p.IdSocio });            

            builder.Property(p => p.IdEmpresa)
                .HasColumnName("CD_EMPRESA")
                .IsRequired();           

            builder.Property(p => p.IdSocio)
                .HasColumnName("CD_PESSOA")
                .IsRequired();

            builder.HasOne(rpe => rpe.Empresa)
                .WithMany(p => p.RelacionaEmpresaSocio)
                .HasForeignKey(rpe => rpe.IdEmpresa);

            builder.HasOne(rpe => rpe.Pessoa)
                .WithMany(e => e.RelacionaEmpresaSocio)
                .HasForeignKey(rpe => rpe.IdSocio);
        }
    }
}
