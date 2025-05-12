using Domain.Entities.Faturas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Faturas
{
    public class FaturaConfiguration : IEntityTypeConfiguration<Fatura>
    {
        public void Configure(EntityTypeBuilder<Fatura> builder)
        {
            builder.ToTable("TB_FATURA");

            // Chave primária
            builder.HasKey(f => f.Id);
            builder.HasIndex(f => f.Id).IsUnique();

            // Propriedades
            builder.Property(f => f.Id)
                .HasColumnName("CD_FATURA")
                .IsRequired();

            builder.Property(p => p.IdStatus)
               .HasColumnName("CD_STATUS");

            builder.Property(p => p.IdCliente)
               .HasColumnName("CD_CLIENTE");

            builder.Property(p => p.InformacoesAdicionais)
               .HasColumnName("TX_INFORMACOES_ADICIONAIS");

            builder.Property(p => p.InformacoesAdicionaisFisco)
               .HasColumnName("TX_INFORMACOES_ADICIONAIS_FISCO");

            builder.Property(p => p.RazaoSocial)
               .HasColumnName("DS_NOME_RAZAO_SOCIAL_CLIENTE");

            builder.Property(p => p.NaturezaOperacao)
               .HasColumnName("DS_NATUREZA_OPERACAO");

            builder.Property(p => p.CepEntrega) 
               .HasColumnName("NR_CEP_ENTREGA");

            builder.Property(p => p.EnderecoEntrega) 
               .HasColumnName("DS_ENDERECO_ENTREGA");

            builder.Property(p => p.NumeroEntrega) 
               .HasColumnName("NR_NUMERO_ENTREGA");

            builder.Property(p => p.ComplementoEntrega)
               .HasColumnName("DS_COMPLEMENTO_ENTREGA");

            builder.Property(p => p.IdUfEntrega)
               .HasColumnName("CD_UF_ENTREGA");

            builder.Property(p => p.IdCidadeEntrega)
               .HasColumnName("CD_CIDADE_ENTREGA");

            builder.Property(p => p.BairroEntrega)
               .HasColumnName("NM_BAIRRO_ENTREGA");


            builder.Property(p => p.CepCobranca) 
               .HasColumnName("NR_CEP_COBRANCA");

            builder.Property(p => p.EnderecoCobranca)
              .HasColumnName("DS_ENDERECO_COBRANCA");

            builder.Property(p => p.NumeroCobranca)
               .HasColumnName("NR_NUMERO_COBRANCA");

            builder.Property(p => p.ComplementoCobranca)
               .HasColumnName("DS_COMPLEMENTO_COBRANCA");

            builder.Property(p => p.IdUfCobranca)
               .HasColumnName("CD_UF_COBRANCA");

            builder.Property(p => p.IdCidadeCobranca)
               .HasColumnName("CD_CIDADE_COBRANCA");

            builder.Property(p => p.BairroCobranca)
               .HasColumnName("NM_BAIRRO_COBRANCA");

            builder.Property(p => p.IdTipoFrete) 
               .HasColumnName("CD_TIPO_FRETE");

            builder.Property(p => p.IdTransportadora) 
               .HasColumnName("CD_TRANSPORTADORA");
            
            builder.Property(p => p.PlacaVeiculoTransportadora) 
               .HasColumnName("NR_PLACA_VEICULO_TRANSPORTADORA");
            
            builder.Property(p => p.IdUfVeiculo) 
               .HasColumnName("CD_ESTADO_VEICULO");
            
            builder.Property(p => p.QuantidadeItens) 
               .HasColumnName("QT_ITENS");
            
            builder.Property(p => p.Especie) 
               .HasColumnName("DS_ESPECIE");
            
            builder.Property(p => p.NumeroPedido) 
               .HasColumnName("NR_PEDIDO");
            
            builder.Property(p => p.NumeroPedidoCliente) 
               .HasColumnName("NR_PEDIDO_CLIENTE");
            
            builder.Property(p => p.Marca) 
               .HasColumnName("DS_MARCA");
            
            builder.Property(p => p.PesoBruto) 
               .HasColumnName("VL_PESO_BRUTO");
            
            builder.Property(p => p.PesoLiquido) 
               .HasColumnName("VL_PESO_LIQUIDO");
            
            builder.Property(p => p.ValorFrete) 
               .HasColumnName("VL_FRETE");
            
            builder.Property(p => p.ValorSeguro) 
               .HasColumnName("VL_SEGURO");
            
            builder.Property(p => p.ValorOutrasDespesas) 
               .HasColumnName("VL_OUTRAS_DESPESAS");
            
            builder.Property(p => p.ValorTotalProdutos) 
               .HasColumnName("VL_TOTAL_PRODUTOS");
            
            builder.Property(p => p.ValorBaseCalculoIcms) 
               .HasColumnName("VL_BASE_CALCULO_ICMS");
            
            builder.Property(p => p.ValorIcms) 
               .HasColumnName("VL_ICMS");
            
            builder.Property(p => p.BaseCalculoPisCofins) 
               .HasColumnName("VL_BASE_CALCULO_PIS_COFINS");
            
            builder.Property(p => p.ValorIpi) 
               .HasColumnName("VL_IPI");
            
            builder.Property(p => p.ValorPis) 
               .HasColumnName("VL_PIS");
            
            builder.Property(p => p.ValorCofins) 
               .HasColumnName("VL_COFINS");
            
            builder.Property(p => p.BaseCalculoSt) 
               .HasColumnName("VL_BASE_CALCULO_ST");
            
            builder.Property(p => p.ValorSt) 
               .HasColumnName("VL_ST");
            
            builder.Property(p => p.PercentualDesconto) 
               .HasColumnName("VL_PERCENTUAL_DESCONTO");
            
            builder.Property(p => p.ValorDesconto) 
               .HasColumnName("VL_DESCONTO");
            
            builder.Property(p => p.ValorTotal) 
               .HasColumnName("VL_TOTAL");
            
            builder.Property(p => p.ValorDifal) 
               .HasColumnName("VL_DIFAL");

            // Relacionamento com FaturaItem (1 Fatura -> N FaturaItem)
            builder.HasMany(f => f.FaturaItem)
                .WithOne(i => i.Fatura)
                .HasForeignKey(i => i.IdFatura);

            // Relacionamento 1:1 com RelacionaFaturaVendaRecebimentoTipo
            builder.HasOne(f => f.RelacionaFaturaVendaRecebimentoTipo)
                .WithOne(r => r.Fatura)
                .HasForeignKey<RelacionaFaturaVendaRecebimentoTipo>(r => r.IdFatura)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(e => !e.Removed);
        }
    }
}
