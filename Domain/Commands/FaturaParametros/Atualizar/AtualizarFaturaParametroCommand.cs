namespace Domain.Commands.FaturaParametros.Atualizar
{
    public class AtualizarFaturaParametroCommand : FaturaParametroCommand<AtualizarFaturaParametroCommand>
    {
        public AtualizarFaturaParametroCommand(Guid id, int modelo, string serie, int primeiroNumero)
            : base(id, modelo, serie, primeiroNumero)
        {
        }

        public AtualizarFaturaParametroCommand()
        {

        }
    }
}