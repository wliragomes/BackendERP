using Domain.Commands.Impostos.CstIcmss;

namespace Domain.Commands.Impostos.CstIcmss.Atualizar
{
    public class AtualizarCST_ICMSCommand : CstIcmsCommand<AtualizarCST_ICMSCommand>
    {
        public AtualizarCST_ICMSCommand(Guid id, string nome, string csticmsamigavel, bool descontaicms)
            : base(id, nome, csticmsamigavel, descontaicms)
        {
        }

        public AtualizarCST_ICMSCommand()
        {

        }
    }
}