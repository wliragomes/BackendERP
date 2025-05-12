namespace Domain.Commands.MinimoCobrancas.Atualizar
{
    public class AtualizarMinimoCobrancaCommand : MinimoCobrancaCommand<AtualizarMinimoCobrancaCommand>
    {
        public AtualizarMinimoCobrancaCommand(Guid id, string descricao, decimal valorMinimoCobranca)
            : base(id, descricao, valorMinimoCobranca)
        {
        }

        public AtualizarMinimoCobrancaCommand()
        {

        }
    }
}