using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Comissao : EntityId
    {
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

        public Comissao (){}
        public Comissao(Guid idVendaRecebimentoTipo, Guid idContaAReceber, Guid idFatura, Guid idVendedor, decimal comissao, decimal valorComissao,
                        decimal valorPago, DateTime dataEmissao, DateTime dataVencimento, DateTime dataPagamento, Guid idStatus)
        {
            SetId(Guid.NewGuid());
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

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idVendaRecebimentoTipo, Guid idContaAReceber, Guid idFatura, Guid idVendedor, decimal comissao, decimal valorComissao,
                        decimal valorPago, DateTime dataEmissao, DateTime dataVencimento, DateTime dataPagamento, Guid idStatus)
        {
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

            ChangeUpdateAtToDateTimeNow();
        }

        public void Update(Guid idVendedor, decimal comissao, decimal valorComissao)
        {            
            IdVendedor = idVendedor;
            Comissaoo = comissao;
            ValorComissao = valorComissao;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
