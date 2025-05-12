using Application.Interfaces.Empresas;
using Application.Interfaces.Queries;
using Application.Services.Empresas;
using Domain.Commands.Empresas;
using Domain.Commands.Empresas.Adicionar;
using Domain.Commands.Empresas.Atualizar;
using Domain.Commands.Empresas.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Empresas;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Empresas
{
    public static class EmpresaDependencyInjection
    {
        public static void AddEmpresaDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarEmpresaCommand, FormularioResponse<AdicionarEmpresaCommand>>, AdicionarEmpresaCommandHandler>();
            services.AddTransient<IValidator<AdicionarEmpresaCommand>, AdicionarEmpresaCommandValidation>();
            services.AddTransient<IValidator<EmpresaCommand<AdicionarEmpresaCommand>>, EmpresaCommandValidation<AdicionarEmpresaCommand>>();

            services.AddScoped<IRequestHandler<AtualizarEmpresaCommand, FormularioResponse<AtualizarEmpresaCommand>>, AtualizarEmpresaCommandHandler>();
            services.AddTransient<IValidator<AtualizarEmpresaCommand>, AtualizarEmpresaCommandValidation>();
            services.AddTransient<IValidator<EmpresaCommand<AtualizarEmpresaCommand>>, EmpresaCommandValidation<AtualizarEmpresaCommand>>();

            services.AddScoped<IRequestHandler<ExcluirEmpresaCommand, List<FormularioResponse<ExcluirEmpresaCommand>>>, ExcluirEmpresaCommandHandler>();

            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IEmpresaQuery, EmpresaQuery>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        }
    }
}
