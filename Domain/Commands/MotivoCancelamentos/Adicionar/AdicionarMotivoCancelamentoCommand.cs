namespace Domain.Commands.MotivoCancelamentos.Adicionar
{
    public class AdicionarMotivoCancelamentoCommand : MotivoCancelamentoCommand<AdicionarMotivoCancelamentoCommand>
    {
        public AdicionarMotivoCancelamentoCommand()
        {

        }

        public AdicionarMotivoCancelamentoCommand(Guid id, string nome, string descricao, bool pedido, bool orcamento, bool pedidoInativo, bool orcamentoInativo)
            : base(id, nome, descricao, pedido, orcamento, pedidoInativo, orcamentoInativo)
        {
        }
    }
}
