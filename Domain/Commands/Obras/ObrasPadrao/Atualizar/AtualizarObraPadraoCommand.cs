namespace Domain.Commands.ObrasPadrao.Atualizar
{
    public class AtualizarObraPadraoCommand : ObraPadraoCommand<AtualizarObraPadraoCommand>
    {
        public AtualizarObraPadraoCommand(Guid id, string nome)
            : base(id, nome)
        {
        }

        public AtualizarObraPadraoCommand()
        {

        }
    }
}