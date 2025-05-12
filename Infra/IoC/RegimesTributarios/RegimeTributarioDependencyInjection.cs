using Application.Interfaces.RegimeTributarios;
using Application.Interfaces.Queries;
using Application.Services.RegimeTributarios;
using Domain.Commands.RegimeTributarios;
using Domain.Commands.RegimeTributarios.Adicionar;
using Domain.Commands.RegimeTributarios.Atualizar;
using Domain.Commands.RegimeTributarios.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.RegimeTributarios;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.RegimeTributarios
{
    public static class RegimeTributarioDependencyInjection
    {
        public static void AddRegimeTributarioDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarRegimeTributarioCommand, FormularioResponse<AdicionarRegimeTributarioCommand>>, AdicionarRegimeTributarioCommandHandler>();
            services.AddTransient<IValidator<AdicionarRegimeTributarioCommand>, AdicionarRegimeTributarioCommandValidation>();
            services.AddTransient<IValidator<RegimeTributarioCommand<AdicionarRegimeTributarioCommand>>, RegimeTributarioCommandValidation<AdicionarRegimeTributarioCommand>>();

            services.AddScoped<IRequestHandler<AtualizarRegimeTributarioCommand, FormularioResponse<AtualizarRegimeTributarioCommand>>, AtualizarRegimeTributarioCommandHandler>();
            services.AddTransient<IValidator<AtualizarRegimeTributarioCommand>, AtualizarRegimeTributarioCommandValidation>();
            services.AddTransient<IValidator<RegimeTributarioCommand<AtualizarRegimeTributarioCommand>>, RegimeTributarioCommandValidation<AtualizarRegimeTributarioCommand>>();

            services.AddScoped<IRequestHandler<ExcluirRegimeTributarioCommand, List<FormularioResponse<ExcluirRegimeTributarioCommand>>>, ExcluirRegimeTributarioCommandHandler>();

            services.AddScoped<IRegimeTributarioService, RegimeTributarioService>();
            services.AddScoped<IRegimeTributarioQuery, RegimeTributarioQuery>();
            services.AddScoped<IRegimeTributarioRepository, RegimeTributarioRepository>();
        }
    }
}
