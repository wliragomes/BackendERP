using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IMedidaParametroRepository
    {
        Task<MedidaParametro?> ObterMedidaFrete(decimal medidaFrete);
    }
}