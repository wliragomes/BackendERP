using Application.Interfaces.DashBoards;
using Application.Interfaces.Queries;
using Application.Services.DashBoards;
using Infra.Queries.DashBoards;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC.DashBoards
{
    public static class DashBoardDependencyInjection
    {
        public static void AddDashBoardDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IDashBoardService, DashBoardService>();
            services.AddScoped<IDashBoardQuery, DashBoardQuery>();
        }
    }
}
