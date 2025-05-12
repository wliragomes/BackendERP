using SharedKernel.MediatR;

namespace Domain.Commands.ContasAReceber
{
    public abstract class ContaAReceberCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public bool? Status { get; set; }
        public bool? Rascunho { get; set; }
        public Guid? IdCliente { get; set; }
        public string? NDocumento { get; set; }
        public DateTime? DataDocumento { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal? ValorDocumento { get; set; }
        public int? UnitarioPeriodoMensal { get; set; }
        public int? QtdParcela { get; set; } = 1;
        public int QtdPeriodo { get; set; }
        public Guid? IdCentroDeCusto { get; set; }
        public Guid? IdDespesa { get; set; }
        public Guid? IdBanco { get; set; }
        public Guid? IdFatura { get; set; }
        public string? Historico { get; set; }

        public ContaAReceberCommand()
        {

        }

        public ContaAReceberCommand(Guid id, bool? status, bool? rascunho, Guid? idCliente, string? nDocumento, DateTime? dataDocumento, DateTime dataVencimento, decimal? valorDocumento,
                                    int? unitarioPeriodoMensal, int? qtdParcela, int qtdPeriodo, Guid? idCentroDeCusto, Guid? idDespesa, Guid? idBanco, Guid? idFatura, string? historico)
        {
            Id = id;
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
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}