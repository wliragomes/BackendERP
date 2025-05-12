using Domain.Interfaces.Services;

namespace Application.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(IPagination filter, string route);
    }
}
