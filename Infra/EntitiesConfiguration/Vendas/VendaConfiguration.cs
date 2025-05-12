using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.Vendas;
using Domain.Entities.Faturas;
using Domain.Entities;
using Domain.Entities.VendasItem;

namespace Infra.EntitiesConfiguration.Vendas
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("TB_VENDA");
            builder.HasKey(v => v.Id);
            builder.HasIndex(v => v.Id).IsUnique();

            builder.Property(v => v.Id)
                .HasColumnName("CD_VENDA")
                .IsRequired();

            builder.Property(v => v.IdEmpresa)
                .HasColumnName("CD_EMPRESA");

            builder.Property(v => v.CodigoVenda)
                .HasColumnName("SQ_VENDA_CODIGO");

            builder.Property(v => v.AnoVenda)
                .HasColumnName("SQ_VENDA_ANO");

            builder.Property(v => v.Release)
                .HasColumnName("SQ_RELEASE");

            builder.Property(v => v.IdStatus)
                .HasColumnName("CD_STATUS");

            builder.Property(v => v.IdStatus)
                .HasColumnName("CD_STATUS");

            builder.Property(v => v.DataCriacaoOrcamento)
                .HasColumnName("DT_CRIACAO_ORCAMENTO");

            builder.Property(v => v.DataCriacaoPedido)
                .HasColumnName("DT_CRIACAO_PEDIDO");

            builder.Property(v => v.DataConversaoPedido)
                .HasColumnName("DT_CONVERSAO_PEDIDO");

            builder.Property(v => v.FechamentoPedido)
                .HasColumnName("FL_FECHAMENTO_PEDIDO");

            builder.Property(v => v.DataFechamentoPedido)
                .HasColumnName("DT_FECHAMENTO_PEDIDO");

            builder.Property(v => v.ValidadeOrcamento)
                .HasColumnName("DT_VALIDADE_ORCAMENTO");

            builder.Property(v => v.ValidadePedido)
                .HasColumnName("DT_VALIDADE_PEDIDO");

            builder.Property(v => v.FaturaManual)
                .HasColumnName("FL_FATURA_MANUAL");

            builder.Property(v => v.PedidoGuardian)
                .HasColumnName("DS_PEDIDO_GUARDIAN");

            builder.Property(v => v.LancarOf)
                .HasColumnName("FL_PRODUTO_OF");

            builder.Property(v => v.SuprimiVendedor)
                .HasColumnName("FL_SUPRIMIR_VENDEDOR");

            builder.Property(v => v.SuprimirTotal)
                .HasColumnName("FL_SUPRIMIR_TOTAL");

            builder.Property(v => v.ComIpi)
                .HasColumnName("FL_COM_IPI");

            builder.Property(v => v.ComFrete)
                .HasColumnName("FL_COM_FRETE");

            builder.Property(v => v.VendaEntregaFutura)
               .HasColumnName("FL_VENDA_ENTREGA_FUTURA");

            builder.Property(v => v.MensagemFrete)
                .HasColumnName("DS_MENSAGEM_FRETE");

            builder.Property(v => v.IdCliente)
                .HasColumnName("CD_CLIENTE");

            builder.Property(v => v.IdResponsavelCompra)
               .HasColumnName("CD_RESPONSAVEL_COMPRA");

            builder.Property(v => v.IdConstrutora)
                .HasColumnName("CD_CONSTRUTORA");

            builder.Property(v => v.NomeContato)
                .HasColumnName("NM_CONTATO");

            builder.Property(v => v.EmailContato)
                .HasColumnName("DS_EMAIL_CONTATO");

            builder.Property(v => v.TelefoneContato)
                .HasColumnName("NR_TELEFONE_CONTATO");

            builder.Property(v => v.IdEnderecoEntrega)
                .HasColumnName("CD_ENDERECO_ENTREGA");

            builder.Property(v => v.IdEnderecoCobranca)
                .HasColumnName("CD_ENDERECO_COBRANCA");

            builder.Property(v => v.IdVendedor)
                .HasColumnName("CD_VENDEDOR");

            builder.Property(v => v.DescricaoObra)
                .HasColumnName("DS_OBRA");

            builder.Property(v => v.Engenheiro)
                .HasColumnName("NM_ENGENHEIRO"); //ToDo Verificar por que não tem esse campo no front

            builder.Property(v => v.IdTransportadora)
                .HasColumnName("CD_TRANSPORTADORA");

            builder.Property(v => v.PlacaVeiculoTransportadora)
                .HasColumnName("NR_PLACA_VEICULO_TRANSPORTADORA");

            builder.Property(v => v.IdUfVeiculo)
                .HasColumnName("CD_ESTADO_VEICULO ");

            builder.Property(p => p.Apfe)
                .HasColumnName("VL_ARREDONDAMENTO_FORA_ESQUADRO");

            builder.Property(p => p.NomeProjeto)
                .HasColumnName("NM_PROJETO");

            builder.Property(v => v.EnvioMedidas)
                .HasColumnName("DT_ENVIO_MEDIDA");

            builder.Property(p => p.InicioEntrega)
                .HasColumnName("DT_INICIO_ENTREGA");

            builder.Property(p => p.TerminoEntrega)
                .HasColumnName("DT_FINAL_ENTREGA");

            builder.Property(v => v.Observacao)
                .HasColumnName("TX_OBSERVACAO");

            builder.Property(v => v.ImpressaoEspecial)
                .HasColumnName("FL_IMPRESSAO_ESPECIAL");

            builder.Property(i => i.Difal)
                .HasColumnName("FL_DIFAL");

            builder.Property(p => p.FretesPrevistos)
                .HasColumnName("QT_FRETE");

            builder.Property(v => v.PrecoCadaFrete)
                .HasColumnName("VL_PRECO_CADA_FRETE");

            builder.Property(v => v.NaturezaOperacao)
                .HasColumnName("DS_NATUREZA_OPERACAO");

            builder.Property(p => p.InformacoesAdicionais)
               .HasColumnName("TX_INFORMACOES_ADICIONAIS");

            builder.Property(p => p.InformacoesAdicionaisFisco)
               .HasColumnName("TX_INFORMACOES_ADICIONAIS_FISCO");

            builder.Property(p => p.ValorFrete)
                .HasColumnName("VL_FRETE");

            builder.Property(i => i.ValorSeguro)
                .HasColumnName("VL_SEGURO");

            builder.Property(i => i.ValorOutrasDespesas)
                .HasColumnName("VL_OUTRAS_DESPESAS");

            builder.Property(i => i.ValorBaseCalculoIcms)
                .HasColumnName("VL_BASE_CALCULO_ICMS");

            builder.Property(i => i.ValorIcms)
                .HasColumnName("VL_ICMS");

            builder.Property(i => i.ValorIpi)
                .HasColumnName("VL_IPI");

            builder.Property(v => v.PercentualPis)
                .HasColumnName("PR_PIS");

            builder.Property(v => v.ValorPis)
                .HasColumnName("VL_PIS");

            builder.Property(v => v.PercentualCofins)
                .HasColumnName("PR_COFINS");

            builder.Property(v => v.ValorCofins)
                .HasColumnName("VL_COFINS");

            builder.Property(v => v.BaseCalculoSt)
                .HasColumnName("VL_BASE_CALCULO_ST");

            builder.Property(v => v.ValorSt)
                .HasColumnName("VL_ST");

            builder.Property(v => v.ValorTotalProdutos)
                .HasColumnName("VL_TOTAL_PRODUTO");

            builder.Property(i => i.ValorTotal)
                .HasColumnName("VL_TOTAL");

            builder.Property(v => v.PedidoCliente)
               .HasColumnName("DS_PEDIDO_CLIENTE");

            builder.Property(v => v.IdTipoFrete)
               .HasColumnName("CD_TIPO_FRETE");

            builder.Property(v => v.Especie)
               .HasColumnName("DS_ESPECIE");

            builder.Property(p => p.QuantidadeItens)
               .HasColumnName("QT_ITENS");

            builder.Property(v => v.PesoBruto)
               .HasColumnName("VL_PESO_BRUTO");

            builder.Property(v => v.PesoLiquido)
               .HasColumnName("VL_PESO_LIQUIDO");

            builder.Property(v => v.Cancelado)
                .HasColumnName("FL_CANCELADO");

            builder.Property(v => v.DataCancelamento)
                .HasColumnName("DT_CANCELAMENTO");

            builder.Property(v => v.IdMotivoCancelamentoPedidoOrcamento)
                .HasColumnName("CD_MOTIVO_CANCELAMENTO_PEDIDO_ORCAMENTO");

            builder.Property(v => v.MotivoCancelamentoOutrosMotivos)
                .HasColumnName("DS_MOTIVO_CANCELAMENTO_OUTROS_MOTIVOS");

            builder.Property(v => v.Retira)
             .HasColumnName("FL_RETIRA");

            builder.Property(v => v.Entrega)
                .HasColumnName("FL_ENTREGA");

            builder.Property(v => v.UsoConsumo)
                .HasColumnName("FL_USO_CONSUMO");

            builder.Property(v => v.IdTipoFechamento)
                .HasColumnName("CD_TIPO_FECHAMENTO");

            builder.Property(v => v.Amostra)
                .HasColumnName("FL_AMOSTRA");

            builder.HasOne(p => p.EnderecoCobranca)
                .WithMany()
                .HasForeignKey(p => p.IdEnderecoCobranca);

            builder.HasOne(p => p.EnderecoEntrega)
                .WithMany()
                .HasForeignKey(p => p.IdEnderecoEntrega);

            builder.HasOne(p => p.Pessoa)
                .WithMany()
                .HasForeignKey(p => p.IdCliente);

            builder.HasOne(p => p.Status)
                .WithMany()
                .HasForeignKey(p => p.IdStatus);

            // Relacionamento 1:1 com RelacionaFaturaVendaRecebimentoTipo
            builder.HasOne(v => v.RelacionaFaturaVendaRecebimentoTipo)
                .WithOne(r => r.Venda)
                .HasForeignKey<RelacionaFaturaVendaRecebimentoTipo>(r => r.IdVenda)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.ImpressaoEspecialTexto)
                .WithOne(r => r.Venda)
                .HasForeignKey<ImpressaoEspecial>(r => r.IdVenda);

            builder.HasOne(p => p.Empresa)
                .WithOne(c => c.Venda) // Relação 1:1
                .HasForeignKey<Venda>(p => p.IdEmpresa); // Define a chave estrangeira


            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}

           
