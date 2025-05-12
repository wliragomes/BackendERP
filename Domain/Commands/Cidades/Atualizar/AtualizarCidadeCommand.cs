namespace Domain.Commands.Cidades.Atualizar
{
    public class AtualizarCidadeCommand : CidadeCommand<AtualizarCidadeCommand>
    {
        public AtualizarCidadeCommand(Guid? id, Guid idEstado, string? nome, decimal prISS, decimal valorMultiplicador, string codIBGE)
            : base(id, idEstado, nome, prISS, valorMultiplicador, codIBGE)
        {
        }

        public AtualizarCidadeCommand()
        {

        }
    }
}
