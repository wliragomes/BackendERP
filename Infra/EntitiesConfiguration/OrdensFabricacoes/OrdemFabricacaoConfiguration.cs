using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class OrdemFabricacaoConfiguration : IEntityTypeConfiguration<OrdemFabricacao>
    {
        public void Configure(EntityTypeBuilder<OrdemFabricacao> builder)
        {
            builder.ToTable("TB_ORDEM_FABRICACAO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_ORDEM_FABRICACAO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IdVenda)
               .HasColumnName("CD_VENDA");

            builder.Property(p => p.SqOrdemFabricacaoCodigo)
               .HasColumnName("SQ_ORDEM_FABRICACAO_CODIGO");

            builder.Property(p => p.SqOrdemFabricacaoAno)
               .HasColumnName("SQ_ORDEM_FABRICACAO_ANO");

            builder.Property(p => p.IdStatus)
               .HasColumnName("CD_STATUS");

            builder.Property(p => p.IdPessoa)
               .HasColumnName("CD_PESSOA");

            builder.Property(p => p.VidroModulado)
               .HasColumnName("PR_VIDRO_MODULADO");

            builder.Property(p => p.Chapa)
               .HasColumnName("FL_CHAPA");

            builder.Property(p => p.DataCriacao)
               .HasColumnName("DT_CRIACAO");

            builder.Property(p => p.DataEfetivacao)
               .HasColumnName("DT_EFETIVACAO");

            builder.Property(p => p.NomeContato)
               .HasColumnName("NM_CONTATO");

            builder.Property(p => p.Telefone)
               .HasColumnName("NR_TEL_CONTATO");

            builder.Property(p => p.Celular)
               .HasColumnName("NR_TEL_CONTATO_CELULAR");

            builder.Property(p => p.IdEnderecoEntrega)
               .HasColumnName("CD_ENDERECO_ENTREGA");

            builder.Property(p => p.Obra)
               .HasColumnName("DS_OBRA");

            builder.Property(p => p.Engenheiro)
               .HasColumnName("NM_ENGENHEIRO_RESPONSAVEL");

            builder.Property(p => p.Observacao)
               .HasColumnName("TX_OBSERVACAO");

            builder.Property(p => p.EtiquetaGrandeTemperado)
               .HasColumnName("FL_ETIQUETA_GRANDE_TEMPERADO");

            builder.Property(p => p.DescargaCliente)
               .HasColumnName("FL_DESCARGA_CONTA_CLIENTE");

            builder.Property(p => p.DiasEntrega)
               .HasColumnName("QT_DIAS_ENTREGA");

            builder.Property(p => p.DataEntrega)
               .HasColumnName("DT_ENTREGA");

            builder.HasOne(p => p.Pessoa)
                .WithOne(c => c.OrdemFabricacao) // Relação 1:1
                .HasForeignKey<OrdemFabricacao>(p => p.IdPessoa); // Define a chave estrangeira

            builder.HasOne(p => p.Venda)
                .WithOne(c => c.OrdemFabricacao)
                .HasForeignKey<OrdemFabricacao>(p => p.IdVenda);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
