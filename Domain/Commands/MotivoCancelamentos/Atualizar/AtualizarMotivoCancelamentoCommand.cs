namespace Domain.Commands.MotivoCancelamentos.Atualizar
{
    public class AtualizarMotivoCancelamentoCommand : MotivoCancelamentoCommand<AtualizarMotivoCancelamentoCommand>
    {
        public AtualizarMotivoCancelamentoCommand(Guid id, string nome, string descricao, bool pedido, bool orcamento, bool pedidoInativo, bool orcamentoInativo)
            : base(id, nome, descricao, pedido, orcamento, pedidoInativo, orcamentoInativo)
        {
        }

        public AtualizarMotivoCancelamentoCommand()
        {

        }
    }
}