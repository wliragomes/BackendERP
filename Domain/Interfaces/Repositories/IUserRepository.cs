using Domain.Entities.Pessoas;
using Domain.Entities.Usuarios;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task Add(Users entity);
        Task<List<Users>> GetUserToFilterBulk(FilterBulkBase filterBulk);
        Task<bool> Exists(Guid? id);
        Task<Users?> GetById(Guid? id);
        Task<Users?> GetUserByUserName(string? userName);
        Task<Users?> ObterPorIdPessoa(Guid? id);
        Task<bool> IsPeopleUnique(Guid? userId, Guid? idPeople);
        Task<bool> UnblockByCode(Guid userId, string unblockCode);
        Task<List<Users>> GetUserForOpenToFilterBulk(FilterBulkBase commandOpenBulkBase);
        Task<bool> AdministratorExistInDb(Guid? id);
        Task<bool> BoundAdministratorUserExistsInDb(Guid? administratorId, Guid? userId);
        Task<bool> IsUserEffectiveDateActive(Guid userId);
        Task<bool> UserHaveAccessToAdministrator(Guid idUser, Guid idAdministrator);
        Task Remover(Users user, CancellationToken cancellationToken = default);
    }
}
