using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IContaAReceberPagoRepository
    {
        Task Adicionar(ContaAReceberPago ContaAReceberPago);
        Task<ContaAReceberPago?> BuscarPorContaAReceberId(Guid? id);
    }
}
