namespace Domain.Commands.ContasAPagar.Atualizar
{
    public class AtualizarContaAPagarCommand : ContaAPagarCommand<AtualizarContaAPagarCommand>
    {
        public AtualizarContaAPagarCommand(Guid id, bool status, bool rascunho, Guid idFornecedor, Guid idModalidade, string nDocumento, DateTime dataDocumento,
                                  decimal valorDocumento, decimal valorSaldo, bool antecipaDataPagamento, bool resumo, int unitarioPeriodoMensal, int lancadaDefinida,
                                  int qtdParcela, int qtdPeriodo, decimal reajuste, DateTime dataVencimento, Guid idBanco, string historico
                                  )
            : base(id, status, rascunho, idFornecedor, idModalidade, nDocumento, dataDocumento, valorDocumento, valorSaldo, antecipaDataPagamento, resumo, 
                  unitarioPeriodoMensal, lancadaDefinida, qtdParcela, qtdPeriodo, reajuste, dataVencimento, idBanco, historico)
        {
        }

        public AtualizarContaAPagarCommand()
        {

        }
    }
}