using Domain.Commands.Impostos.CstIpis;

namespace Domain.Commands.Impostos.CstIpis.Atualizar
{
    public class AtualizarCstIpiCommand : CstIpiCommand<AtualizarCstIpiCommand>
    {
        public AtualizarCstIpiCommand(Guid id, string nome, string cstipiamigavel, bool cobraipi, string entradasaida)
            : base(id, nome, cstipiamigavel, cobraipi, entradasaida)
        {
        }

        public AtualizarCstIpiCommand()
        {

        }
    }
}