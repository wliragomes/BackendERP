namespace Domain.Commands.ObrasPadrao.Adicionar
{
    public class AdicionarObraPadraoCommand : ObraPadraoCommand<AdicionarObraPadraoCommand>
    {
        public AdicionarObraPadraoCommand()
        {

        }

        public AdicionarObraPadraoCommand(Guid id, string nome)
            : base(id, nome)
        {
        }
    }
}
