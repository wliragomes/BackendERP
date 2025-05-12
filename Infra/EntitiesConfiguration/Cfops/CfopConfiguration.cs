using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Cfops;

namespace Infra.EntitiesConfiguration.Contatos
{
    public class CfopConfiguration : IEntityTypeConfiguration<Cfop>
    {
        public void Configure(EntityTypeBuilder<Cfop> builder)
        {
            builder.ToTable("TB_CFOP");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CFOP")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.CodigoAmigavel)
               .HasColumnName("CD_AMIGAVEL");

            builder.Property(p => p.CodigoLetra)
               .HasColumnName("CD_LETRA");

            builder.Property(p => p.CodigoCfopLetra)
               .HasColumnName("CD_CFOP_LETRA");

            builder.Property(p => p.DsResumida)
               .HasColumnName("DS_RESUMIDA");

            builder.Property(p => p.DsDetalhada)
               .HasColumnName("DS_DETALHADA");

            builder.Property(p => p.EntradaSaida)
               .HasColumnName("FL_ENTRADA_SAIDA");

            builder.Property(p => p.DadosAdicionaisIcms)
               .HasColumnName("TX_DADOS_ADICIONAIS_ICMS");

            builder.Property(p => p.DadosAdicionaisIpi)
               .HasColumnName("TX_DADOS_ADICIONAIS_IPI");

            builder.Property(p => p.IdCstIcmsOrigemMaterial)
               .HasColumnName("CD_CST_ICMS_ORIGEM_MATERIAL");

            builder.Property(p => p.IdCstIcms)
               .HasColumnName("CD_CST_ICMS");

            builder.Property(p => p.IdCstIpi)
               .HasColumnName("CD_CST_IPI");

            builder.Property(p => p.IdCstPis)
               .HasColumnName("CD_CST_PIS");

            builder.Property(p => p.IdCstCofins)
               .HasColumnName("CD_CST_COFINS");

            builder.Property(p => p.Comissao)
               .HasColumnName("FL_COMISSAO");

            builder.Property(p => p.Duplicata)
               .HasColumnName("FL_DUPLICATA");

            builder.Property(p => p.Resumo)
               .HasColumnName("FL_RESUMO");

            builder.Property(p => p.TaxaForaEstado)
               .HasColumnName("FL_TAXA_FORA_ESTADO");

            builder.Property(p => p.Retorno)
               .HasColumnName("FL_RETORNO");

            builder.Property(p => p.Devolucao)
               .HasColumnName("FL_DEVOLUCAO");

            builder.Property(p => p.Mercadoria)
               .HasColumnName("FL_MERCADORIA");

            builder.Property(p => p.Producao)
               .HasColumnName("FL_PRODUCAO");

            builder.Property(p => p.VendaOrdem)
               .HasColumnName("FL_VENDA_ORDEM");

            builder.Property(p => p.FaturaAutomatica)
               .HasColumnName("FL_FATURA_AUTOMATICA");

            builder.Property(p => p.ZerarValor)
               .HasColumnName("FL_ZERAR_VALOR");

            builder.Property(p => p.Difal)
               .HasColumnName("FL_DIFAL");

            builder.HasOne(p => p.CstIcmsOrigemMaterial)
                .WithMany()
                .HasForeignKey(p => p.IdCstIcmsOrigemMaterial);

            builder.HasOne(p => p.CST_ICMS)
                .WithMany()
                .HasForeignKey(p => p.IdCstIcms);

            builder.HasOne(p => p.CstIpi)
                .WithMany()
                .HasForeignKey(p => p.IdCstIpi);

            builder.HasOne(p => p.Pis)
                .WithMany()
                .HasForeignKey(p => p.IdCstPis);

            builder.HasOne(p => p.Cofins)
                .WithMany()
                .HasForeignKey(p => p.IdCstCofins);

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
