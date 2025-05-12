using Domain.Entities.Enderecos;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Vendas
{
    public class VendaOrdemParceiro : Entity
    {
        public Guid IdVenda { get; set; }
        public int CaixilheiroObra { get; set; }
        public Guid IdCliente { get; set; }
        public Guid IdEndereco { get; set; }
        public string? Observacao { get; set; }

        public Venda? Venda { get; set; }
        public virtual Endereco? Endereco { get; private set; }

        public VendaOrdemParceiro()
        {
        }

        public VendaOrdemParceiro(Guid idVenda, int caixilheiroObra, Guid idCliente, Guid idEndereco, string observacao)
        {
            IdVenda = idVenda;
            CaixilheiroObra = caixilheiroObra;
            IdCliente = idCliente;
            IdEndereco = idEndereco;
            Observacao = observacao;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idVenda, int caixilheiroObra, Guid idCliente, Guid idEndereco, string observacao)
        {
            IdVenda = idVenda;
            CaixilheiroObra = caixilheiroObra;
            IdCliente = idCliente;
            IdEndereco = idEndereco;
            Observacao = observacao;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
