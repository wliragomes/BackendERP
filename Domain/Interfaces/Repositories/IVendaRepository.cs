using Domain.Entities;
using Domain.Entities.Vendas;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IVendaRepository
    {
        Task Adicionar(Venda venda);             
        Task<Venda?> ObterPorId(Guid? id);        
        Task<int> GetMaxCodigoVenda(int anoVenda);        
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteCodigoAsync(string codigo, Guid? id);
        Func<IUnitOfWork, string, Guid?, Task<bool>> VerificarExistenciaCodigo();
        Task AdicionarEmMassa(List<Venda> vendas, CancellationToken cancellationToken = default);
        Task<List<Venda>> RetornarVendasExcluirMassa(FiltroBase filtroBase);        
        Task<List<Status>> GetStatus();        
    }
}
