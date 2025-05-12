using Domain.Entities.Vendas;

namespace Domain.Interfaces.Repositories
{
    public interface IVendaRecebimentoParcelaRepository
    {
        Task AdicionarEmMassa(List<VendaRecebimentoParcela> vendaRecebimentoParcelaRepository, CancellationToken cancellationToken = default);
        Task<List<VendaRecebimentoParcela?>> ObterPorId(Guid? idVenda);
        Task<List<VendaRecebimentoParcela>> ObterPorFaturaId(Guid idFatura);
        Task RemoverPorVendaRecebimentoId(Guid idVendaRecebimentoTipo);
    }
}
