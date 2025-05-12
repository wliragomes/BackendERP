using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Domain.Commands.Auth;
using Domain.Commands.Auth.Login;
using Application.Interfaces.Auth;
using Application.Services.Auth;
using Domain.Commands.Auth.Refresh;
using Domain.Commands.Auth.UpdatePassword;

namespace Infra.IoC.Auth
{
    public static class AuthDependencyInjection
    {
        public static void AddAuthDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<LoginCommand, FormularioResponse<LoginCommand>>, LoginCommandHandler>();
            services.AddScoped<IRequestHandler<RefreshCommand, FormularioResponse<RefreshCommand>>, RefreshCommandHandler>();
            services.AddTransient<IValidator<LoginCommand>, LoginCommandValidation>();

            services.AddScoped<IRequestHandler<UpdateLoginPasswordCommand, FormularioResponse<UpdateLoginPasswordCommand>>, UpdatePasswordHandler>();
            services.AddTransient<IValidator<UpdateLoginPasswordCommand>, UpdatePasswordValidation>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
