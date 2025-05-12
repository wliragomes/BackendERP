namespace Domain.Commands.Impostos.Cofinss.Adicionar
{
    public class AdicionarCofinsCommand : CofinsCommand<AdicionarCofinsCommand>
    {
        public AdicionarCofinsCommand()
        {

        }

        public AdicionarCofinsCommand(Guid id, string nome, string cofinsAmigavel, bool descontaCofins)
            : base(id, nome, cofinsAmigavel, descontaCofins)
        {
        }
    }
}