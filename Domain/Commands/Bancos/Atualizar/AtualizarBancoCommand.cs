namespace Domain.Commands.Bancos.Atualizar
{
    public class AtualizarBancoCommand : BancoCommand<AtualizarBancoCommand>
    {
        public AtualizarBancoCommand(Guid id, string nome, bool naoSomar, string numeroBanco)
            : base(id, nome, naoSomar, numeroBanco)
        {
        }

        public AtualizarBancoCommand()
        {

        }
    }
}