namespace Domain.Commands.Romaneios.Atualizar
{
    public class AtualizarRomaneioCommand : RomaneioCommand<AtualizarRomaneioCommand>
    {
        public AtualizarRomaneioCommand(Guid id, int sqRomaneioCodigo, int sqRomaneioAno, int qtdFrete)
            : base(id, sqRomaneioCodigo, sqRomaneioAno, qtdFrete)
        {
        }

        public AtualizarRomaneioCommand()
        {

        }
    }
}