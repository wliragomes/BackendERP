using Domain.Entities.Pessoas;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IPessoaRepository
    {
        Task Adicionar(Pessoa pessoa);
        Task<Pessoa?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteCpfCnpjAsync(string? cpfCnpj);
        Task<bool> ExisteCodigoAsync(string codigo, Guid? id);
        Func<IUnitOfWork, string, Guid?, Task<bool>> VerificarExistenciaCodigo();
        Task AdicionarEmMassa(List<Pessoa> pessoas, CancellationToken cancellationToken = default);
        Task<List<Pessoa>> RetornarPessoasExcluirMassa(FiltroBase filtroBase);
    }
}
