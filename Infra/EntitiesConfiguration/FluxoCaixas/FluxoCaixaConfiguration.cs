using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class FluxoCaixaConfiguration : IEntityTypeConfiguration<FluxoCaixa>
    {
        public void Configure(EntityTypeBuilder<FluxoCaixa> builder)
        {
            builder.ToTable("TB_FLUXO_CAIXA");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_FLUXO_CAIXA")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IdCliente)
               .HasColumnName("CD_CLIENTE");

            builder.Property(p => p.Caixa)
               .HasColumnName("DT_CAIXA");

            builder.Property(p => p.IdOperacao)
               .HasColumnName("CD_OPERACAO");

            builder.Property(p => p.IdCliente)
               .HasColumnName("CD_CLIENTE");

            builder.Property(p => p.CreditoDebito)
               .HasColumnName("BT_CREDITO_DEBITO");

            builder.Property(p => p.ChequeCartao)
               .HasColumnName("BT_CHEQUE_CARTAO");

            builder.Property(p => p.IdBanco)
               .HasColumnName("CD_BANCO");

            builder.Property(p => p.IdCartao)
               .HasColumnName("CD_BANDEIRA_CARTAO");

            builder.Property(p => p.Agencia)
               .HasColumnName("NR_AGENCIA");

            builder.Property(p => p.DigitoAgencia)
               .HasColumnName("NR_AGENCIA_DIGITO");

            builder.Property(p => p.Conta)
               .HasColumnName("NR_CONTA");

            builder.Property(p => p.DigitoConta)
               .HasColumnName("NR_CONTA_DIGITO");

            builder.Property(p => p.NChequeComprovanteCartao)
               .HasColumnName("NR_CHEQUE_COMPROVANTE_CARTAO");

            builder.Property(p => p.DataVencimento)
               .HasColumnName("DT_VENCIMENTO");

            builder.Property(p => p.ValorLancamento)
              .HasColumnName("VL_LANCAMENTO");

            builder.Property(p => p.ValorSaldo)
               .HasColumnName("VL_SALDO");

            builder.Property(p => p.Historico)
               .HasColumnName("TX_HISTORICO");

            builder.Property(p => p.IdContaAReceber)
               .HasColumnName("CD_CONTA_RECEBER");

            builder.Property(p => p.IdContaAReceberPago)
               .HasColumnName("CD_CONTA_RECEBER_PAGO");

            builder.HasOne(p => p.Pessoa)
                .WithOne(c => c.FluxoCaixa) // Relação 1:1
                .HasForeignKey<FluxoCaixa>(p => p.IdCliente); // Define a chave estrangeira

            builder.HasOne(p => p.Banco)
                .WithOne(c => c.FluxoCaixa) // Relação 1:1
                .HasForeignKey<FluxoCaixa>(p => p.IdBanco); // Define a chave estrangeira

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
