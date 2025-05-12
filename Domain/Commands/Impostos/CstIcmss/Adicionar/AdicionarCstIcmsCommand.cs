namespace Domain.Commands.Impostos.CstIcmss.Adicionar
{
    public class AdicionarCstIcmsCommand : CstIcmsCommand<AdicionarCstIcmsCommand>
    {
        public AdicionarCstIcmsCommand()
        {

        }

        public AdicionarCstIcmsCommand(Guid id, string nome, string csticmsamigavel, bool descontaicms)
            : base(id, nome, csticmsamigavel, descontaicms)
        {
        }
    }
}
