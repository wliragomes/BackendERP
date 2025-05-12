using Domain.Commands.Romaneios;

namespace Domain.Commands.OrdensFabricacoes.Adicionar
{
    public class AdicionarRomaneioCommand : RomaneioCommand<AdicionarRomaneioCommand>
    {
        public AdicionarRomaneioCommand()
        {

        }

        public AdicionarRomaneioCommand(Guid id, int sqRomaneioCodigo, int sqRomaneioAno, int qtdFrete)
            : base(id, sqRomaneioCodigo, sqRomaneioAno, qtdFrete)
        {
        }
    }
}
