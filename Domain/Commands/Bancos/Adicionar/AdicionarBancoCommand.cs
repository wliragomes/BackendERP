namespace Domain.Commands.Bancos.Adicionar
{
    public class AdicionarBancoCommand : BancoCommand<AdicionarBancoCommand>
    {
        public AdicionarBancoCommand()
        {

        }

        public AdicionarBancoCommand(Guid id, string? nome, bool naoSomar, string? numeroBanco)
            : base(id, nome, naoSomar, numeroBanco)
        {
        }
    }
}
