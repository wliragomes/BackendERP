using Domain.Entities.Vendas;

namespace Domain.Interfaces.Repositories
{
    public interface IVendaOrdemParceiroRepository
    {
        Task<List<VendaOrdemParceiro?>> ObterPorVendaId(Guid? idVenda);
        Task Adicionar(VendaOrdemParceiro vendaOrdemParceiro);
        Task AdicionarEmMassa(List<VendaOrdemParceiro> vendaOrdemParceiro, CancellationToken cancellationToken = default);
        Task RemoverPorVendaId(Guid idVenda);
        Task RemoverEmMassa(List<VendaOrdemParceiro> vendaOrdemParceiro, CancellationToken cancellationToken = default);
    }
}
