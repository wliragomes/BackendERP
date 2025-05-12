using Domain.Entities.Vendas;

namespace Domain.Interfaces.Repositories
{
    public interface IImpressaoEspecialRepository
    {
        Task Adicionar(ImpressaoEspecial impressaoEspecial);
        Task<ImpressaoEspecial?> ObterPorVendaId(Guid? idVenda);
        Task RemoverPorVendaId(Guid idVenda);
    }
}
