using Domain.Entities.Pessoas;
using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class FluxoCaixa : EntityId
    {
        public DateTime? Caixa { get; set; }
        public Guid? IdOperacao { get; set; }
        public Guid? IdCliente { get; set; }
        public int? CreditoDebito { get; set; }
        public int? ChequeCartao { get; set; }
        public Guid? IdBanco { get; set; }
        public Guid? IdCartao { get; set; }
        public string? Agencia { get; set; }
        public string? DigitoAgencia { get; set; }
        public string? Conta { get; set; }
        public string? DigitoConta { get; set; }
        public string? NChequeComprovanteCartao { get; set; }
        public DateTime ? DataVencimento { get; set; }
        public decimal? ValorLancamento { get; set; }
        public decimal? ValorSaldo { get; set; }
        public string? Historico { get; set; }
        public Guid? IdContaAReceber { get; set; }
        public Guid? IdContaAReceberPago { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual Banco Banco { get; set; }
        public FluxoCaixa(DateTime? caixa, Guid? idOperacao, Guid? idCliente, int? creditoDebito, int? chequeCartao, Guid ? idBanco, Guid ? idCartao, string? agencia,
                                 string? digitoAgencia, string? conta, string? digitoConta, string? nChequeComprovanteCartao, DateTime ? dataVencimento, decimal? valorLancamento, decimal? valorSaldo,
                                 string? historico, Guid? idContaAReceber, Guid? idContaAReceberPago)
        {
            SetId(Guid.NewGuid());
            Caixa = caixa;
            IdOperacao = idOperacao;
            IdCliente = idCliente;
            CreditoDebito = creditoDebito;
            ChequeCartao = chequeCartao;
            IdBanco = idBanco;
            IdCartao = idCartao;
            Agencia = agencia;
            DigitoAgencia = digitoAgencia;
            Conta = conta;
            DigitoConta = digitoConta;
            NChequeComprovanteCartao = nChequeComprovanteCartao;
            DataVencimento = dataVencimento;
            ValorLancamento = valorLancamento;
            ValorSaldo = valorSaldo;
            Historico = historico;
            IdContaAReceber = idContaAReceber;
            IdContaAReceberPago = idContaAReceberPago;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(DateTime? caixa, Guid? idOperacao, Guid? idCliente, int? creditoDebito, int? chequeCartao, Guid ? idBanco, Guid ? idCartao, string? agencia,
                                 string? digitoAgencia, string? conta, string? digitoConta, string? nChequeComprovanteCartao, DateTime ? dataVencimento, decimal? valorLancamento, decimal? valorSaldo,
                                 string? historico)
        {
            IdCliente = idCliente;
            Caixa = caixa;
            IdOperacao = idOperacao;
            IdCliente = idCliente;
            CreditoDebito = creditoDebito;
            ChequeCartao = chequeCartao;
            IdBanco = idBanco;
            IdCartao = idCartao;
            Agencia = agencia;
            DigitoAgencia = digitoAgencia;
            Conta = conta;
            DigitoConta = digitoConta;
            NChequeComprovanteCartao = nChequeComprovanteCartao;
            DataVencimento = dataVencimento;
            ValorLancamento = valorLancamento;
            ValorSaldo = valorSaldo;
            Historico = historico;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
