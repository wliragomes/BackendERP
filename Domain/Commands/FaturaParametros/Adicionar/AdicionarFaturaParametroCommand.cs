namespace Domain.Commands.FaturaParametros.Adicionar
{
    public class AdicionarFaturaParametroCommand : FaturaParametroCommand<AdicionarFaturaParametroCommand>
    {
        public AdicionarFaturaParametroCommand()
        {

        }

        public AdicionarFaturaParametroCommand(Guid id, int modelo, string serie, int primeiroNumero)
            : base(id, modelo, serie, primeiroNumero)
        {
        }
    }
}
