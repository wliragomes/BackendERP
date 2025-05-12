using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ICodigoImportacaoRepository
    {
        Task Adicionar(CodigoImportacao codigo);
        Task<CodigoImportacao?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<CodigoImportacao> codigo, CancellationToken cancellationToken = default);
        Task<List<CodigoImportacao>> RetornarCodigoImportacaoExcluirMassa(FiltroBase filtroBase);
    }
}
