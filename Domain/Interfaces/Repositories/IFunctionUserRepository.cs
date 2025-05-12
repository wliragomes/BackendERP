
using Domain.Entities.Usuarios;

namespace Domain.Interfaces.Repositories
{
    public interface IFunctionUserRepository
    {
        Task<Credentials> GetCredential(Guid id);
    }
}
