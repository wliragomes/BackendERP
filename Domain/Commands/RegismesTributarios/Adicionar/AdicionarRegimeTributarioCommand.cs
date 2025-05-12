namespace Domain.Commands.RegimeTributarios.Adicionar
{
    public class AdicionarRegimeTributarioCommand : RegimeTributarioCommand<AdicionarRegimeTributarioCommand>
    {
        public AdicionarRegimeTributarioCommand()
        {

        }

        public AdicionarRegimeTributarioCommand(Guid id, string? nome, decimal valorPis, decimal valorCofins)
            : base(id, nome, valorPis, valorCofins)
        {
        }
    }
}
