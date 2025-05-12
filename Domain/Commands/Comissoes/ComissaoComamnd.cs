using SharedKernel.MediatR;

namespace Domain.Commands.Comissoes
{
    public class ComissaoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public Guid IdVendaRecebimentoTipo { get; set; }
        public Guid IdContaAReceber { get; set; }
        public Guid IdFatura { get; set; }
        public Guid IdVendedor { get; set; }
        public decimal Comissaoo { get; set; }
        public decimal ValorComissao { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public Guid IdStatus { get; set; }

        public ComissaoCommand()
        {

        }

        public ComissaoCommand(Guid id, Guid idVendaRecebimentoTipo, Guid idContaAReceber, Guid idFatura, Guid idVendedor, decimal comissao, decimal valorComissao,
                               decimal valorPago, DateTime dataEmissao, DateTime dataVencimento, DateTime dataPagamento, Guid idStatus)
        {
            Id = id;
            IdVendaRecebimentoTipo = idVendaRecebimentoTipo;
            IdContaAReceber = idContaAReceber;
            IdFatura = idFatura;
            IdVendedor = idVendedor;
            Comissaoo = comissao;
            ValorComissao = valorComissao;
            ValorPago = valorPago;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            DataPagamento = dataPagamento;
            IdStatus = idStatus;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}