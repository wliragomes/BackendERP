namespace Domain.Commands.MinimoCobrancas.Adicionar
{
    public class AdicionarMinimoCobrancaCommand : MinimoCobrancaCommand<AdicionarMinimoCobrancaCommand>
    {
        public AdicionarMinimoCobrancaCommand()
        {

        }

        public AdicionarMinimoCobrancaCommand(Guid id, string descricao, decimal valorMinimoCobranca)
            : base(id, descricao, valorMinimoCobranca)
        {
        }
    }
}
