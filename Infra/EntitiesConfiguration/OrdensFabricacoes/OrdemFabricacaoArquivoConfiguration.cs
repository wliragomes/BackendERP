using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class OrdemFabricacaoArquivoConfiguration : IEntityTypeConfiguration<OrdemFabricacaoArquivo>
    {
        public void Configure(EntityTypeBuilder<OrdemFabricacaoArquivo> builder)
        {
            builder.ToTable("TB_ORDEM_FABRICACAO_ARQUIVO");

            builder.HasKey(p => new { p.IdOrdemFabricacao, p.SqArquivo });

            // Propriedades
            builder.Property(p => p.IdOrdemFabricacao)
                .HasColumnName("CD_ORDEM_FABRICACAO")
                .IsRequired();

            builder.Property(p => p.SqArquivo)
                .HasColumnName("SQ_ARQUIVO")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("DS_ARQUIVO");

            builder.Property(p => p.NomeOriginal)
                .HasColumnName("NM_ORIGINAL");

            builder.Property(p => p.Destino)
                .HasColumnName("NM_DESTSINO");

            builder.Property(p => p.EnderecoOriginal)
                .HasColumnName("DS_ENDERECO_ORIGINAL");

            builder.Property(p => p.EnderecoDestino)
                .HasColumnName("DS_ENDERECO_DESTINO");

            builder.Property(p => p.Arquivo)
                .HasColumnName("ARQUIVO");

            builder.HasOne(p => p.OrdemFabricacao)
                .WithMany(c => c.OrdemFabricacaoArquivo)
                .HasForeignKey(p => p.IdOrdemFabricacao);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
