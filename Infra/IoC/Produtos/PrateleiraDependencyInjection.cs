using Domain.Commands.Produtos.Prateleiras;
using Domain.Commands.Produtos.Prateleiras.Adicionar;
using Domain.Commands.Produtos.Prateleiras.Atualizar;
using Domain.Commands.Produtos.Prateleiras.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Produtos
{
    public static class PrateleiraDependencyInjection
    {
        public static void AddPrateleiraDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarPrateleiraCommand, FormularioResponse<AdicionarPrateleiraCommand>>, AdicionarPrateleiraCommandHandler>();
            services.AddTransient<IValidator<AdicionarPrateleiraCommand>, AdicionarPrateleiraCommandValidation>();
            services.AddTransient<IValidator<PrateleiraCommand<AdicionarPrateleiraCommand>>, PrateleiraCommandValidation<AdicionarPrateleiraCommand>>();

            services.AddScoped<IRequestHandler<AtualizarPrateleiraCommand, FormularioResponse<AtualizarPrateleiraCommand>>, AtualizarPrateleiraCommandHandler>();
            services.AddTransient<IValidator<AtualizarPrateleiraCommand>, AtualizarPrateleiraCommandValidation>();
            services.AddTransient<IValidator<PrateleiraCommand<AtualizarPrateleiraCommand>>, PrateleiraCommandValidation<AtualizarPrateleiraCommand>>();

            services.AddScoped<IRequestHandler<ExcluirPrateleiraCommand, List<FormularioResponse<ExcluirPrateleiraCommand>>>, ExcluirPrateleiraCommandHandler>();

            services.AddScoped<IPrateleiraRepository, PrateleiraRepository>();
        }
    }
}
