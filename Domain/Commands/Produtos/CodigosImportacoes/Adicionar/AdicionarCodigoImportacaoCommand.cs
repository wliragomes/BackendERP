namespace Domain.Commands.Produtos.CodigosImportacoes.Adicionar
{
    public class AdicionarCodigoImportacaoCommand : CodigoImportacaoCommand<AdicionarCodigoImportacaoCommand>
    {
        public AdicionarCodigoImportacaoCommand()
        {

        }

        public AdicionarCodigoImportacaoCommand(Guid id, string? descricao)
            : base(id, descricao)
        {
        }
    }
}
