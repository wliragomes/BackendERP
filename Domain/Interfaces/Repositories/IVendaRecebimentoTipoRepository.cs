using Domain.Entities.Vendas;

namespace Domain.Interfaces.Repositories
{
    public interface IVendaRecebimentoTipoRepository
    {
        Task Adicionar(VendaRecebimentoTipo vendaRecebimentoTipo);
        Task<VendaRecebimentoTipo?> ObterPorId(Guid? idVenda);
        Task<VendaRecebimentoTipo?> ObterPorFaturaId(Guid? idVenda);
        Task<VendaRecebimentoTipo?> ObterPorVendaId(Guid? idVenda);
    }
}
