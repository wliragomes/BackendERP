using Domain.Commands.Cartoes;
using Domain.Commands.Cartoes.Adicionar;
using Domain.Commands.Cartoes.Atualizar;
using Domain.Commands.Cartoes.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Cartoes
{
    public static class CartaoDependencyInjection
    {
        public static void AddCartaoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarCartaoCommand, FormularioResponse<AdicionarCartaoCommand>>, AdicionarCartaoCommandHandler>();
            services.AddTransient<IValidator<AdicionarCartaoCommand>, AdicionarCartaoCommandValidation>();
            services.AddTransient<IValidator<CartaoCommand<AdicionarCartaoCommand>>, CartaoCommandValidation<AdicionarCartaoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarCartaoCommand, FormularioResponse<AtualizarCartaoCommand>>, AtualizarCartaoCommandHandler>();
            services.AddTransient<IValidator<AtualizarCartaoCommand>, AtualizarCartaoCommandValidation>();
            services.AddTransient<IValidator<CartaoCommand<AtualizarCartaoCommand>>, CartaoCommandValidation<AtualizarCartaoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirCartaoCommand, List<FormularioResponse<ExcluirCartaoCommand>>>, ExcluirCartaoCommandHandler>();

            services.AddScoped<ICartaoRepository, CartaoRepository>();
        }
    }
}
