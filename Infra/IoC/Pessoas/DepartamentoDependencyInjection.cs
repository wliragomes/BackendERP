using Domain.Commands.Departamentos;
using Domain.Commands.Departamentos.Adicionar;
using Domain.Commands.Departamentos.Atualizar;
using Domain.Commands.Departamentos.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Pessoas
{
    public static class DepartamentoDependencyInjection
    {
        public static void AddDepartamentoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarDepartamentoCommand, FormularioResponse<AdicionarDepartamentoCommand>>, AdicionarDepartamentoCommandHandler>();
            services.AddTransient<IValidator<AdicionarDepartamentoCommand>, AdicionarDepartamentoCommandValidation>();
            services.AddTransient<IValidator<DepartamentoCommand<AdicionarDepartamentoCommand>>, DepartamentoCommandValidation<AdicionarDepartamentoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarDepartamentoCommand, FormularioResponse<AtualizarDepartamentoCommand>>, AtualizarDepartamentoCommandHandler>();
            services.AddTransient<IValidator<AtualizarDepartamentoCommand>, AtualizarDepartamentoCommandValidation>();
            services.AddTransient<IValidator<DepartamentoCommand<AtualizarDepartamentoCommand>>, DepartamentoCommandValidation<AtualizarDepartamentoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirDepartamentoCommand, List<FormularioResponse<ExcluirDepartamentoCommand>>>, ExcluirDepartamentoCommandHandler>();

            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
        }
    }
}
