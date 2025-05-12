namespace Domain.Commands.Cidades.Adicionar
{
    public class AdicionarCidadeCommand : CidadeCommand<AdicionarCidadeCommand>
    {
        public AdicionarCidadeCommand()
        {

        }

        public AdicionarCidadeCommand(Guid? id, Guid idEstado, string? nome, decimal prISS, decimal valorMultiplicador, string codIBGE)
            : base(id, idEstado, nome, prISS, valorMultiplicador, codIBGE)
        {
        }
    }
}
