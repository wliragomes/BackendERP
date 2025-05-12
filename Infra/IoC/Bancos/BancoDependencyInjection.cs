using Application.Interfaces.Bancos;
using Application.Interfaces.Queries;
using Application.Services.Bancos;
using Domain.Commands.Bancos;
using Domain.Commands.Bancos.Adicionar;
using Domain.Commands.Bancos.Atualizar;
using Domain.Commands.Bancos.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Bancos;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Bancos
{
    public static class BancoDependencyInjection
    {
        public static void AddBancoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarBancoCommand, FormularioResponse<AdicionarBancoCommand>>, AdicionarBancoCommandHandler>();
            services.AddTransient<IValidator<AdicionarBancoCommand>, AdicionarBancoCommandValidation>();
            services.AddTransient<IValidator<BancoCommand<AdicionarBancoCommand>>, BancoCommandValidation<AdicionarBancoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarBancoCommand, FormularioResponse<AtualizarBancoCommand>>, AtualizarBancoCommandHandler>();
            services.AddTransient<IValidator<AtualizarBancoCommand>, AtualizarBancoCommandValidation>();
            services.AddTransient<IValidator<BancoCommand<AtualizarBancoCommand>>, BancoCommandValidation<AtualizarBancoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirBancoCommand, List<FormularioResponse<ExcluirBancoCommand>>>, ExcluirBancoCommandHandler>();

            services.AddScoped<IBancoService, BancoService>();
            services.AddScoped<IBancoQuery, BancoQuery>();
            services.AddScoped<IBancoRepository, BancoRepository>();
        }
    }
}
