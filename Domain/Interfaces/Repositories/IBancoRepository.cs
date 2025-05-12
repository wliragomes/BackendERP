using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IBancoRepository
    {
        Task Adicionar(Banco banco);
        Task<Banco?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);        
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task<bool> ExisteNumeroBancoAsync(string numeroBanco, Guid? id);
        Task AdicionarEmMassa(List<Banco> bancos, CancellationToken cancellationToken = default);
        Task<List<Banco>> RetornarBancosExcluirMassa(FiltroBase filtroBase);
    }
}
