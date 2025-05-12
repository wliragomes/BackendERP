using Domain.Entities.Faturas;

namespace Domain.Interfaces.Repositories
{
    public interface IRelacionaFaturaVendaRecebimentoTipoRepository
    {
        Task Adicionar(RelacionaFaturaVendaRecebimentoTipo relacionaFaturaVendaRecebimentoTipo);
        Task<RelacionaFaturaVendaRecebimentoTipo?> ObterPorFaturaId(Guid idFatura);
        Task<RelacionaFaturaVendaRecebimentoTipo?> ObterPorVendaId(Guid idVenda);
    }
}
