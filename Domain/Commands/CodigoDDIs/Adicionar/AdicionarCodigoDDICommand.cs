namespace Domain.Commands.CodigoDDIs.Adicionar
{
    public class AdicionarCodigoDDICommand : CodigoDDICommand<AdicionarCodigoDDICommand>
    {
        public AdicionarCodigoDDICommand()
        {

        }

        public AdicionarCodigoDDICommand(Guid id, string codigo)
            : base(id, codigo)
        {
        }
    }
}
