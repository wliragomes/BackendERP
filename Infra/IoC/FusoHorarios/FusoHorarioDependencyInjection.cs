using Application.Interfaces.FusoHorarios;
using Application.Interfaces.Queries;
using Application.Services.FusoHorarios;
using Domain.Commands.FusoHorarios;
using Domain.Commands.FusoHorarios.Adicionar;
using Domain.Commands.FusoHorarios.Atualizar;
using Domain.Commands.FusoHorarios.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.FusoHorarios;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.FusoHorarios
{
    public static class FusoHorarioDependencyInjection
    {
        public static void AddFusoHorarioDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarFusoHorarioCommand, FormularioResponse<AdicionarFusoHorarioCommand>>, AdicionarFusoHorarioCommandHandler>();
            services.AddTransient<IValidator<AdicionarFusoHorarioCommand>, AdicionarFusoHorarioCommandValidation>();
            services.AddTransient<IValidator<FusoHorarioCommand<AdicionarFusoHorarioCommand>>, FusoHorarioCommandValidation<AdicionarFusoHorarioCommand>>();

            services.AddScoped<IRequestHandler<AtualizarFusoHorarioCommand, FormularioResponse<AtualizarFusoHorarioCommand>>, AtualizarFusoHorarioCommandHandler>();
            services.AddTransient<IValidator<AtualizarFusoHorarioCommand>, AtualizarFusoHorarioCommandValidation>();
            services.AddTransient<IValidator<FusoHorarioCommand<AtualizarFusoHorarioCommand>>, FusoHorarioCommandValidation<AtualizarFusoHorarioCommand>>();

            services.AddScoped<IRequestHandler<ExcluirFusoHorarioCommand, List<FormularioResponse<ExcluirFusoHorarioCommand>>>, ExcluirFusoHorarioCommandHandler>();

            services.AddScoped<IFusoHorarioService, FusoHorarioService>();
            services.AddScoped<IFusoHorarioQuery, FusoHorarioQuery>();
            services.AddScoped<IFusoHorarioRepository, FusoHorarioRepository>();
        }
    }
}
