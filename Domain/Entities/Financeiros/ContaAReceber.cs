using Domain.Entities.Pessoas;
using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class ContaAReceber : EntityId
    {
        public bool? Status { get; set; }
        public bool? Rascunho { get; set; }
        public Guid? IdCliente { get; set; }
        public string? NDocumento { get; set; }
        public DateTime? DataDocumento { get; set; }
        public DateTime? DataVencimento { get; set; }
        public decimal? ValorDocumento { get; set; }
        public int? UnitarioPeriodoMensal { get; set; }
        public int? QtdParcela { get; set; } = 1;
        public int? QtdPeriodo { get; set; }
        public Guid? IdCentroDeCusto { get; set; }
        public Guid? IdDespesa { get; set; }
        public Guid? IdBanco { get; set; }
        public Guid? IdFatura { get; set; }
        public string? Historico { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public ContaAReceber(bool? status, bool? rascunho, Guid? idCliente, string? nDocumento, DateTime? dataDocumento, DateTime? dataVencimento, decimal? valorDocumento,
                             int? unitarioPeriodoMensal, int? qtdParcela, int? qtdPeriodo, Guid? idCentroDeCusto, Guid? idDespesa, Guid? idBanco, Guid? idFatura, string? historico)
        {
            SetId(Guid.NewGuid());
            Status = status;
            Rascunho = rascunho;
            IdCliente = idCliente;
            NDocumento = nDocumento;
            DataDocumento = dataDocumento;
            DataVencimento = dataVencimento;
            ValorDocumento = valorDocumento;
            UnitarioPeriodoMensal = unitarioPeriodoMensal;
            QtdParcela = qtdParcela;
            QtdPeriodo = qtdPeriodo;
            IdCentroDeCusto = idCentroDeCusto;
            IdDespesa = idDespesa;
            IdBanco = idBanco;
            IdFatura = idFatura;
            Historico = historico;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(bool? status, bool? rascunho, Guid? idCliente, string? nDocumento, DateTime? dataDocumento, DateTime? dataVencimento, decimal? valorDocumento,
                           int? unitarioPeriodoMensal, int? qtdParcela, int? qtdPeriodo, Guid? idCentroDeCusto, Guid? idDespesa, Guid? idBanco, Guid? idFatura, string? historico)
        {
            Status = status;
            Rascunho = rascunho;
            IdCliente = idCliente;
            NDocumento = nDocumento;
            DataDocumento = dataDocumento;
            DataVencimento = dataVencimento;
            ValorDocumento = valorDocumento;
            UnitarioPeriodoMensal = unitarioPeriodoMensal;
            QtdParcela = qtdParcela;
            QtdPeriodo = qtdPeriodo;
            IdCentroDeCusto = idCentroDeCusto;
            IdDespesa = idDespesa;
            IdBanco = idBanco;
            IdFatura = idFatura;
            Historico = historico;

            ChangeUpdateAtToDateTimeNow();
        }

        public void Update(Guid? idCliente, string? nDocumento, DateTime? dataVencimento, decimal? valorDocumento, Guid? idBanco, string? historico)
        {
            IdCliente = idCliente;
            NDocumento = nDocumento;
            DataVencimento = dataVencimento;
            ValorDocumento = valorDocumento;
            IdBanco = idBanco;
            Historico = historico;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
