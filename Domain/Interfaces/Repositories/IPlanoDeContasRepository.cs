using Domain.Commands.PlanosDeContas.Adicionar;
using Domain.Commands.PlanosDeContas.Atualizar;
using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IPlanoDeContasRepository
    {
        Task Adicionar(PlanoDeContas planoDeContas);
        Task<PlanoDeContas?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExistePlanoDeContaAsync(string planoDeContasCompleto, Guid? id);
        Task AdicionarEmMassa(List<PlanoDeContas> planosDeContas, CancellationToken cancellationToken = default);
        Task<List<PlanoDeContas>> RetornarPlanosDeContasExcluirMassa(FiltroBase filtroBase);
        Task<PlanoDeContas> RetornarValidacao(AdicionarPlanoDeContasCommand command);
        Task<PlanoDeContas> RetornarValidacao(AtualizarPlanoDeContasCommand command);
    }
}
