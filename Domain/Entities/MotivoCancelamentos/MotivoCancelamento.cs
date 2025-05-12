using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class MotivoCancelamento : EntityIdNome
    {
        public string Descricao { get; set; }
        public bool Pedido { get; set; }
        public bool Orcamento { get; set; }
        public bool PedidoInativo { get; set; }
        public bool OrcamentoInativo { get; set; }

        public MotivoCancelamento(string nome, string descricao, bool pedido, bool orcamento, bool pedidoInativo, bool orcamentoInativo)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);
            Descricao = descricao;
            Pedido = pedido;
            Orcamento = orcamento;
            PedidoInativo = pedidoInativo;
            OrcamentoInativo = orcamentoInativo;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nome, string descricao, bool pedido, bool orcamento, bool pedidoInativo, bool orcamentoInativo)
        {
            SetNome(nome);
            Descricao = descricao;
            Pedido = pedido;
            Orcamento = orcamento;
            PedidoInativo = pedidoInativo;
            OrcamentoInativo = orcamentoInativo;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
