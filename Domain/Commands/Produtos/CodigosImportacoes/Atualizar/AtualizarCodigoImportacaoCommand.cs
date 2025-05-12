namespace Domain.Commands.Produtos.CodigosImportacoes.Atualizar
{
    public class AtualizarCodigoImportacaoCommand : CodigoImportacaoCommand<AtualizarCodigoImportacaoCommand>
    {
        public AtualizarCodigoImportacaoCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarCodigoImportacaoCommand()
        {

        }
    }
}
