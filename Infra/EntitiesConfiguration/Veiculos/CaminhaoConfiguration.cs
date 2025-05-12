using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class CaminhaoConfiguration : IEntityTypeConfiguration<Caminhao>
    {
        public void Configure(EntityTypeBuilder<Caminhao> builder)
        {
            builder.ToTable("TB_CAMINHAO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CAMINHAO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_CAMINHAO");

            builder.Property(p => p.CaminhaoCarreta)
               .HasColumnName("FL_CAMINHAO_CARRETA");

            builder.Property(p => p.Numero)
               .HasColumnName("NM_CAMINHAO");

            builder.Property(p => p.Placa)
               .HasColumnName("PLACA");

            builder.Property(p => p.Tara)
               .HasColumnName("TARA");

            builder.Property(p => p.CapacidadeKg)
               .HasColumnName("CAP_KG");

            builder.Property(p => p.CapacidadeM3)
               .HasColumnName("CAP_M3");

            builder.Property(p => p.IdPessoa)
               .HasColumnName("CD_PESSOA");

            builder.Property(p => p.IdTipoRodado)
               .HasColumnName("CD_TIPO_RODADO");

            builder.Property(p => p.IdTipoCarroceria)
               .HasColumnName("CD_TIPO_CARROCERIA");

            builder.Property(p => p.IdEstado)
               .HasColumnName("CD_ESTADO");

            builder.Property(p => p.Inativo)
               .HasColumnName("FL_INATIVO");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
