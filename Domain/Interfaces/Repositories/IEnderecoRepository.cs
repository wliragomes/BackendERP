using Domain.Entities.Enderecos;

namespace Domain.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        Task Adicionar(Endereco endereco);
        Task AdicionarEmMassa(List<Endereco> enderecos, CancellationToken cancellationToken = default);
        Task<List<Endereco?>> ObterPorIdPessoa(Guid? id);
        //Task<Endereco?> ObterPorIdEmpresa(Guid? id);
        Task<Endereco?> ObterPorId(Guid? id);
        Task<List<Endereco>> ObterPorIds(IEnumerable<Guid> ids);
        Task RemoverEmMassa(List<Endereco> enderecos, CancellationToken cancellationToken = default);
        Task RemoverPorId(Guid id);
    }
}