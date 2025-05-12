using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Enderecos;

namespace Infra.EntitiesConfiguration.Enderecos
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("TB_ENDERECO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_ENDERECO")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.IdTipoEndereco)
                .HasColumnName("CD_TIPO_ENDERECO");

            builder.Property(p => p.EnderecoDescricao)
                .HasColumnName("DS_ENDERECO");

            builder.Property(p => p.Numero)
                .HasColumnName("NR_NUMERO");

            builder.Property(p => p.Complemento)
                .HasColumnName("DS_COMPLEMENTO");

            builder.Property(p => p.IdCidade)
                .HasColumnName("CD_CIDADE");

            builder.Property(p => p.Bairro)
                .HasColumnName("NM_BAIRRO");

            builder.Property(p => p.IdUf)
                .HasColumnName("CD_UF");

            builder.Property(p => p.Cep)
                .HasColumnName("NR_CEP");

            builder.HasOne(c => c.TiposEndereco)
                .WithMany(e => e.Enderecos)
                .HasForeignKey(c => c.IdTipoEndereco);

            builder.HasOne(e => e.Cidade)
                .WithMany()
                .HasForeignKey(e => e.IdCidade);

            builder.HasOne(e => e.Estado)
                .WithMany()
                .HasForeignKey(e => e.IdUf);
        }
    }
}