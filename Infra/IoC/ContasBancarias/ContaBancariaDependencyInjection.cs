using Application.Interfaces.ContasBancarias;
using Application.Interfaces.Queries;
using Application.Services.ContasBancarias;
using Domain.Commands.ContasBancarias;
using Domain.Commands.ContasBancarias.Adicionar;
using Domain.Commands.ContasBancarias.Atualizar;
using Domain.Commands.ContasBancarias.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.ContasBancarias;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.ContasBancarias
{
    public static class ContaBancariaDependencyInjection
    {
        public static void AddContaBancariaDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarContaBancariaCommand, FormularioResponse<AdicionarContaBancariaCommand>>, AdicionarContaBancariaCommandHandler>();
            services.AddTransient<IValidator<AdicionarContaBancariaCommand>, AdicionarContaBancariaCommandValidation>();
            services.AddTransient<IValidator<ContaBancariaCommand<AdicionarContaBancariaCommand>>, ContaBancariaCommandValidation<AdicionarContaBancariaCommand>>();

            services.AddScoped<IRequestHandler<AtualizarContaBancariaCommand, FormularioResponse<AtualizarContaBancariaCommand>>, AtualizarContaBancariaCommandHandler>();
            services.AddTransient<IValidator<AtualizarContaBancariaCommand>, AtualizarContaBancariaCommandValidation>();
            services.AddTransient<IValidator<ContaBancariaCommand<AtualizarContaBancariaCommand>>, ContaBancariaCommandValidation<AtualizarContaBancariaCommand>>();

            services.AddScoped<IRequestHandler<ExcluirContaBancariaCommand, List<FormularioResponse<ExcluirContaBancariaCommand>>>, ExcluirContaBancariaCommandHandler>();

            services.AddScoped<IContaBancariaService, ContaBancariaService>();
            services.AddScoped<IContaBancariaQuery, ContaBancariaQuery>();
            services.AddScoped<IContaBancariaRepository, ContaBancariaRepository>();
        }
    }
}
