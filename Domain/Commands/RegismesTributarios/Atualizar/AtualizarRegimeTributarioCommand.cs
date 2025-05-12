namespace Domain.Commands.RegimeTributarios.Atualizar
{
    public class AtualizarRegimeTributarioCommand : RegimeTributarioCommand<AtualizarRegimeTributarioCommand>
    {
        public AtualizarRegimeTributarioCommand(Guid id, string nome, decimal valorPis, decimal valorCofins)
            : base(id, nome, valorPis, valorCofins)
        {
        }

        public AtualizarRegimeTributarioCommand()
        {

        }
    }
}