namespace Domain.Commands.ContasAReceber.Atualizar
{
    public class AtualizarContaAReceberCommand : ContaAReceberCommand<AtualizarContaAReceberCommand>
    {
        public AtualizarContaAReceberCommand(Guid id, bool? status, bool? rascunho, Guid? idCliente, string? nDocumento, DateTime? dataDocumento, DateTime dataVencimento, decimal? valorDocumento,
                                             int? unitarioPeriodoMensal, int? qtdParcela, int qtdPeriodo, Guid? idCentroDeCusto, Guid? idDespesa, Guid? idBanco, Guid? idFatura, string? historico)
            : base(id, status, rascunho, idCliente, nDocumento, dataDocumento, dataVencimento, valorDocumento, unitarioPeriodoMensal, qtdParcela, qtdPeriodo, idCentroDeCusto, idDespesa, 
                   idBanco, idFatura, historico)
        {
        }

        public AtualizarContaAReceberCommand()
        {

        }
    }
}