namespace Domain.Commands.Representantes.Atualizar
{
    public class AtualizarRepresentanteCommand : RepresentanteCommand<AtualizarRepresentanteCommand>
    {
        public AtualizarRepresentanteCommand(Guid id, Guid idPessoa, bool externo, decimal comissao)
            : base(id, idPessoa, externo, comissao)
        {
        }

        public AtualizarRepresentanteCommand()
        {

        }
    }
}