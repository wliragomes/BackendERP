namespace Domain.Commands.Impostos.Cofinss.Atualizar
{
    public class AtualizarCofinsCommand : CofinsCommand<AtualizarCofinsCommand>
    {
        public AtualizarCofinsCommand(Guid id, string nome, string cofinsAmigavel, bool descontaCofins)
            : base(id, nome, cofinsAmigavel, descontaCofins)
        {
        }

        public AtualizarCofinsCommand()
        {

        }
    }
}