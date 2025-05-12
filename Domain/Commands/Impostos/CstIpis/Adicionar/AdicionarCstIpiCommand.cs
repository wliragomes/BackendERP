using Domain.Commands.Impostos.CstIpis;

namespace Domain.Commands.Impostos.CstIpis.Adicionar
{
    public class AdicionarCstIpiCommand : CstIpiCommand<AdicionarCstIpiCommand>
    {
        public AdicionarCstIpiCommand()
        {

        }

        public AdicionarCstIpiCommand(Guid id, string nome, string cstipiamigavel, bool cobraipi, string entradasaida)
            : base(id, nome, cstipiamigavel, cobraipi, entradasaida)
        {
        }
    }
}
