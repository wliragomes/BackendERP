using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ICidadeRepository
    {
        Task Adicionar(Cidade Cidade);
        Task<Cidade?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteCidadeDuplicadaAsyn(string nome, Guid? idEstado, Guid? id);
        Task<List<Cidade>> RetornarCidadesExcluirMassa(FiltroBase filtroBase);
    }
}
