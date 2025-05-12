namespace Domain.Commands.CodigoDDIs.Atualizar
{
    public class AtualizarCodigoDDICommand : CodigoDDICommand<AtualizarCodigoDDICommand>
    {
        public AtualizarCodigoDDICommand(Guid id, string codigo)
            : base(id, codigo)
        {
        }

        public AtualizarCodigoDDICommand()
        {

        }
    }
}