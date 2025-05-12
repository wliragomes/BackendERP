using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IContaBancariaRepository
    {
        Task Adicionar(ContaBancaria contaBancaria);
        Task<ContaBancaria?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<ContaBancaria> contasBancarias, CancellationToken cancellationToken = default);
        Task<List<ContaBancaria>> RetornarContasBancariasExcluirMassa(FiltroBase filtroBase);
    }
}
