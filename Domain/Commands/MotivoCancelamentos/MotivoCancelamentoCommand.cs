using SharedKernel.MediatR;

namespace Domain.Commands.MotivoCancelamentos
{
    public abstract class MotivoCancelamentoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Pedido { get; set; }
        public bool Orcamento { get; set; }
        public bool PedidoInativo { get; set; }
        public bool OrcamentoInativo { get; set; }

        public MotivoCancelamentoCommand()
        {

        }

        public MotivoCancelamentoCommand(Guid id, string nome, string descricao, bool pedido, bool orcamento, bool pedidoInativo, bool orcamentoInativo)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Pedido = pedido;
            Orcamento = orcamento;
            PedidoInativo = pedidoInativo;
            OrcamentoInativo = orcamentoInativo;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}