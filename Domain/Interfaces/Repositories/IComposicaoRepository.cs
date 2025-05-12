using Domain.Entities.Produtos;

namespace Domain.Interfaces.Repositories
{
    public interface IComposicaoRepository
    {
        Task<List<Composicao?>> ObterPorId(Guid? id);
        Task AdicionarEmMassa(List<Composicao> composicao, CancellationToken cancellationToken = default);
        Task Adicionar(Composicao composicao, CancellationToken cancellationToken = default);

    }
}
