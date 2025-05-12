using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Domain.Commands.Produtos.Ncms.Adicionar;
using Domain.Commands.Produtos.Ncms;
using Domain.Commands.Produtos.Ncms.Atualizar;
using Domain.Commands.Produtos.Ncms.Excluir;

namespace Infra.IoC.Produtos
{
    public static class NcmDependencyInjection
    {
        public static void AddNcmDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarNcmCommand, FormularioResponse<AdicionarNcmCommand>>, AdicionarNcmCommandHandler>();
            services.AddTransient<IValidator<AdicionarNcmCommand>, AdicionarNcmCommandValidation>();
            services.AddTransient<IValidator<NcmCommand<AdicionarNcmCommand>>, NcmCommandValidation<AdicionarNcmCommand>>();

            services.AddScoped<IRequestHandler<AtualizarNcmCommand, FormularioResponse<AtualizarNcmCommand>>, AtualizarNcmCommandHandler>();
            services.AddTransient<IValidator<AtualizarNcmCommand>, AtualizarNcmCommandValidation>();
            services.AddTransient<IValidator<NcmCommand<AtualizarNcmCommand>>, NcmCommandValidation<AtualizarNcmCommand>>();

            services.AddScoped<IRequestHandler<ExcluirNcmCommand, List<FormularioResponse<ExcluirNcmCommand>>>, ExcluirNcmCommandHandler>();

            services.AddScoped<INcmRepository, NcmRepository>();
        }
    }
}
