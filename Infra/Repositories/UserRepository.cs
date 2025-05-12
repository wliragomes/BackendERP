using Domain.Entities.Usuarios;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        //private readonly IHttpRequestCustom _httpRequestCustom;
        //private readonly string _msConfigurationUrl;

        public UserRepository(ApplicationDbContext context
                              //,IConfiguration configuration,
                              //IHttpRequestCustom httpRequestCustom
                              )
        {
            _context = context;
            //_msConfigurationUrl = configuration.GetSection("MsConfigurationUrl").Value ?? string.Empty;
            //_httpRequestCustom = httpRequestCustom;
        }

        public async Task Add(Users entity)
        {
            await _context.User.AddAsync(entity);
        }

        public async Task<bool> Exists(Guid? id)
        {
            return await _context.User.AnyAsync(x => x.Id == id);
        }

        public async Task<Users?> GetById(Guid? id)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Users>> GetUserToFilterBulk(FilterBulkBase filterBulk)
        {
            //var dbSetQuery = _context.User;
            //var hasActiveEffectiveDate = filterBulk.FilterBy?.ToLower().Contains(EffectiveDateConstant.HAS_ACTIVE_EFFECTIVE_DATE.ToLower());
            //var hasInactiveEffectiveDate = filterBulk.FilterBy?.ToLower().Contains(EffectiveDateConstant.HAS_INACTIVE_EFFECTIVE_DATE.ToLower());

            //filterBulk.FilterBy = FilterByWithoutHasEffectiveDate(filterBulk.FilterBy);
            //var query = FilterBulkBuilder<Users>.BuildQuery(dbSetQuery, filterBulk);

            //query = query.Include(x => x.BoundEffectiveDateUser!)
            //    .ThenInclude(b => b.EffectiveDateUser);

            //query = QueryWithActiveInactive(hasActiveEffectiveDate, hasInactiveEffectiveDate, query);

            //return await query.ToListAsync();
            return default;
        }

        public async Task<Users?> GetUserByUserName(string? userName)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<Users?> ObterPorIdPessoa(Guid? id)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.IdPessoa == id);
        }

        public async Task<bool> UnblockByCode(Guid userId, string unblockedCode)
        {
            decimal unblockCode = 0;
            decimal.TryParse(unblockedCode, out unblockCode);

            Users? user = await _context.User.AsNoTracking().FirstOrDefaultAsync(x =>
                    x.UnblockCode > 0 &&
                    (x.Id == userId) &&
                    x.UnblockCode == unblockCode &&
                    DateTime.Now <= x.UnBlockCodeExpire);

            if (user == null)
                return false;

            return true;
        }

        public async Task<List<Users>> GetUserForOpenToFilterBulk(FilterBulkBase filterBulk)
        {
            //var dbSetQuery = _context.User;
            //var hasActiveEffectiveDate = filterBulk.FilterBy?.ToLower().Contains(EffectiveDateConstant.HAS_ACTIVE_EFFECTIVE_DATE.ToLower());
            //var hasInactiveEffectiveDate = filterBulk.FilterBy?.ToLower().Contains(EffectiveDateConstant.HAS_INACTIVE_EFFECTIVE_DATE.ToLower());

            //filterBulk.FilterBy = FilterByWithoutHasEffectiveDate(filterBulk.FilterBy);
            //var query = FilterBulkBuilder<Users>.BuildQuery(dbSetQuery, filterBulk);

            //query = query.Include(x => x.BoundEffectiveDateUser!)
            //    .ThenInclude(b => b.EffectiveDateUser);

            //query = QueryWithActiveInactive(hasActiveEffectiveDate, hasInactiveEffectiveDate, query);

            //return await query.ToListAsync();
            return default;
        }

        public async Task<bool> IsPeopleUnique(Guid? userId, Guid? idPeople)
        {
            var queryResult = await _context.User
                .AsNoTracking()
                .AnyAsync(x => x.IdPessoa == idPeople && x.Id != userId);

            return !queryResult;
        }

        private IQueryable<Users> QueryWithActiveInactive(bool? hasActiveEffectiveDate, bool? hasInactiveEffectiveDate, IQueryable<Users> query)
        {
            //if (hasActiveEffectiveDate is not null || hasInactiveEffectiveDate is not null)
            //{
            //    if (hasActiveEffectiveDate is not null && hasActiveEffectiveDate!.Value)
            //        query = query.Where(x => x.BoundEffectiveDateUser!.Any(x => x.EffectiveDateUser.StartEffectiveDate.Date <= DateTime.UtcNow.Date && (x.EffectiveDateUser.EndEffectiveDate == null || x.EffectiveDateUser.EndEffectiveDate.Value.Date >= DateTime.UtcNow.Date)));
            //    else if (hasInactiveEffectiveDate is not null && hasInactiveEffectiveDate!.Value)
            //        query = query.Where(x => !x.BoundEffectiveDateUser!.Any(x => x.EffectiveDateUser.StartEffectiveDate.Date <= DateTime.UtcNow.Date && (x.EffectiveDateUser.EndEffectiveDate == null || x.EffectiveDateUser.EndEffectiveDate.Value.Date >= DateTime.UtcNow.Date)));
            //}
            //return query;
            return default;
        }

        private string FilterByWithoutHasEffectiveDate(string? filterBy)
        {
            //var hasActiveEffectiveDate = filterBy?.ToLower().Contains(EffectiveDateConstant.HAS_ACTIVE_EFFECTIVE_DATE.ToLower());
            //var hasInactiveEffectiveDate = filterBy?.ToLower().Contains(EffectiveDateConstant.HAS_INACTIVE_EFFECTIVE_DATE.ToLower());
            //var filterByWithoutHasEffectiveDate = string.Empty;
            //if (hasActiveEffectiveDate is not null && hasActiveEffectiveDate!.Value)
            //{
            //    filterByWithoutHasEffectiveDate = Regex.Replace(filterBy!, EffectiveDateConstant.HAS_ACTIVE_EFFECTIVE_DATE, "", RegexOptions.IgnoreCase);
            //}
            //else if (hasInactiveEffectiveDate is not null && hasInactiveEffectiveDate!.Value)
            //{
            //    filterByWithoutHasEffectiveDate = Regex.Replace(filterBy!, EffectiveDateConstant.HAS_INACTIVE_EFFECTIVE_DATE, "", RegexOptions.IgnoreCase);
            //}
            //else
            //{
            //    return filterBy;
            //}

            //var filters = filterByWithoutHasEffectiveDate.Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            //return string.Join(",", filters);
            return default;
        }

        public async Task<bool> IsUserEffectiveDateActive(Guid userId)
        {
            //var query = _context.EffectiveDateUser
            //    .Include(x => x.BoundEffectiveDateUsers)
            //    .Where(x => x.BoundEffectiveDateUsers != null &&
            //                x.BoundEffectiveDateUsers.Any(b => b.User != null && b.User.Id == userId))
            //    .OrderByDescending(x => x.StartEffectiveDate)
            //.AsNoTracking();

            //bool isActive = await query.AnyAsync(x => x.StartEffectiveDate.Date <= DateTime.UtcNow.Date && (x.EndEffectiveDate == null || x.EndEffectiveDate.Value.Date >= DateTime.UtcNow.Date));

            //return isActive;
            return default;
        }

        public async Task<bool> AdministratorExistInDb(Guid? id)
        {
            //var url = new HttpRequestCustomUrl(_msConfigurationUrl, UserConstant.CONFIGURATION_API_ADMINISTRATOR_CHECK_IF_EXISTS_URL, string.Empty);
            //var request = new Dictionary<string, string>();
            //request.Add(UserConstant.PROPERTY_ID, id!.ToString()!);
            //var exists = await _httpRequestCustom.Get<HttpCustomDataResponse<AdministratorExistsSimpleResponseDto>>(url, request, null);

            //return exists!.Data!.Exists;
            return default;
        }

        public async Task<bool> BoundAdministratorUserExistsInDb(Guid? administratorId, Guid? userId)
        {
            //return await _context.BoundAdministratorUser.AsNoTracking()
            //            .AnyAsync(x => x.IdAdministrator == administratorId
            //                        && x.IdUsers == userId
            //                        && x.Removed);
            return default;
        }

        public async Task<bool> UserHaveAccessToAdministrator(Guid idUser, Guid idAdministrator)
        {
            //var query = await _context.BoundAdministratorUser
            //    .AsNoTracking()
            //    .Where(x => x.IdUsers == idUser && x.IdAdministrator == idAdministrator)
            //    .AnyAsync();

            //return query;
            return default;
        }

        public async Task Remover(Users user, CancellationToken cancellationToken = default)
        {
            _context.User.Remove(user);
        }
    }
}
