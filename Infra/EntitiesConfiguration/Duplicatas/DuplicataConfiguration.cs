using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class DuplicataConfiguration : IEntityTypeConfiguration<Duplicata>
    {
        public void Configure(EntityTypeBuilder<Duplicata> builder)
        {
            builder.ToTable("TB_DUPLICATA");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_DUPLICATA")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Parcelado)
               .HasColumnName("FL_PARCELADO");

            builder.Property(p => p.Numero)
               .HasColumnName("NR_NUM_DUPLICATA");

            builder.Property(p => p.Ano)
               .HasColumnName("NR_ANO_DUPLICATA");

            builder.Property(p => p.ValorTotal)
               .HasColumnName("VL_DUPLICATA_TOTAL");

            builder.Property(p => p.QtdParcelas)
               .HasColumnName("QT_PARCELA");

            builder.Property(p => p.DataEmissao)
               .HasColumnName("DT_EMISSAO");

            builder.Property(p => p.IdSacado)
               .HasColumnName("CD_PESSOA");

            builder.Property(p => p.Cep)
               .HasColumnName("NR_CEP");

            builder.Property(p => p.Endereco)
               .HasColumnName("DS_ENDERECO");

            builder.Property(p => p.IdCidade)
               .HasColumnName("CD_CIDADE");

            builder.Property(p => p.IdEstado)
               .HasColumnName("CD_UF");

            builder.Property(p => p.NumeroEndereco)
               .HasColumnName("NR_NUMERO");

            builder.Property(p => p.Complemento)
               .HasColumnName("DS_COMPLEMENTO");

            builder.Property(p => p.CepCobranca)
               .HasColumnName("NR_CEP_COBRANCA");

            builder.Property(p => p.EnderecoCobranca)
               .HasColumnName("DS_ENDERECO_COBRANCA");

            builder.Property(p => p.IdCidadeCobranca)
               .HasColumnName("CD_CIDADE_COBRANCA");

            builder.Property(p => p.IdEstadoCobranca)
               .HasColumnName("CD_UF_COBRANCA");

            builder.Property(p => p.NumeroEnderecoCobranca)
               .HasColumnName("NR_NUMERO_COBRANCA");

            builder.Property(p => p.ComplementoCobranca)
               .HasColumnName("DS_COMPLEMENTO_COBRANCA");

            builder.Property(p => p.Observacao)
               .HasColumnName("DS_OBSERVACAO");

            builder.HasOne(p => p.Pessoa)
                .WithOne(c => c.Duplicata)
                .HasForeignKey<Duplicata>(p => p.IdSacado);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
