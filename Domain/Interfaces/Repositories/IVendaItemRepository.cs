using Domain.Entities.VendasItem;

namespace Domain.Interfaces.Repositories
{
    public interface IVendaItemRepository
    {
        //Task Adicionar(VendaItem vendaItem);
        //Task<VendaItem?> ObterPorId(Guid? idVenda);
        //Task<bool> ExisteIdAsync(Guid? idVenda);
        //Task<bool> ExisteCodigoAsync(Guid? idVenda);
        //Func<IUnitOfWork, string, Guid?, Task<bool>> VerificarExistenciaCodigo();
        Task AdicionarEmMassa(List<VendaItem> vendaItem, CancellationToken cancellationToken = default);
        Task RemoverPorVendaId(Guid idVenda);
        //Task<List<VendaItem>> RetornarVendaItemExcluirMassa(FiltroBase filtroBase);
    }
}
