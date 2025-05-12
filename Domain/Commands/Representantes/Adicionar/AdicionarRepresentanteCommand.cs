namespace Domain.Commands.Representantes.Adicionar
{
    public class AdicionarRepresentanteCommand : RepresentanteCommand<AdicionarRepresentanteCommand>
    {
        public AdicionarRepresentanteCommand()
        {

        }

        public AdicionarRepresentanteCommand(Guid id, Guid idPessoa, bool externo, decimal comissao)
            : base(id, idPessoa, externo, comissao)
        {
        }
    }
}
