using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Domain.Commands.Produtos.Ruas.Adicionar;
using Domain.Commands.Produtos.Ruas;
using Domain.Commands.Produtos.Ruas.Atualizar;
using Domain.Commands.Produtos.Ruas.Excluir;
using Infra.Repositories;

namespace Infra.IoC.Produtos
{
    public static class RuaDependencyInjection
    {
        public static void AddRuaDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarRuaCommand, FormularioResponse<AdicionarRuaCommand>>, AdicionarRuaCommandHandler>();
            services.AddTransient<IValidator<AdicionarRuaCommand>, AdicionarRuaCommandValidation>();
            services.AddTransient<IValidator<RuaCommand<AdicionarRuaCommand>>, RuaCommandValidation<AdicionarRuaCommand>>();

            services.AddScoped<IRequestHandler<AtualizarRuaCommand, FormularioResponse<AtualizarRuaCommand>>, AtualizarRuaCommandHandler>();
            services.AddTransient<IValidator<AtualizarRuaCommand>, AtualizarRuaCommandValidation>();
            services.AddTransient<IValidator<RuaCommand<AtualizarRuaCommand>>, RuaCommandValidation<AtualizarRuaCommand>>();

            services.AddScoped<IRequestHandler<ExcluirRuaCommand, List<FormularioResponse<ExcluirRuaCommand>>>, ExcluirRuaCommandHandler>();

            services.AddScoped<IRuaRepository, RuaRepository>();
        }
    }
}
