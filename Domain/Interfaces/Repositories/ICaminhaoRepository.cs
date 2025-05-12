using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ICaminhaoRepository
    {
        Task Adicionar(Caminhao caminhao);
        Task<Caminhao?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExistePlacaAsync(string placa, Guid? id);
        Task AdicionarEmMassa(List<Caminhao> caminhoes, CancellationToken cancellationToken = default);
        Task<List<Caminhao>> RetornarCaminhoesExcluirMassa(FiltroBase filtroBase);
    }
}
