using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class NormaAbnt : EntityIdDescricao
    {
        public string Numero { get; set; }
        public string Pedido { get; set; }
        public DateTime? Validade { get; set; }
        public bool Vencida { get; set; }
        public IEnumerable<RelacionaNormaAbntVenda> RelacionaNormaAbntVenda { get; set; }

        public NormaAbnt() { }

        public NormaAbnt(string nnbr, string descricao, string pedido, DateTime? validade, bool vencida)
        {
            Numero = nnbr;
            SetDescricao(descricao);
            Pedido = pedido;
            Validade = validade;
            Vencida = vencida;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nnbr, string descricao, string pedido, DateTime? validade, bool vencida)
        {            
            Numero = nnbr;
            SetDescricao(descricao);
            Pedido = pedido;
            Validade = validade;
            Vencida = vencida;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
