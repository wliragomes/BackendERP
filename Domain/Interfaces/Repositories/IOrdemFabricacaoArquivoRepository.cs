using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IOrdemFabricacaoArquivoRepository
    {
        Task Adicionar(OrdemFabricacaoArquivo ordemFabricacaoArquivo);
        Task RemoverMassa(List<OrdemFabricacaoArquivo> ordemFabricacaoArquivo, CancellationToken cancellationToken = default);
        Task<List<OrdemFabricacaoArquivo>> ObterPorIdOrdemFabricacaoArquivo(Guid? id);
        Task<OrdemFabricacaoArquivo?> ObterOrdemFabricacaoArquivoPorId(Guid? idOrdemFabricacao, int SqArquivo);
        Task<OrdemFabricacaoArquivo?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<OrdemFabricacaoArquivo> ordensFabricacoesArquivos, CancellationToken cancellationToken = default);
        Task<List<OrdemFabricacaoArquivo>> RetornarOrdensFabricacoesArquivosExcluirMassa(FiltroBase filtroBase);
    }
}
